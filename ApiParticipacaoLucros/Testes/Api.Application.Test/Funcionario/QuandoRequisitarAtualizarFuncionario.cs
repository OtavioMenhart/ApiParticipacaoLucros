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
    public class QuandoRequisitarAtualizarFuncionario
    {
        private FuncionarioController _controller;

        [Fact(DisplayName = "É possível requisitar API para atualizar funcionário")]
        public async Task E_Possivel_Atualizar_Funcionario()
        {
            var serviceMock = new Mock<IFuncionarioService>();

            string nome = Faker.Name.FullName();

            serviceMock.Setup(x => x.AtualizarFuncionario(It.IsAny<FuncionarioDto>())).ReturnsAsync(new FuncionarioDto
            {
                nome = nome,
                area = "Contabilidade",
                cargo = "Auxiliar Administrativo",
                data_de_admissao = DateTime.UtcNow.AddMonths(-new Random().Next(180)),
                matricula = new Random().Next(15000).ToString(),
                salario_bruto = Convert.ToDecimal(new Random().Next(1100, 20000)).ToString("C")
            });

            _controller = new FuncionarioController(serviceMock.Object);

            FuncionarioDto funcionarioUpdate = new FuncionarioDto
            {
                nome = nome,
                area = "Contabilidade",
                cargo = "Auxiliar Administrativo",
                data_de_admissao = DateTime.UtcNow.AddMonths(-new Random().Next(180)),
                matricula = new Random().Next(15000).ToString(),
                salario_bruto = Convert.ToDecimal(new Random().Next(1100, 20000)).ToString("C")
            };

            var result = await _controller.AtualizarFuncionario(funcionarioUpdate);
            Assert.True(result is OkObjectResult);

            FuncionarioDto resultValue = ((OkObjectResult)result).Value as FuncionarioDto;
            Assert.NotNull(resultValue);
            Assert.Equal(funcionarioUpdate.nome, resultValue.nome);

        }

    }
}
