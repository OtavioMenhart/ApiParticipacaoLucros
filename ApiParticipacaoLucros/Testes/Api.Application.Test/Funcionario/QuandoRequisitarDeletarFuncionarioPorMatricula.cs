using ApiParticipacaoLucros.Application.Controllers;
using ApiParticipacaoLucros.Domain.Interfaces.Services.Funcionario;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Test.Funcionario
{
    public class QuandoRequisitarDeletarFuncionarioPorMatricula
    {
        private FuncionarioController _controller;

        [Fact(DisplayName = "É possível requisitar API para deletar funcionário")]
        public async Task E_Possivel_Atualizar_Funcionario()
        {
            var serviceMock = new Mock<IFuncionarioService>();

            serviceMock.Setup(x => x.Deletar(It.IsAny<string>())).ReturnsAsync(true);

            _controller = new FuncionarioController(serviceMock.Object);


            var result = await _controller.DeletarFuncionarioPorMatricula(It.IsAny<string>());
            Assert.True(result is OkObjectResult);
            
            string resultValue = ((OkObjectResult)result).Value as string;
            Assert.NotNull(resultValue);
            Assert.Equal("Usuário deletado", resultValue);

        }
    }
}
