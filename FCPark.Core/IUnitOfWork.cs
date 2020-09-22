using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FCPark.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IVeiculoRepository Veiculos { get; }
        IEstabelecimentoRepository Estabelecimentos { get; }

        IMovimentacaoVeiculoRepository MovimentacaoVeiculos { get; }
        Task<int> CommitAsync();
    }
}
