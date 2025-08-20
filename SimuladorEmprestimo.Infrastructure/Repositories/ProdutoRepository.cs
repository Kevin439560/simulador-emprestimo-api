using Microsoft.EntityFrameworkCore;
using SimuladorEmprestimo.Domain.Entities;
using SimuladorEmprestimo.Domain.Interfaces;
using SimuladorEmprestimo.Infrastructure.Data;
using SimuladorEmprestimo.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorEmprestimo.Infrastructure.Repositories {
    public class ProdutoRepository : IProdutoRepository {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context) {
            _context = context;
        }
        public async Task<IEnumerable<Produto>> GetAllAsync() {

            return await _context.Produtos.ToListAsync();
        }
    }
}
