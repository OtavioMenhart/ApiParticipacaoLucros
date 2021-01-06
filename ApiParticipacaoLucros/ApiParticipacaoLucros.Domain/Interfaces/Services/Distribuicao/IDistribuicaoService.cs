using ApiParticipacaoLucros.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiParticipacaoLucros.Domain.Interfaces.Services.Distribuicao
{
    public interface IDistribuicaoService
    {
        Task<bool> InserirInformacoes(List<FuncionarioDto> funcionarios);
    }
}
