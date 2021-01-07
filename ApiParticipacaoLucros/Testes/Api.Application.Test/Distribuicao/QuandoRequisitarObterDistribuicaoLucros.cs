using ApiParticipacaoLucros.Application.Controllers;
using ApiParticipacaoLucros.Domain.Dtos;
using ApiParticipacaoLucros.Domain.Interfaces.Services.Distribuicao;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Test.Distribuicao
{
    public class QuandoRequisitarObterDistribuicaoLucros
    {
        private DistribuicaoController _controller;

        [Fact(DisplayName = "É possível requisitar funcionarios")]
        public async Task E_Possivel_Requisitar_Funcionarios()
        {
            var serviceMock = new Mock<IDistribuicaoService>();

            serviceMock.Setup(x => x.ObterDistribuicaoLucros(2000000)).ReturnsAsync(new ParticipacoesDto
            {
                participacoes = new List<FuncionarioPLRDto>
             {
                 new FuncionarioPLRDto
                 {
                     matricula = new Random().Next(15000).ToString(),
                     nome = Faker.Name.FullName(),
                     valor_da_participação = Convert.ToDecimal(new Random().Next(80000, 100000)).ToString("C")
                 }
             },
                saldo_total_disponibilizado = Convert.ToDecimal(new Random().Next(80000, 100000)).ToString("C"),
                total_de_funcionarios = "1",
                total_disponibilizado = Convert.ToDecimal(new Random().Next(80000, 100000)).ToString("C"),
                total_distribuido = Convert.ToDecimal(new Random().Next(80000, 100000)).ToString("C")
            });

            _controller = new DistribuicaoController(serviceMock.Object);
            var result = await _controller.ObterDistribuicaoLucros(2000000);
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as ParticipacoesDto;
            Assert.NotNull(resultValue);
        }
    }
}
