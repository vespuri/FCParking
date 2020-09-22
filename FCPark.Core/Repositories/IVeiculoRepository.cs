using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FCPark.Core
{
    public interface IVeiculoRepository : IRepository<Veiculo>
    {
        Task<Veiculo> GetVeiculoPorPlaca(string prPlaca);
    }
}
