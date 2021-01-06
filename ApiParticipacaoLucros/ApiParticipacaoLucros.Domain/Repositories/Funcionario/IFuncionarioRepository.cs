using ApiParticipacaoLucros.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiParticipacaoLucros.Domain.Repositories.Funcionario
{
    public interface IFuncionarioRepository
    {
        Task<bool> InserirInformacoes(List<FuncionarioDto> funcionarios);
        Task<FuncionarioDto> ObterPorMatricula(string matricula);
        Task<FuncionarioDto> AtualizarFuncionario(FuncionarioDto funcionario);
        Task<bool> Deletar(string matricula = "");
        Task<Dictionary<string, FuncionarioDto>> ObterTodos();
    }
}
