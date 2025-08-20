using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimuladorEmprestimo.Domain.Entities;

namespace SimuladorEmprestimo.Domain.Interfaces {
    public interface ISimulacaoRepository {
        Task AddAsync(Simulacao simulacao);
    }
}
