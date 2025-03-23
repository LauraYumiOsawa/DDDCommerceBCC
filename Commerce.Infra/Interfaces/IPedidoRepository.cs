using Commerce.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Commerce.Infra.Interfaces
{
    public interface IPedidoRepository
    {
        Task<List<Pedido>> GetAll();
        Task<Pedido> GetById(int id);
        Task<bool> Add(Pedido pedido);
        Task<bool> Update(int id, Pedido pedido);
        Task<bool> Delete(int id);
    }
}