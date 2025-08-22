using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SimuladorEmprestimo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorEmprestimo.Infrastructure.Data {
    public class AppDbContext : DbContext {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Simulacao> Simulacoes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // Mapeia a entidade Produto para a tabela PRODUTO
            modelBuilder.Entity<Produto>().ToTable("PRODUTO");

            // Mapeia a entidade Simulacao para a tabela SIMULACAO
            modelBuilder.Entity<Simulacao>().ToTable("SIMULACAO");

            modelBuilder.Entity<Simulacao>().
                HasOne<Produto>().
                WithMany().
                HasForeignKey(s => s.ProdutoId);
        }
    }
}
