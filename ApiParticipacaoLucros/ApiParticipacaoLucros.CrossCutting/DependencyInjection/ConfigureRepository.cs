using ApiParticipacaoLucros.Data.Repositories.Distribuicao;
using ApiParticipacaoLucros.Data.Repositories.Funcionario;
using ApiParticipacaoLucros.Domain.Repositories.Distribuicao;
using ApiParticipacaoLucros.Domain.Repositories.Funcionario;
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
            serviceCollection.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            serviceCollection.AddScoped<IDistribuicaoRepository, DistribuicaoRepository>();
        }
    }
}
