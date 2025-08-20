using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorEmprestimo.Domain.Entities {
    public class Produto {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public Decimal TaxaJurosMensal { get; set; }
        public Decimal ValorMinimo { get; set; }
        public Decimal ValorMaximo { get; set; }
        public int PrazoMinimoMeses { get; set; }
        public int PrazoMaximoMeses { get; set; }

    }
}
