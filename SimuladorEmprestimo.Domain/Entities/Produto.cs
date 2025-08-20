using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorEmprestimo.Domain.Entities {
    public class Produto {
        [Column("CO_PRODUTO")]
        public int Id { get; set; }

        [Column("NO_PRODUTO")]
        public String Nome { get; set; }

        [Column("PC_TAXA_JUROS")]
        public Decimal TaxaJurosMensal { get; set; }

        [Column("VR_MINIMO")]
        public Decimal ValorMinimo { get; set; }

        [Column("VR_MAXIMO")]
        public Decimal ValorMaximo { get; set; }

        [Column("NU_MINIMO_MESES")]
        public int PrazoMinimoMeses { get; set; }

        [Column("NU_MAXIMO_MESES")] 
        public int PrazoMaximoMeses { get; set; }


    }
}
