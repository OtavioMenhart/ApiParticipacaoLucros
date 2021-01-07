using ApiParticipacaoLucros.Domain.Dtos;
using ApiParticipacaoLucros.Domain.Interfaces.Services.Funcionario;
using ApiParticipacaoLucros.Domain.Repositories.Funcionario;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiParticipacaoLucros.Service.Services.Funcionario
{
    public class FuncionarioService : IFuncionarioService
    {
        private IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(IFuncionarioRepository distribuicaoRepository)
        {
            _funcionarioRepository = distribuicaoRepository;
        }

        public async Task<FuncionarioDto> AtualizarFuncionario(FuncionarioDto funcionario)
        {
            try
            {
                if (await _funcionarioRepository.ObterPorMatricula(funcionario.matricula) == null)
                    return null;

                funcionario.matricula = funcionario.matricula.PadLeft(7, '0');
                FuncionarioDto funcionarioAtualizado = await _funcionarioRepository.AtualizarFuncionario(funcionario);
                return funcionarioAtualizado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Deletar(string matricula = "")
        {
            try
            {
                if(matricula != "")
                {
                    string matriculaAjustada = matricula.PadLeft(7, '0');
                    if (await _funcionarioRepository.ObterPorMatricula(matriculaAjustada) == null)
                        return false;
                    return await _funcionarioRepository.Deletar(matriculaAjustada);
                }
                return await _funcionarioRepository.Deletar();
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> InserirInformacoes(List<FuncionarioDto> funcionarios)
        {
            try
            {
                if (funcionarios.Count == 0)
                    return true;
                bool resultadoInsert = await _funcionarioRepository.InserirInformacoes(funcionarios);
                return resultadoInsert;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<FuncionarioDto> ObterPorMatricula(string matricula)
        {
            try
            {
                FuncionarioDto funcionario = await _funcionarioRepository.ObterPorMatricula(matricula.PadLeft(7, '0'));
                return funcionario;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<FuncionarioDto>> ObterTodos()
        {
            try
            {
                Dictionary<string, FuncionarioDto> funcionarios = await _funcionarioRepository.ObterTodos();
                List<FuncionarioDto> funcionariosCadastrados = new List<FuncionarioDto>();
                if (funcionarios is null)
                    return null;
                foreach (var funcionario in funcionarios)
                {
                    funcionariosCadastrados.Add(new FuncionarioDto
                    {
                        matricula = funcionario.Value.matricula,
                        nome = funcionario.Value.nome,
                        area = funcionario.Value.area,
                        cargo = funcionario.Value.cargo,
                        salario_bruto = funcionario.Value.salario_bruto,
                        data_de_admissao = funcionario.Value.data_de_admissao
                    });
                }

                return funcionariosCadastrados;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
