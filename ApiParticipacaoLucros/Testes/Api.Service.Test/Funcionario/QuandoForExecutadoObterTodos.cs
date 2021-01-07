using ApiParticipacaoLucros.Domain.Dtos;
using ApiParticipacaoLucros.Domain.Interfaces.Services.Funcionario;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Funcionario
{
    public class QuandoForExecutadoObterTodos : FuncionarioTestes
    {
        private IFuncionarioService _service;
        private Mock<IFuncionarioService> _serviceMock;

        [Fact(DisplayName = "É possível obter todos os funcionários")]
        public async Task E_Possivel_Obter_Todos_Funcionarios()
        {
            _serviceMock = new Mock<IFuncionarioService>();
            _serviceMock.Setup(x => x.ObterTodos()).ReturnsAsync(listaFuncionarios);
            _service = _serviceMock.Object;

            var result = await _service.ObterTodos();
            Assert.NotNull(result);
            Assert.True(result.Count == 2);

        }
    }
}
