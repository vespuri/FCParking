using System.Collections.Generic;
using System.Threading.Tasks;
using FCPark.Core;

namespace FCPark.Core
{
    public interface IVeiculoService
    {
        Task<IEnumerable<Veiculo>> GetAllVeiculos();
        Task<Veiculo> GetVeiculoById(int id);
        Task<Veiculo> CreateVeiculo(Veiculo newVeiculo);
        Task UpdateVeiculo(Veiculo veiculoToBeUpdated, Veiculo veiculo);
        Task DeleteVeiculo(Veiculo veiculo);
    }
}