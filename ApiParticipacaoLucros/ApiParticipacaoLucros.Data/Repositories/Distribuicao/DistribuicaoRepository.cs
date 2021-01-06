using ApiParticipacaoLucros.Domain.Dtos;
using ApiParticipacaoLucros.Domain.Repositories.Distribuicao;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiParticipacaoLucros.Data.Repositories.Distribuicao
{
    public class DistribuicaoRepository : BaseRepository<ParticipacoesDto>, IDistribuicaoRepository
    {
        public async Task<bool> GravarLogGravacao(ParticipacoesDto calculoPLR)
        {
            try
            {
                ParticipacoesDto result = await InsertFirebaseAsync("CalculoPLR/" + Guid.NewGuid().ToString(), calculoPLR);
                if (result is null)
                    return false;
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
