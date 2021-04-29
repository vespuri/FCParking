using FCPark.Core;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace FCPark.Services
{

    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClienteService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Cliente> CreateCliente(Cliente newCliente)
        {
            await _unitOfWork.Clientes
                .AddAsync(newCliente);
            await _unitOfWork.CommitAsync();

            return newCliente;
        }
        public async Task DeleteCliente(Cliente cliente)
        {
            _unitOfWork.Clientes.Remove(cliente);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Cliente>> GetAllClientes()
        {
            return await _unitOfWork.Clientes.GetAllAsync();
        }

        public async Task<Cliente> GetClienteById(int id)
        {
            return await _unitOfWork.Clientes.GetByIdAsync(id);
        }

        public async Task UpdateCliente(Cliente clienteToBeUpdated, Cliente cliente)
        {
            clienteToBeUpdated.Nome = cliente.Nome;
            clienteToBeUpdated.Telefone = cliente.Telefone;
            clienteToBeUpdated.Endereco = cliente.Endereco;

            await _unitOfWork.CommitAsync();
        }
    }
}

