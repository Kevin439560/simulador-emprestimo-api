using Microsoft.AspNetCore.Mvc;
using SimuladorEmprestimo.Application.DTOs;
using SimuladorEmprestimo.Application.Interfaces;

namespace SimuladorEmprestimo.API.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class SimulacaoController : Controller {

        private readonly ISimulacaoService _simulacaoService;
        public SimulacaoController(ISimulacaoService simulacaoService) {
            _simulacaoService = simulacaoService;
        }

        [HttpPost]
        public async Task<IActionResult> Simular([FromBody] SimulacaoRequestDto requestDto) {

            try {

                var resultado = await _simulacaoService.SimularEmprestimoAsync(requestDto);
                return Ok(resultado);

            } catch (ArgumentException ex) {

                return BadRequest(new { Mensagem = ex.Message });

            } catch (Exception ex) {

                return StatusCode(500, new { Mensagem = "Ocorreu um erro ao processar a simulação.", Detalhes = ex.Message });


            }
        }
    }
}
