using ApiParticipacaoLucros.Domain.Interfaces.Services.Funcionario;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace Api.Service.Test.Funcionario
{
    public class QuandoForExecutadoAtualizarFuncionario : FuncionarioTestes
    {
        private IFuncionarioService _service;
        private Mock<IFuncionarioService> _serviceMock;

        [Fact(DisplayName = "É possível atualizar informações do funcionário")]
        public async Task E_Possivel_Atualizar_Infos_Funcionario()
        {
            _serviceMock = new Mock<IFuncionarioService>();
            _serviceMock.Setup(x => x.InserirInformacoes(listaFuncionarios)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var result = await _service.InserirInformacoes(listaFuncionarios);
            Assert.True(result);

            _serviceMock = new Mock<IFuncionarioService>();
            _serviceMock.Setup(x => x.AtualizarFuncionario(funcionarioAtualizar)).ReturnsAsync(funcionarioAtualizado);
            _service = _serviceMock.Object;

            var resultAtualizacao = await _service.AtualizarFuncionario(funcionarioAtualizar);
            Assert.NotNull(resultAtualizacao);
            Assert.Equal(resultAtualizacao.cargo, cargoAlterado);
            Assert.Equal(resultAtualizacao.area, areaAlterado);
            Assert.Equal(resultAtualizacao.matricula, listaFuncionarios[0].matricula);
        }
    }
}
