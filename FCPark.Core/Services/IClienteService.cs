using System.Collections.Generic;
using System.Threading.Tasks;
using FCPark.Core;

namespace FCPark.Core
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetAllClientes();
        Task<Cliente> GetClienteById(int id);
        Task<Cliente> CreateCliente(Cliente newCliente);
        Task UpdateCliente(Cliente clienteToBeUpdated, Cliente cliente);
        Task DeleteCliente(Cliente cliente);

    }
}