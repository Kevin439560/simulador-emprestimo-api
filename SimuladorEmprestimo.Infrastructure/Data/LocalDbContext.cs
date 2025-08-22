using Microsoft.EntityFrameworkCore;
using SimuladorEmprestimo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorEmprestimo.Infrastructure.Data {
    public class LocalDbContext : DbContext{

        public DbSet<Simulacao> Simulacoes { get; set; }

        public LocalDbContext(DbContextOptions<LocalDbContext> options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Simulacao>().ToTable("SIMULACAO");

        }
    }
}
