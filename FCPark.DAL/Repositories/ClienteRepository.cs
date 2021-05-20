using FCPark.Core;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FCPark.DAL
{
    public class ClienteRepository : RepositoryBaseEF<Cliente>, IClienteRepository
    {
        public ClienteRepository(FCParkDbContext context)
        : base(context)
        { }
        public Task<Cliente> GetClientePorCPF(string prCPF)
        {
            return FCParkDbContext.Clientes
                .SingleOrDefaultAsync(a => a.CPF == prCPF);
        }

        private FCParkDbContext FCParkDbContext
        {
            get { return _context as FCParkDbContext; }
        }
    }
}