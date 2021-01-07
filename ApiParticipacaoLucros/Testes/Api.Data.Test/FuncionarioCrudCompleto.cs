using ApiParticipacaoLucros.Data.Repositories.Funcionario;
using ApiParticipacaoLucros.Domain.Dtos;
using FireSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace Api.Data.Test
{
    public class FuncionarioCrudCompleto
    {
        [Fact(DisplayName = "CRUD de funcionário")]
        public async Task E_Possivel_Realizar_Crud_Funcionario()
        {
            FuncionarioRepository funcionarioRepository = new FuncionarioRepository();

            List<FuncionarioDto> entities = new List<FuncionarioDto>()
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

            };

            var registroCriado = await funcionarioRepository.InserirInformacoes(entities);
            Assert.True(registroCriado);

            FuncionarioDto entity = entities[0];
            entity.nome = Faker.Name.First();
            var registroAtualizado = await funcionarioRepository.AtualizarFuncionario(entity);
            Assert.NotNull(registroAtualizado);
            Assert.Equal(entity.nome, registroAtualizado.nome);
            Assert.Equal(entity.matricula, registroAtualizado.matricula);

            var registroSelecionado = await funcionarioRepository.ObterPorMatricula(entities[1].matricula);
            Assert.NotNull(registroSelecionado);
            Assert.Equal(entities[1].nome, registroSelecionado.nome);
            Assert.Equal(entities[1].area, registroSelecionado.area);

            var todos = await funcionarioRepository.ObterTodos();
            Assert.NotNull(todos);
            Assert.True(todos.Count > 0);

            var deletado = await funcionarioRepository.Deletar(registroSelecionado.matricula);
            Assert.True(deletado);

            var todosDeletados = await funcionarioRepository.Deletar();
            Assert.True(todosDeletados);
        }
    }
}
