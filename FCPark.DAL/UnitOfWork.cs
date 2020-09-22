using FCPark.Core;
using FCPark.DAL.Repositories;
using System.Threading.Tasks;

namespace FCPark.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FCParkDbContext _context;
        private VeiculoRepository _veiculoRepository;
        private EstabelecimentoRepository _estabelecimentoRepository;
        private MovimentacaoVeiculoRepository _movimentacaoVeiculoRepository;

        public UnitOfWork(FCParkDbContext context)
        {
            this._context = context;
        }

        public IVeiculoRepository Veiculos => _veiculoRepository = _veiculoRepository ?? new VeiculoRepository(_context);

        public IEstabelecimentoRepository Estabelecimentos => _estabelecimentoRepository = _estabelecimentoRepository ?? new EstabelecimentoRepository(_context);
        public IMovimentacaoVeiculoRepository MovimentacaoVeiculos => _movimentacaoVeiculoRepository = _movimentacaoVeiculoRepository ?? new MovimentacaoVeiculoRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
