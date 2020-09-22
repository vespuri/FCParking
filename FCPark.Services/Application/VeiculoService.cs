using FCPark.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FCPark.Services
{

    public class VeiculoService : IVeiculoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public VeiculoService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Veiculo> CreateVeiculo(Veiculo newVeiculo)
        {
            await _unitOfWork.Veiculos
                .AddAsync(newVeiculo);
            await _unitOfWork.CommitAsync();

            return newVeiculo;
        }
        public async Task DeleteVeiculo(Veiculo veiculo)
        {
            _unitOfWork.Veiculos.Remove(veiculo);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Veiculo>> GetAllVeiculos()
        {
            return await _unitOfWork.Veiculos.GetAllAsync();
        }

        public async Task<Veiculo> GetVeiculoById(int id)
        {
            return await _unitOfWork.Veiculos.GetByIdAsync(id);
        }

        public async Task UpdateVeiculo(Veiculo veiculoToBeUpdated, Veiculo veiculo)
        {
            veiculoToBeUpdated.Modelo = veiculo.Modelo;
            veiculoToBeUpdated.Placa = veiculo.Placa;
            veiculoToBeUpdated.Tipo = veiculo.Tipo;
            veiculoToBeUpdated.Cor = veiculo.Cor;
            veiculoToBeUpdated.Marca = veiculo.Marca;

            await _unitOfWork.CommitAsync();
        }
    }
}
