using ApiParticipacaoLucros.Domain.Interfaces.Services.Distribuicao;
using ApiParticipacaoLucros.Domain.Interfaces.Services.Funcionario;
using ApiParticipacaoLucros.Service.Services.Distribuicao;
using ApiParticipacaoLucros.Service.Services.Funcionario;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiParticipacaoLucros.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IFuncionarioService, FuncionarioService>();
            serviceCollection.AddTransient<IDistribuicaoService, DistribuicaoService>();
        }
    }
}
