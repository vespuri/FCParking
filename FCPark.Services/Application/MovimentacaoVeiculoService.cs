using FCPark.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FCPark.Services
{
    public class MovimentacaoVeiculoService : IMovimentacaoVeiculoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MovimentacaoVeiculoService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<MovimentacaoVeiculo> CreateMovimentacao(MovimentacaoVeiculo movimentacaoVeiculo)
        {
            await _unitOfWork.MovimentacaoVeiculos
                .AddAsync(movimentacaoVeiculo);
            await _unitOfWork.CommitAsync();

            return movimentacaoVeiculo;
        }
        public async Task RegistrarSaidaVeiculo(MovimentacaoVeiculo movimentoVeiculoToBeUpdated, MovimentacaoVeiculo movimentacaoVeiculo)
        {

            movimentoVeiculoToBeUpdated.DataSaida = movimentacaoVeiculo.DataSaida;
            movimentoVeiculoToBeUpdated.DataEntrada = movimentacaoVeiculo.DataEntrada;

            await _unitOfWork.CommitAsync();
        }

        public async Task<MovimentacaoVeiculo> GetMovimentacaoById(int id)
        {
            return await _unitOfWork.MovimentacaoVeiculos.GetByIdAsync(id);
        }

        public async Task<MovimentacaoVeiculo> GetMovimentacaoPorPlaca(string placa)
        {
            return await _unitOfWork.MovimentacaoVeiculos.GetMovimentacaoPlacaHoje(placa);
        }
        public async Task<MovimentacaoVeiculo> GetMovimentacaoPorCPF(string CPF)
        {
            return await _unitOfWork.MovimentacaoVeiculos.GetMovimentacaoPlacaHoje(CPF);
        }
        public async Task<IEnumerable<MovimentacaoVeiculo>> GetAllMovimentacaoVeiculos()
        {
            return await _unitOfWork.MovimentacaoVeiculos.GetAllAsync();
        }
        public async Task<IEnumerable<MovimentacaoVeiculo>> GetEntradaSaidaVeiculosHora()
        {
            return await _unitOfWork.MovimentacaoVeiculos.GetAllAsync();
        }

        public async Task<List<TotalsReport>> GetMovimentacaoEntradaDiaHora(DateTime prData)
        {
            return await _unitOfWork.MovimentacaoVeiculos.GetTotalEntradaDiaHora(prData);
        }

        public async Task<List<TotalsReport>> GetMovimentacaoSaidaDiaHora(DateTime prData)
        {
            return await _unitOfWork.MovimentacaoVeiculos.GetTotalSaidaDiaHora(prData);
        }

        public async Task<List<TotalsReport>> GetTotalEntradaSaidaDia(DateTime prData)
        {
            return await _unitOfWork.MovimentacaoVeiculos.GetTotalEntradaSaidaDia(prData);
        }



    }
}
