using System.Collections.Generic;
using System.Threading.Tasks;
using FCPark.Core;

namespace FCPark.Core
{
    public interface IEstabelecimentoService
    {
        Task<IEnumerable<Estabelecimento>> GetAllEstabelecimentos();
        Task<Estabelecimento> GetEstabelecimentoById(int id);
        Task<Estabelecimento> CreateEstabelecimento(Estabelecimento newEstabelecimento);
        Task UpdateEstabelecimento(Estabelecimento estabelecimentoToBeUpdated, Estabelecimento estabelecimento);
        Task DeleteEstabelecimento(Estabelecimento estabelecimento);
    }
}