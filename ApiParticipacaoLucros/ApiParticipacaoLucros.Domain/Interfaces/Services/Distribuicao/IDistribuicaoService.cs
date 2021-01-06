using ApiParticipacaoLucros.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiParticipacaoLucros.Domain.Interfaces.Services.Distribuicao
{
    public interface IDistribuicaoService
    {
        Task<ParticipacoesDto> ObterDistribuicaoLucros(decimal valor);
        int RetornarPesoArea(string area);
        int RetornarPesoFaixaSalarial(decimal salarioBruto, decimal salarioMinimo);
        int RetornarPesoTempoAdmissao(DateTime dataAdmissao);
    }
}
