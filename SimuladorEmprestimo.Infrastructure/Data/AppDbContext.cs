using Microsoft.EntityFrameworkCore;
using SimuladorEmprestimo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorEmprestimo.Infrastructure.Data {
    public class AppDbContext : DbContext{
        public DbSet<Produto> Produtos { get; set; }
        public DbSet <Simulacao> Simulacaos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        }
    }
}
