using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApi.Context;
using WebApi.Repositorio;
using WebApi.Repositorio.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



//Json - Serialização e desserialização - ignoreCycle acabanco com o ciclo dos objetos produto e categoria

builder.Services.AddControllers().AddJsonOptions(options =>
options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//Banco de dados
builder.Services.AddDbContext<appContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Repositorio
builder.Services.AddTransient<IProdutosRepository, ProdutoRepository>();
builder.Services.AddTransient<ICategoriasRepository, CategoriasRepository>();




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
