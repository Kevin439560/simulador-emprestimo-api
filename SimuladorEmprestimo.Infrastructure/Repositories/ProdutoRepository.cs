// Garanta que estes 'usings' estão no topo do seu arquivo
using Microsoft.EntityFrameworkCore;
using SimuladorEmprestimo.Domain.Entities;
using SimuladorEmprestimo.Domain.Interfaces;
using SimuladorEmprestimo.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimuladorEmprestimo.Infrastructure.Repositories {
    public class ProdutoRepository : IProdutoRepository {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetAllAsync() {
            // Esta linha depende do "using Microsoft.EntityFrameworkCore;"
            return await _context.Produtos.ToListAsync();
        }
    }
}