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
                    if (await _funcionarioRepository.ObterPorMatricula(matricula) == null)
                        return false;
                    return await _funcionarioRepository.Deletar(matricula);
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
                FuncionarioDto funcionario = await _funcionarioRepository.ObterPorMatricula(matricula);
                return funcionario;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
