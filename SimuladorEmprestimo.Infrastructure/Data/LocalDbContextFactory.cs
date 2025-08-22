using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorEmprestimo.Infrastructure.Data {
    public class LocalDbContextFactory : IDesignTimeDbContextFactory<LocalDbContext>{

        public LocalDbContext CreateDbContext(string[] args) {
            string basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(),"..","SimuladorEmprestimo.API"));
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<LocalDbContext>();
            var connectionString = configuration.GetConnectionString("LocalDbConnection");

            builder.UseSqlServer(connectionString);

            return new LocalDbContext(builder.Options);
        }
    }
}
