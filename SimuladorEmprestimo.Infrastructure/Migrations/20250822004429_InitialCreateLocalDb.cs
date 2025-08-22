using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimuladorEmprestimo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateLocalDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SIMULACAO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValorSolicitado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrazoMeses = table.Column<int>(type: "int", nullable: false),
                    ResultadoJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataSimulacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SIMULACAO", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SIMULACAO");
        }
    }
}
