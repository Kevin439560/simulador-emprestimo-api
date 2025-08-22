using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorEmprestimo.Domain.Entities {
    [Table("SIMULACAO")]
    public class Simulacao {
        public Guid Id { get; set; }
        public Decimal ValorSolicitado { get; set; }
        public int PrazoMeses { get; set; }
        public String ResultadoJson { get; set; }
        public DateTime DataSimulacao { get; set; }
        public int ProdutoId { get; set; }
        
        public Simulacao() {
            Id = Guid.NewGuid();
            DataSimulacao = DateTime.UtcNow;
        }
    }
}
