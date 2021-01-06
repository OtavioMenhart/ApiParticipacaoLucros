using ApiParticipacaoLucros.Domain.Interfaces.Services.SalarioMinimo;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace ApiParticipacaoLucros.Service.Services.SalarioMinimo
{
    public class SalarioMinimoService : ISalarioMinimoService
    {
        public decimal ObterSalarioMinimoAtual()
        {
            try
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
                return salarioMinimo;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
