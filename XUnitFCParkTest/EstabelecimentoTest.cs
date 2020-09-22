using FCPark.Core;
using FCPark.Services;
using Moq;
using Xunit;

namespace XUnitFCParkTest
{
    public class EstabelecimentoTest
    {
        private readonly Mock<IEstabelecimentoService> _estabelecimentoServiceMock;
        Estabelecimento _estabelecimento;

        public EstabelecimentoTest()
        {
            _estabelecimentoServiceMock = new Mock<IEstabelecimentoService>();

        }

        [Fact]
        public void GetByIdAsync_Retorno_Estabelecimento()
        {
            var estabelecimentoId = 1;
            var nomeEstabelecimento = "NOME MOCK";

            _estabelecimento = new Estabelecimento
            {
                Id = estabelecimentoId,
                CNPJ = "012354456",
                Endereco = "KASDKJHASDKJASD",
                Nome = nomeEstabelecimento,
                QtdVagasCarros = 60,
                QtdVagasMotos = 70,
                Telefone = "34646548"
            };
            _estabelecimentoServiceMock.Setup(service => service.GetEstabelecimentoById(estabelecimentoId)).ReturnsAsync(_estabelecimento);

            var estabelecimentoRepositoryMock = new Mock<IEstabelecimentoRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.Estabelecimentos).Returns(estabelecimentoRepositoryMock.Object);

            IEstabelecimentoService sut = new EstabelecimentoService(unitOfWorkMock.Object);
            var actual = _estabelecimentoServiceMock.Object.GetEstabelecimentoById(estabelecimentoId);


            _estabelecimentoServiceMock.Verify();
            Assert.NotNull(actual.Result);
            Assert.Equal(_estabelecimento.Nome, actual.Result.Nome);
        }
   }
}
