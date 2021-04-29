using FCPark.Core;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FCPark.DAL
{
    public class ClienteRepository : RepositoryBaseEF<Cliente>, IClienteRepository
    {
        public ClienteRepository(FCParkDbContext context)
        : base(context)
        {

        }

    
    }
}