using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorEmprestimo.Domain.Entities {
    public class Simulacao {
        public Guid Id { get; set; }
        public Decimal ValorSolicitado { get; set; }
        public int PrazoMeses { get; set; }
        public String ResultadoJson { get; set; }
        public DateTime DataSimulacao { get; set; }
        public Guid ProdutoId { get; set; }
        
        public Simulacao() {
            Id = Guid.NewGuid();
            DataSimulacao = DateTime.UtcNow;
        }
    }
}
