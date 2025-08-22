using SimuladorEmprestimo.Domain.Entities;
using SimuladorEmprestimo.Domain.Interfaces;
using SimuladorEmprestimo.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorEmprestimo.Infrastructure.Repositories {
    public class SimulacaoRepository : ISimulacaoRepository{

        private readonly LocalDbContext _context;

        public SimulacaoRepository(LocalDbContext context) {
            _context = context;
        }
        public async Task AddAsync(Simulacao simulacao) {

            await _context.Simulacoes.AddAsync(simulacao);

            await _context.SaveChangesAsync();

        }
    }
}
