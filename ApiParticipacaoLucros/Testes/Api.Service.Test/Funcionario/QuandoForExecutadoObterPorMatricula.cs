using ApiParticipacaoLucros.Domain.Interfaces.Services.Funcionario;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Funcionario
{
    public class QuandoForExecutadoObterPorMatricula : FuncionarioTestes
    {
        private IFuncionarioService _service;
        private Mock<IFuncionarioService> _serviceMock;

        [Fact(DisplayName = "É possível obter funcionário por matrícula")]
        public async Task E_Possivel_Obter_Funcionario_Matricula()
        {
            _serviceMock = new Mock<IFuncionarioService>();
            _serviceMock.Setup(x => x.ObterPorMatricula(listaFuncionarios[0].matricula)).ReturnsAsync(funcionarioObtido);
            _service = _serviceMock.Object;

            var result = await _service.ObterPorMatricula(listaFuncionarios[0].matricula);
            Assert.NotNull(result);
            Assert.True(result.matricula == listaFuncionarios[0].matricula);
            Assert.Equal(listaFuncionarios[0].nome, result.nome);
        }
    }
}
