using FCPark.Core;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FCPark.DAL
{
    public class EstabelecimentoRepository : RepositoryBaseEF<Estabelecimento>, IEstabelecimentoRepository
    {
        public EstabelecimentoRepository(FCParkDbContext context)
        : base(context){

        }

        public Task<Estabelecimento> GetEstabelecimentoCNPJ(string prCNPJ)
        {
            return FCParkDbContext.Estabelecimentos
                .SingleOrDefaultAsync(a => a.CNPJ == prCNPJ);
        }

        private FCParkDbContext FCParkDbContext
        {
            get { return _context as FCParkDbContext; }
        }
    }
}
