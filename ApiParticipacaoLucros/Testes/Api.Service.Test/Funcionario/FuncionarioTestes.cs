using ApiParticipacaoLucros.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Service.Test.Funcionario
{
    public class FuncionarioTestes
    {
        public string matricula { get; set; }
        public string nome { get; set; }
        public string area { get; set; }
        public string cargo { get; set; }
        public string salario_bruto { get; set; }
        public DateTime data_de_admissao { get; set; }

        public string areaAlterado { get; set; }
        public string cargoAlterado { get; set; }


        public List<FuncionarioDto> listaFuncionarios = new List<FuncionarioDto>();
        public FuncionarioDto funcionarioAtualizar;
        public FuncionarioDto funcionarioAtualizado;
        public FuncionarioDto funcionarioObtido;

        public FuncionarioTestes()
        {

            listaFuncionarios = new List<FuncionarioDto>()
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

            areaAlterado = "Relacionamento com o Cliente";
            cargoAlterado = "Líder de Relacionamento";

            funcionarioAtualizar = new FuncionarioDto
            {
                nome = Faker.Name.FullName(),
                area = areaAlterado,
                cargo = cargoAlterado,
                data_de_admissao = DateTime.UtcNow.AddMonths(-new Random().Next(180)),
                matricula = listaFuncionarios[0].matricula,
                salario_bruto = Convert.ToDecimal(new Random().Next(1100, 20000)).ToString("C"),
            };

            funcionarioAtualizado = new FuncionarioDto
            {
                area = areaAlterado,
                cargo = cargoAlterado,
                matricula = listaFuncionarios[0].matricula
            };

            funcionarioObtido = listaFuncionarios[0];
        }
    }
}
