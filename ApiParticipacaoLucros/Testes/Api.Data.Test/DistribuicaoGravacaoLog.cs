using ApiParticipacaoLucros.Data.Repositories.Distribuicao;
using ApiParticipacaoLucros.Domain.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace Api.Data.Test
{
    public class DistribuicaoGravacaoLog
    {
        [Fact(DisplayName = "Gravação de log do cálculo da PLR")]
        public async Task E_Possivel_Gravar_Log_PLR()
        {
            DistribuicaoRepository distribuicaoRepository = new DistribuicaoRepository();

            ParticipacoesDto entity = JsonConvert.DeserializeObject<ParticipacoesDto>("{  \"participacoes\": [    { \"matricula\": \"3943\",      \"nome\": \"Miss Charlotte Wintheiser\",      \"valor_da_participação\": \"R$ 156.716,00\"    },    {                \"matricula\": \"3976\",      \"nome\": \"Howard\",      \"valor_da_participação\": \"R$ 148.500,00\"    },    {                \"matricula\": \"5442\",      \"nome\": \"Gisselle Gorczany DDS\",      \"valor_da_participação\": \"R$ 121.500,00\"    },    {                \"matricula\": \"10840\",      \"nome\": \"Verlie\",      \"valor_da_participação\": \"R$ 334.740,00\"   }  ],  \"total_de_funcionarios\": \"4\",  \"total_distribuido\": \"R$ 761.456,00\",  \"total_disponibilizado\": \"R$ 50.000,00\",  \"saldo_total_disponibilizado\": \"-R$ 711.456,00\"}");
            bool resultado = await distribuicaoRepository.GravarLogGravacao(entity);
            Assert.True(resultado);
        }
    }
}
