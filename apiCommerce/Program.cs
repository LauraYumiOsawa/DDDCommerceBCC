using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Commerce.Infra;
using Commerce.Infra.Repositories;
using Commerce.Infra.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

builder.Services.AddControllers()
    .AddApplicationPart(Assembly.Load("apiCommerce"));

var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.Run();