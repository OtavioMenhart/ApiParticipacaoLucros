using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiParticipacaoLucros.Domain.Interfaces.Services.Distribuicao
{
    public interface IDistribuicaoService
    {
        Task<decimal> ObterDistribuicaoLucros(decimal valor);
    }
}
