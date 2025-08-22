using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorEmprestimo.Application.DTOs {
    public class ResultadoAmortizacaoDto {
        public String Tipo { get; set; }
        public List<ParcelaDto> Parcelas { get; set; } = new List<ParcelaDto>();

    }
}
