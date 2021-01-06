using ApiParticipacaoLucros.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiParticipacaoLucros.Domain.Repositories.Distribuicao
{
    public interface IDistribuicaoRepository
    {
        Task<bool> GravarLogGravacao(ParticipacoesDto calculoPLR);
    }
}
