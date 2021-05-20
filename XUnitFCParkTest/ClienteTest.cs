using FCPark.Core;
using FCPark.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitFCParkTest
{
    public class ClienteTest
    {
        private readonly Mock<IClienteService> _clienteServiceMock;
        Cliente _cliente;

        public ClienteTest()
        {
            _clienteServiceMock = new Mock<IClienteService>();

        }
        [Fact]
        public void GetByIdAsync_Retorno_Cliente()
        {
            var clienteId = 1;
            var CPFCliente = "48111799861";

            _cliente = new Cliente
            {
                Id = clienteId,
                CPF = CPFCliente,
            };
            _clienteServiceMock.Setup(service => service.GetClienteById(clienteId)).ReturnsAsync(_cliente);

            var clienteRepositoryMock = new Mock<IClienteRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.Clientes).Returns(clienteRepositoryMock.Object);

            IClienteService sut = new ClienteService(unitOfWorkMock.Object);
            var actual = _clienteServiceMock.Object.GetClienteById(clienteId);


            _clienteServiceMock.Verify();
            Assert.NotNull(actual.Result);
            Assert.Equal(_cliente.CPF, actual.Result.CPF);
        }
    }
}
