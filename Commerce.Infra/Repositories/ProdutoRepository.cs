using Commerce.Domain;
using Commerce.Infra;
using Commerce.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Commerce.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Produto>> GetAll()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> GetById(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<bool> Add(Produto produto)
        {
            if (produto == null) return false;
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(int id, Produto produto)
        {
            var produtoExistente = await _context.Produtos.FindAsync(id);
            if (produtoExistente == null) return false;

            produtoExistente.Nome = produto.Nome;
            produtoExistente.Descricao = produto.Descricao;
            produtoExistente.Preco = produto.Preco;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null) return false;

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}