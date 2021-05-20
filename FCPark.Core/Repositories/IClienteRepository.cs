using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FCPark.Core
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> GetClientePorCPF(string prCPF);

    }
}
