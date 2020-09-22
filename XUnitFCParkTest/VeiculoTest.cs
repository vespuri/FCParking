using FCPark.Core;
using FCPark.Services;
using Moq;
using Xunit;


namespace XUnitFCParkTest
{
    public class VeiculoTest
    {
        private readonly Mock<IVeiculoService> _veiculoServiceMock;
        Veiculo _veiculo;

        public VeiculoTest()
        {
            _veiculoServiceMock = new Mock<IVeiculoService>();

        }
        [Fact]
        public void GetByIdAsync_Retorno_Veiculo()
        {
            var veiculoId = 1;
            var placaVeiculo = "UMDEALX";

            _veiculo = new Veiculo
            {
                Id = veiculoId,
                Placa = placaVeiculo
            };
            _veiculoServiceMock.Setup(service => service.GetVeiculoById(veiculoId)).ReturnsAsync(_veiculo);

            var veiculoRepositoryMock = new Mock<IVeiculoRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.Veiculos).Returns(veiculoRepositoryMock.Object);

            IVeiculoService sut = new VeiculoService(unitOfWorkMock.Object);
            var actual = _veiculoServiceMock.Object.GetVeiculoById(veiculoId);


            _veiculoServiceMock.Verify();
            Assert.NotNull(actual.Result);
            Assert.Equal(_veiculo.Placa, actual.Result.Placa);
        }
    }
}
