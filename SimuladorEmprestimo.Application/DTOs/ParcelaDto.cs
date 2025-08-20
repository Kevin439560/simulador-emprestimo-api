using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorEmprestimo.Application.DTOs {
    public class ParcelaDto {
        public int Numero { get; set; }
        public Decimal ValorAmortizacao { get; set; }
        public Decimal ValorJuros { get; set; }
        public Decimal ValorPrestacao { get; set; }
        public Decimal SaldoDevedor { get; set; }
    }
}
