using ApiParticipacaoLucros.Domain.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Test.Funcionario
{
    public class QuandoRequisitarFuncionario : BaseIntegration
    {
        [Fact(DisplayName = "É possível requisitar todos os endpoints de Funcionario")]
        public async Task E_Possivel_Requisitar_Todos_Endpoints_Funcionario()
        {
            List<FuncionarioDto> listaFuncionarios = new List<FuncionarioDto>()
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
                },
                new FuncionarioDto
                {
                    nome = Faker.Name.FullName(),
                    area = "Relacionamento com o Cliente",
                    cargo = "Líder de Relacionamento",
                    data_de_admissao = DateTime.UtcNow.AddMonths(-new Random().Next(180)),
                    matricula = new Random().Next(15000).ToString(),
                    salario_bruto = Convert.ToDecimal(new Random().Next(1100, 20000)).ToString("C")
                },
            };

            //Post
            var response = await PostJsonAsync(listaFuncionarios, $"{hostApi}Funcionario/InserirInformacoes", client);
            var postResult = await response.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            //Get All
            response = await client.GetAsync($"{hostApi}Funcionario/ObterTodos");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var listaFromJson = JsonConvert.DeserializeObject<List<FuncionarioDto>>(jsonResult);
            Assert.NotNull(listaFromJson);
            Assert.True(listaFromJson.Count > 0);

            //Put
            FuncionarioDto funcionarioAtualizado = new FuncionarioDto()
            {
                area = listaFuncionarios[0].area,
                salario_bruto = listaFuncionarios[0].salario_bruto,
                matricula = listaFuncionarios[0].matricula,
                data_de_admissao = listaFuncionarios[0].data_de_admissao,
                cargo = listaFuncionarios[0].cargo,
                nome = Faker.Name.FullName(),
            };
            funcionarioAtualizado.nome = Faker.Name.FullName();
            var stringContent = new StringContent(JsonConvert.SerializeObject(funcionarioAtualizado),
                                    Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}Funcionario/AtualizarFuncionario", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroAtualizado = JsonConvert.DeserializeObject<FuncionarioDto>(jsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEqual(listaFuncionarios[0].nome, registroAtualizado.nome);

            //Get por matrícula
            response = await client.GetAsync($"{hostApi}Funcionario/ObterPorMatricula/{registroAtualizado.matricula}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionado = JsonConvert.DeserializeObject<FuncionarioDto>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal(registroSelecionado.nome, registroAtualizado.nome);
            Assert.Equal(registroSelecionado.salario_bruto, registroAtualizado.salario_bruto);

            //Delete por matrícula
            response = await client.DeleteAsync($"{hostApi}Funcionario/DeletarFuncionarioPorMatricula/{registroAtualizado.matricula}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //Deletar todos
            response = await client.DeleteAsync($"{hostApi}Funcionario/DeletarTodos");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }
    }
}
