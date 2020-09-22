using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FCPark.Core
{
    public interface IEstabelecimentoRepository : IRepository<Estabelecimento>
    {
        Task<Estabelecimento> GetEstabelecimentoCNPJ(string prCNPJ);
    }
}
