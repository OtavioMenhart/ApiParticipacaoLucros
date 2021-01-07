using ApiParticipacaoLucros.Domain.Interfaces.Services.Funcionario;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Funcionario
{
    public class QuandoForExecutadoDeletar : FuncionarioTestes
    {
        private IFuncionarioService _service;
        private Mock<IFuncionarioService> _serviceMock;

        [Fact(DisplayName = "É possível deletar funcionário(s)")]
        public async Task E_Possivel_Deletar_Funcionarios()
        {
            _serviceMock = new Mock<IFuncionarioService>();
            _serviceMock.Setup(x => x.Deletar(listaFuncionarios[0].matricula)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deletado = await _service.Deletar(listaFuncionarios[0].matricula);
            Assert.True(deletado);

            _serviceMock = new Mock<IFuncionarioService>();
            _serviceMock.Setup(x => x.Deletar("")).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deletadoTodos = await _service.Deletar();
            Assert.True(deletadoTodos);
        }
    }
}
