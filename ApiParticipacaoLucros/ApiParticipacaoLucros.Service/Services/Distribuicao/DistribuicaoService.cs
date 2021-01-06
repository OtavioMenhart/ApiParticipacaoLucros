using ApiParticipacaoLucros.Domain.Interfaces.Services.Distribuicao;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiParticipacaoLucros.Service.Services.Distribuicao
{
    public class DistribuicaoService : IDistribuicaoService
    {
        public Task<decimal> ObterDistribuicaoLucros(decimal valor)
        {
            throw new NotImplementedException();
        }
    }
}
