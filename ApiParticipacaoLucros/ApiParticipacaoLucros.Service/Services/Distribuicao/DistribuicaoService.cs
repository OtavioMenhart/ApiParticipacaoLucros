using ApiParticipacaoLucros.Domain.Dtos;
using ApiParticipacaoLucros.Domain.Interfaces.Services.Distribuicao;
using ApiParticipacaoLucros.Domain.Interfaces.Services.Funcionario;
using ApiParticipacaoLucros.Domain.Repositories.Distribuicao;
using ApiParticipacaoLucros.Domain.Repositories.Funcionario;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ApiParticipacaoLucros.Service.Services.Distribuicao
{
    public class DistribuicaoService : IDistribuicaoService
    {
        private IFuncionarioService _funcionarioService;
        private IDistribuicaoRepository _distribuicaoRepository;

        public DistribuicaoService(IFuncionarioService funcionarioService, IDistribuicaoRepository distribuicaoRepository)
        {
            _funcionarioService = funcionarioService;
            _distribuicaoRepository = distribuicaoRepository;
        }

        public async Task<ParticipacoesDto> ObterDistribuicaoLucros(decimal valor)
        {
            try
            {
                List<FuncionarioDto> funcionarios = await _funcionarioService.ObterTodos();
                if (funcionarios is null)
                    return null;

                List<FuncionarioPLRDto> funcionarioPLR = new List<FuncionarioPLRDto>();
                decimal totalDistribuido = 0;

                foreach (FuncionarioDto funcionario in funcionarios)
                {
                    decimal sb = decimal.Parse(funcionario.salario_bruto, System.Globalization.NumberStyles.Currency);

                    int paa = RetornarPesoArea(funcionario.area);
                    int pfs = RetornarPesoFaixaSalarial(sb);
                    int pta = RetornarPesoTempoAdmissao(funcionario.data_de_admissao);

                    decimal valorPlr = ((sb * pta) + (sb * paa) / pfs) * 12;

                    funcionarioPLR.Add(new FuncionarioPLRDto
                    {
                        matricula = funcionario.matricula,
                        nome = funcionario.nome,
                        valor_da_participação = valorPlr.ToString("C")
                    });

                    totalDistribuido += valorPlr;
                }

                ParticipacoesDto participacoes = new ParticipacoesDto
                {
                    participacoes = funcionarioPLR,
                    data_calculo = DateTime.UtcNow,
                    total_de_funcionarios = funcionarioPLR.Count,
                    total_disponibilizado = valor.ToString("C"),
                    total_distribuido = totalDistribuido.ToString("C"),
                    saldo_total_disponibilizado = Math.Round(valor - totalDistribuido, 2).ToString("C")
                };

                return participacoes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int RetornarPesoArea(string area)
        {
            int peso = 0;
            switch (area)
            {
                case "Diretoria":
                    peso = 1;
                    break;
                case "Contabilidade":
                    peso = 2;
                    break;
                case "Financeiro":
                    peso = 2;
                    break;
                case "Tecnologia":
                    peso = 2;
                    break;
                case "Serviços Gerais":
                    peso = 3;
                    break;
                case "Relacionamento com o Cliente":
                    peso = 5;
                    break;
            }
            return peso;
        }

        public int RetornarPesoFaixaSalarial(decimal salarioBruto)
        {
            int peso = 0;
            decimal salarioMinimo = 1100;

            if (salarioBruto <= salarioMinimo * 3)
                return 1;

            int calculoFaixa = Convert.ToInt32(Math.Ceiling(salarioBruto / salarioMinimo));

            switch (calculoFaixa)
            {
                case int i when i >= 8:
                    peso = 5;
                    break;
                case int i when i >= 5 && i < 8:
                    peso = 3;
                    break;
                case int i when i >= 3 && i < 5:
                    peso = 2;
                    break;
            }
            return peso;
        }

        public int RetornarPesoTempoAdmissao(DateTime dataAdmissao)
        {
            int peso = 0;
            int tempo = DateTime.UtcNow.Year - dataAdmissao.Year;
            if (DateTime.UtcNow.DayOfYear < dataAdmissao.DayOfYear)
                tempo = tempo - 1;

            switch (tempo)
            {
                case 0:
                    peso = 1;
                    break;
                case int i when i >= 1 && i < 3:
                    peso = 2;
                    break;
                case int i when i >= 3 && i < 8:
                    peso = 3;
                    break;
                case int i when i >= 8:
                    peso = 5;
                    break;
            }
            return peso;
        }
    }
}
