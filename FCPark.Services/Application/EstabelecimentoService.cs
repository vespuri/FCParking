using FCPark.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FCPark.Services
{

    public class EstabelecimentoService : IEstabelecimentoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EstabelecimentoService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Estabelecimento> CreateEstabelecimento(Estabelecimento newEstabelecimento)
        {
            await _unitOfWork.Estabelecimentos
                .AddAsync(newEstabelecimento);
            await _unitOfWork.CommitAsync();

            return newEstabelecimento;
        }
        public async Task DeleteEstabelecimento(Estabelecimento estabelecimento)
        {
            _unitOfWork.Estabelecimentos.Remove(estabelecimento);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Estabelecimento>> GetAllEstabelecimentos()
        {
            return await _unitOfWork.Estabelecimentos.GetAllAsync();
        }

        public async Task<Estabelecimento> GetEstabelecimentoById(int id)
        {
            return await _unitOfWork.Estabelecimentos.GetByIdAsync(id);
        }

        public async Task UpdateEstabelecimento(Estabelecimento estabelecimentoToBeUpdated, Estabelecimento estabelecimento)
        {
            estabelecimentoToBeUpdated.Nome = estabelecimento.Nome;
            estabelecimentoToBeUpdated.CNPJ = estabelecimento.CNPJ;
            estabelecimentoToBeUpdated.Telefone = estabelecimento.Telefone;
            estabelecimentoToBeUpdated.Endereco = estabelecimento.Endereco;
            estabelecimentoToBeUpdated.QtdVagasCarros = estabelecimento.QtdVagasCarros;
            estabelecimentoToBeUpdated.QtdVagasMotos = estabelecimento.QtdVagasMotos;

            await _unitOfWork.CommitAsync();
        }
    }
}
