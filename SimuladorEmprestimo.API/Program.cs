using Microsoft.EntityFrameworkCore;
using SimuladorEmprestimo.Application.Interfaces;
using SimuladorEmprestimo.Application.Services;
using SimuladorEmprestimo.Domain.Interfaces;
using SimuladorEmprestimo.Infrastructure.Data;
using SimuladorEmprestimo.Infrastructure.Repositories;
using SimuladorEmprestimo.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var defaultConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(defaultConnectionString));

var localConnectionString = builder.Configuration.GetConnectionString("LocalDbConnection");
builder.Services.AddDbContext<LocalDbContext>(options =>
    options.UseSqlServer(localConnectionString));

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<ISimulacaoRepository, SimulacaoRepository>();
builder.Services.AddScoped<ISimulacaoService, SimulacaoService>();
builder.Services.AddScoped<IEventHubService, EventHubService>();

var app = builder.Build();


if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
