using Commerce.Domain;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Infra;

public class AppDbContext : DbContext
{
    
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseMySql("Server=localhost;Database=ECommerceDB;User=root;Password=minhasenha;",
            new MySqlServerVersion(new Version(8, 0, 32)));
    }
}