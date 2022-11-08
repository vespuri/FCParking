using FCPark.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FCPark.Core
{
    public interface IMovimentacaoVeiculoRepository : IRepository<MovimentacaoVeiculo>
    {
        Task<MovimentacaoVeiculo> GetMovimentacaoPorPlaca(string prPlaca);
        Task<MovimentacaoVeiculo> GetMovimentacaoPorCPF(string prCPF);

        Task<MovimentacaoVeiculo> GetMovimentacaoPlacaHoje(string prPlaca);
        Task<List<MovimentacaoVeiculo>> GetMovimentacaoPlacaDia(DateTime prData);
        Task<List<MovimentacaoVeiculo>> GetMovimentacaoSemSaida(DateTime prData);

        Task<List<TotalsReport>> GetTotalEntradaDiaHora(DateTime prData);
        Task<List<TotalsReport>> GetTotalSaidaDiaHora(DateTime prData);
        Task<List<TotalsReport>> GetTotalEntradaSaidaDia(DateTime prData);
    }
}
