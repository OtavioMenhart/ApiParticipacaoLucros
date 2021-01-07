using ApiParticipacaoLucros.Application.Controllers;
using ApiParticipacaoLucros.Domain.Dtos;
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
    public class QuandoRequisitarObterPorMatricula
    {
        private FuncionarioController _controller;
        [Fact(DisplayName = "É possível requisitar funcionário por matrícula")]
        public async Task E_Possivel_Requisitar_Unico_Funcionario()
        {
            var serviceMock = new Mock<IFuncionarioService>();
            string nomeFake = Faker.Name.FullName();

            serviceMock.Setup(x => x.ObterPorMatricula(It.IsAny<string>())).ReturnsAsync(new FuncionarioDto 
            {
                nome = nomeFake,
                area = "Contabilidade",
                cargo = "Auxiliar Administrativo",
                data_de_admissao = DateTime.UtcNow.AddMonths(-new Random().Next(180)),
                matricula = new Random().Next(15000).ToString(),
                salario_bruto = Convert.ToDecimal(new Random().Next(1100, 20000)).ToString("C")
            });

            _controller = new FuncionarioController(serviceMock.Object);
            var result = await _controller.ObterPorMatricula(new Random().Next(15000).ToString());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as FuncionarioDto;
            Assert.True(resultValue.nome == nomeFake);
        }
    }
}
