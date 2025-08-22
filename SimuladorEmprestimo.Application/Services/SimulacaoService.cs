using SimuladorEmprestimo.Application.DTOs;
using SimuladorEmprestimo.Application.Interfaces;
using SimuladorEmprestimo.Domain.Entities;
using SimuladorEmprestimo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorEmprestimo.Application.Services {
    public class SimulacaoService : ISimulacaoService{
        private readonly IProdutoRepository _produtoRepository;
        private readonly ISimulacaoRepository _simulacaoRepository;
        private readonly IEventHubService _eventHubService;

        public SimulacaoService(IProdutoRepository produtoRepository, ISimulacaoRepository simulacaoRepository, IEventHubService eventHubService) {
            _produtoRepository = produtoRepository;
            _simulacaoRepository = simulacaoRepository;
            _eventHubService = eventHubService;
        }

        public async Task<SimulacaoResponseDto> SimularEmprestimoAsync(SimulacaoRequestDto requestDto) {

            var produtos = await _produtoRepository.GetAllAsync();

            var produtoAdequado = produtos.FirstOrDefault(p => 
            requestDto.ValorSolicitado >= p.ValorMinimo && 
            requestDto.ValorSolicitado <= p.ValorMaximo && 
            requestDto.PrazoMeses >= p.PrazoMinimoMeses && 
            requestDto.PrazoMeses <= p.PrazoMaximoMeses);

            if (produtoAdequado == null) {
                throw new InvalidOperationException("Nenhum produto adequado encontrado para os critérios informados.");
            }
            var simulacao = new SimulacaoResponseDto {
                NomeProduto = produtoAdequado.Nome,
                ValorSolicitado = requestDto.ValorSolicitado,
                PrazoMeses = requestDto.PrazoMeses
            };

            var ResultadoSAC = CalcularSAC(requestDto.ValorSolicitado, requestDto.PrazoMeses, produtoAdequado.TaxaJurosMensal);

            var ResultadoPrice = CalcularPrice(requestDto.ValorSolicitado, requestDto.PrazoMeses, produtoAdequado.TaxaJurosMensal);

            var response = new SimulacaoResponseDto {
                NomeProduto = produtoAdequado.Nome,
                ValorSolicitado = requestDto.ValorSolicitado,
                PrazoMeses = requestDto.PrazoMeses,
            
            };

            response.Resultados.Add(ResultadoSAC);
            response.Resultados.Add(ResultadoPrice);
            
            var simulacaoEntity = new Simulacao {
                ValorSolicitado = requestDto.ValorSolicitado,
                PrazoMeses = requestDto.PrazoMeses,
                ProdutoId = produtoAdequado.Id,
                ResultadoJson = System.Text.Json.JsonSerializer.Serialize(response),
            };

            await _simulacaoRepository.AddAsync(simulacaoEntity);
            await _eventHubService.EnviarEventoAsync(simulacaoEntity.ResultadoJson);

            return response;
        }

        private ResultadoAmortizacaoDto CalcularSAC(decimal valor, int prazoMeses, decimal taxaJurosMensal) {
            var resultado = new ResultadoAmortizacaoDto { Tipo = "SAC" };
            var saldoDevedor = valor;
            var valorAmortizacao = valor / prazoMeses;

            for(int i= 1; i <= prazoMeses; i++) {
                var jurosMes = saldoDevedor * taxaJurosMensal;
                var prestacao = valorAmortizacao + jurosMes;
                saldoDevedor -= valorAmortizacao;

                resultado.Parcelas.Add(new ParcelaDto {
                    Numero = i,
                    ValorAmortizacao = Math.Round(valorAmortizacao, 2),
                    ValorJuros = Math.Round(jurosMes,2),
                    ValorPrestacao = Math.Round(prestacao,2),
                    SaldoDevedor = Math.Round(Math.Max(0, saldoDevedor), 2)
                });

            }
            return resultado;
        }

        private ResultadoAmortizacaoDto CalcularPrice(decimal valor, int prazoMeses, decimal taxaJurosMensal) {
            var resultado = new ResultadoAmortizacaoDto { Tipo = "Price" };
            var saldoDevedor = valor;

            var taxa = (double)taxaJurosMensal;
            var prestacao = valor * (decimal)(taxa * Math.Pow(1 + taxa, prazoMeses)) / (decimal)(Math.Pow(1 + taxa, prazoMeses) - 1);

            for (int i = 1; i <= prazoMeses; i++) {
                var jurosMes = saldoDevedor * taxaJurosMensal;
                var valorAmortizacao = prestacao - jurosMes;
                saldoDevedor -= valorAmortizacao;

                resultado.Parcelas.Add(new ParcelaDto {
                    Numero = i,
                    ValorAmortizacao = Math.Round(valorAmortizacao, 2),
                    ValorJuros = Math.Round(jurosMes, 2),
                    ValorPrestacao = Math.Round(prestacao, 2),
                    SaldoDevedor = Math.Round(Math.Max(0, saldoDevedor), 2)
                });
            }

            return resultado;
        }
    }
}
