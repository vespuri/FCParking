using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FCPark.Core
{
    public interface IMovimentacaoVeiculoService
    {
        Task<MovimentacaoVeiculo> CreateMovimentacao(MovimentacaoVeiculo movimentacaoVeiculo);
        Task<MovimentacaoVeiculo> GetMovimentacaoById(int id);
        Task<IEnumerable<MovimentacaoVeiculo>> GetAllMovimentacaoVeiculos();
        Task RegistrarSaidaVeiculo(MovimentacaoVeiculo movimentoVeiculoToBeUpdated, MovimentacaoVeiculo saveMovimentacaoVeiculoResource);

        Task<MovimentacaoVeiculo> GetMovimentacaoPorPlaca(string placa);
        Task<MovimentacaoVeiculo> GetMovimentacaoPorCPF(string CPF);

        Task<List<TotalsReport>> GetMovimentacaoEntradaDiaHora(DateTime prData);
        Task<List<TotalsReport>> GetMovimentacaoSaidaDiaHora(DateTime prData);

        Task<List<TotalsReport>> GetTotalEntradaSaidaDia(DateTime prData);


    }
}
