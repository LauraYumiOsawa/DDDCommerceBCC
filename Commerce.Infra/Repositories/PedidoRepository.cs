using Commerce.Domain;
using Commerce.Infra;
using Commerce.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Commerce.Infra.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;

        public PedidoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pedido>> GetAll()
        {
            return await _context.Pedidos.ToListAsync();
        }

        public async Task<Pedido> GetById(int id)
        {
            return await _context.Pedidos.FindAsync(id);
        }

        public async Task<bool> Add(Pedido pedido)
        {
            if (pedido == null) return false;
            await _context.Pedidos.AddAsync(pedido);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(int id, Pedido pedido)
        {
            var pedidoExistente = await _context.Pedidos.FindAsync(id);
            if (pedidoExistente == null) return false;

            pedidoExistente.Comprador = pedido.Comprador;
            pedidoExistente.Descricao = pedido.Descricao;
            pedidoExistente.Preco = pedido.Preco;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null) return false;

            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}