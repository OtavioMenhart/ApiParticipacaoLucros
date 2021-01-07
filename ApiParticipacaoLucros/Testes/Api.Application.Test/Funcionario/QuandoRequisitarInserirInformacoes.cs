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
    public class QuandoRequisitarInserirInformacoes
    {
        private FuncionarioController _controller;

        [Fact(DisplayName = "É possível requisitar API para inserir funcionário")]
        public async Task E_Possivel_Inserir_Funcionarios()
        {
            var serviceMock = new Mock<IFuncionarioService>();

            List<FuncionarioDto> listaFuncionarios = new List<FuncionarioDto>()
            {
                new FuncionarioDto
                {
                    nome = Faker.Name.FullName(),
                    area = "Contabilidade",
                    cargo = "Auxiliar Administrativo",
                    data_de_admissao = DateTime.UtcNow.AddMonths(-new Random().Next(180)),
                    matricula = new Random().Next(9999999).ToString().PadLeft(7, '0'),
                    salario_bruto = Convert.ToDecimal(new Random().Next(1100, 20000)).ToString("C")
                },
                new FuncionarioDto
                {
                    nome = Faker.Name.FullName(),
                    area = "Financeiro",
                    cargo = "Analista de Finanças",
                    data_de_admissao = DateTime.UtcNow.AddMonths(-new Random().Next(180)),
                    matricula = new Random().Next(9999999).ToString().PadLeft(7, '0'),
                    salario_bruto = Convert.ToDecimal(new Random().Next(1100, 20000)).ToString("C")
                },
                new FuncionarioDto
                {
                    nome = Faker.Name.FullName(),
                    area = "Relacionamento com o Cliente",
                    cargo = "Líder de Relacionamento",
                    data_de_admissao = DateTime.UtcNow.AddMonths(-new Random().Next(180)),
                    matricula = new Random().Next(9999999).ToString().PadLeft(7, '0'),
                    salario_bruto = Convert.ToDecimal(new Random().Next(1100, 20000)).ToString("C")
                },
            };

            serviceMock.Setup(x => x.InserirInformacoes(listaFuncionarios)).ReturnsAsync(true);

            _controller = new FuncionarioController(serviceMock.Object);
            var result = await _controller.InserirInformacoes(listaFuncionarios);
            Assert.True(result is ObjectResult);

            var resultValue = ((ObjectResult)result).Value as string;
            Assert.True(resultValue == "Sucesso");
        }
    }
}
