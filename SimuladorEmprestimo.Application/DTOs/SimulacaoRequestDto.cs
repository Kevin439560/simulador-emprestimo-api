using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorEmprestimo.Application.DTOs {
    public class SimulacaoRequestDto {
        public Decimal ValorSolicitado { get; set; }
        public int PrazoMeses { get; set; }
    }
}
