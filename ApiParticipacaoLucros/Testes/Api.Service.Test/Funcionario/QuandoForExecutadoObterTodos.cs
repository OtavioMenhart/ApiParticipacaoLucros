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
    public class QuandoForExecutadoObterTodos
    {
        private IFuncionarioService _service;
        private Mock<IFuncionarioService> _serviceMock;

        [Fact(DisplayName = "É possível obter todos os funcionários")]
        public async Task E_Possivel_Obter_Todos_Funcionarios()
        {
            _serviceMock = new Mock<IFuncionarioService>();
            _serviceMock.Setup(x => x.ObterTodos()).ReturnsAsync(new List<FuncionarioDto>()
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
                } 
            });
            _service = _serviceMock.Object;

            var result = await _service.ObterTodos();
            Assert.NotNull(result);
            Assert.True(result.Count == 2);

        }
    }
}
