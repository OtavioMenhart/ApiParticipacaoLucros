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
    public class QuandoRequisitarDeletarTodos
    {
        private FuncionarioController _controller;

        [Fact(DisplayName = "É possível requisitar API para deletar funcionário")]
        public async Task E_Possivel_Atualizar_Funcionario()
        {
            var serviceMock = new Mock<IFuncionarioService>();

            serviceMock.Setup(x => x.Deletar("")).ReturnsAsync(true);

            _controller = new FuncionarioController(serviceMock.Object);


            var result = await _controller.DeletarTodos();
            Assert.True(result is OkObjectResult);

            string resultValue = ((OkObjectResult)result).Value as string;
            Assert.NotNull(resultValue);
            Assert.Equal("Usuários deletados", resultValue);

        }
    }
}
