using ApiParticipacaoLucros.Domain.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Test.PLR
{
    public class QuandoRequisitarDistribuicao : BaseIntegration
    {
        [Fact(DisplayName = "É possível requisitar o cálculo de PLR"), ]
        public async Task E_Possivel_Requisitar_Calculo_PLR()
        {
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

            //Post
            var response = await PostJsonAsync(listaFuncionarios, $"{hostApi}Funcionario/InserirInformacoes", client);
            var postResult = await response.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            //Get simulacao
            var responseSimulacao = await client.GetAsync($"{hostApi}Distribuicao/ObterDistribuicaoLucros/2000000");
            Assert.Equal(HttpStatusCode.OK, responseSimulacao.StatusCode);
            var jsonResult = await responseSimulacao.Content.ReadAsStringAsync();
            var retornoFormatado = JsonConvert.DeserializeObject<ParticipacoesDto>(jsonResult);
            Assert.NotNull(retornoFormatado);

        }
    }
}
