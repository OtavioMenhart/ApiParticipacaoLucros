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
    public class QuandoRequisitarObterTodos
    {
        private FuncionarioController _controller;

        [Fact(DisplayName = "É possível requisitar funcionarios")]
        public async Task E_Possivel_Requisitar_Funcionarios()
        {
            var serviceMock = new Mock<IFuncionarioService>();

            serviceMock.Setup(x => x.ObterTodos()).ReturnsAsync(new List<FuncionarioDto>
            {
                new FuncionarioDto
                {
                    nome = Faker.Name.FullName(),
                    area = "Contabilidade",
                    cargo = "Auxiliar Administrativo",
                    data_de_admissao = DateTime.UtcNow.AddMonths(-new Random().Next(180)),
                    matricula = new Random().Next(15000).ToString(),
                    salario_bruto = Convert.ToDecimal(new Random().Next(1100, 20000)).ToString("C")
                },
                new FuncionarioDto
                {
                    nome = Faker.Name.FullName(),
                    area = "Financeiro",
                    cargo = "Analista de Finanças",
                    data_de_admissao = DateTime.UtcNow.AddMonths(-new Random().Next(180)),
                    matricula = new Random().Next(15000).ToString(),
                    salario_bruto = Convert.ToDecimal(new Random().Next(1100, 20000)).ToString("C")
                }
            });

            _controller = new FuncionarioController(serviceMock.Object);
            var result = await _controller.ObterTodos();
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as List<FuncionarioDto>;
            Assert.True(resultValue.Count == 2);
        }
    }
}
