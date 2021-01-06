using ApiParticipacaoLucros.Data.Repositories.Distribuicao;
using ApiParticipacaoLucros.Domain.Repositories.Distribuicao;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiParticipacaoLucros.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IDistribuicaoRepository, DistribuicaoRepository>();
        }
    }
}
