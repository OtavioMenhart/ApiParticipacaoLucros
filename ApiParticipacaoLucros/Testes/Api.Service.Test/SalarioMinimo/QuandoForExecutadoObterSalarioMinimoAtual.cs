using ApiParticipacaoLucros.Domain.Interfaces.Services.SalarioMinimo;
using HtmlAgilityPack;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.SalarioMinimo
{
    public class QuandoForExecutadoObterSalarioMinimoAtual
    {
        [Fact(DisplayName = "É possível obter salário mínimo")]
        public async Task E_Possivel_Obter_Salario_Minimo()
        {
            WebClient client = new WebClient();
            string html = client.DownloadString("http://www.guiatrabalhista.com.br/guia/salario_minimo.htm");
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var tabelaCorreta = htmlDoc.DocumentNode.SelectNodes("//table")[0];
            HtmlNode tr = tabelaCorreta.SelectNodes("//tr")[1];
            HtmlNode td = tr.SelectNodes("//td")[6];

            string valorAtual = td.InnerText;
            decimal salarioMinimo = decimal.Parse(valorAtual, System.Globalization.NumberStyles.Currency);
            Assert.Equal(1100, salarioMinimo);
        } 
    }
}
