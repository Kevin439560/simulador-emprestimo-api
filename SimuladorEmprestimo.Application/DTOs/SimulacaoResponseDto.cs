
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorEmprestimo.Application.DTOs {
    public class SimulacaoResponseDto {
        public String NomeProduto { get; set; }
        public Decimal ValorSolicitado { get; set; }
        public int PrazoMeses { get; set; }
        public List<ResultadoAmortizacaoDto> Resultados { get; set; } = new List<ResultadoAmortizacaoDto>();
    }
}
