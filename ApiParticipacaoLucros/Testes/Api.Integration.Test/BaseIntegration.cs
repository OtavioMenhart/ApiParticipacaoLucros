using ApiParticipacaoLucros.Application;
using ApiParticipacaoLucros.Data.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Api.Integration.Test
{
    public class BaseIntegration : IDisposable
    {
        public HttpClient client { get; private set; }
        public string hostApi { get; set; }
        public HttpResponseMessage response { get; set; }
        public FirebaseContext myContext { get; private set; }
        

        public BaseIntegration()
        {
            hostApi = "http://localhost:5000/api/";
            var builder = new WebHostBuilder().UseStartup<Startup>();
            var server = new TestServer(builder);
            client = server.CreateClient();
        }

        public static async Task<HttpResponseMessage> PostJsonAsync(object data, string url, HttpClient client)
        {
            return await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
