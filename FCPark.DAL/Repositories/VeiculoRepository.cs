using FCPark.Core;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FCPark.DAL
{
    public class VeiculoRepository : RepositoryBaseEF<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(FCParkDbContext context)
    : base(context)
        { }
        public Task<Veiculo> GetVeiculoPorPlaca(string prPlaca)
        {
            return FCParkDbContext.Veiculos
                .SingleOrDefaultAsync(a => a.Placa == prPlaca);
        }

        private FCParkDbContext FCParkDbContext
        {
            get { return _context as FCParkDbContext; }
        }
    }
}
