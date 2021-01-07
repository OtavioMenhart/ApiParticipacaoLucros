using ApiParticipacaoLucros.Domain.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Test.Distribuicao
{
    public class QuandoRequisitarDistribuicao : BaseIntegration
    {
        [Fact(DisplayName = "É possível requisitar o cálculo de PLR")]
        public async Task E_Possivel_Requisitar_Calculo_PLR()
        {
            //Get simulacao
            var response = await client.GetAsync($"{hostApi}Distribuicao/ObterDistribuicaoLucros/2000000");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var retornoFormatado = JsonConvert.DeserializeObject<ParticipacoesDto>(jsonResult);
            Assert.NotNull(retornoFormatado);

        }
    }
}
