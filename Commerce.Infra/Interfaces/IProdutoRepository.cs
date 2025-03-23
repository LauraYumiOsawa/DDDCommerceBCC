using Commerce.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Commerce.Infra.Interfaces
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> GetAll();
        Task<Produto> GetById(int id);
        Task<bool> Add(Produto produto);
        Task<bool> Update(int id, Produto produto);
        Task<bool> Delete(int id);
    }
}