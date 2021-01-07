using ApiParticipacaoLucros.Domain.Interfaces.Services.Funcionario;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace Api.Service.Test.Funcionario
{
    public class QuantoForExecutadoInserirInformacoes : FuncionarioTestes
    {
        private IFuncionarioService _service;
        private Mock<IFuncionarioService> _serviceMock;

        [Fact(DisplayName = "É possível inserir informações de funcionários")]
        public async Task E_Possivel_Inserir_Infos_Funcionarios()
        {
            _serviceMock = new Mock<IFuncionarioService>();
            _serviceMock.Setup(x => x.InserirInformacoes(listaFuncionarios)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var result = await _service.InserirInformacoes(listaFuncionarios);
            Assert.True(result);
        }
    }
}
