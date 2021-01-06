using ApiParticipacaoLucros.Domain.Dtos;
using ApiParticipacaoLucros.Domain.Interfaces.Services.Distribuicao;
using ApiParticipacaoLucros.Domain.Repositories.Distribuicao;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiParticipacaoLucros.Service.Services.Distribuicao
{
    public class DistribuicaoService : IDistribuicaoService
    {
        private IDistribuicaoRepository _distribuicaoRepository;

        public DistribuicaoService(IDistribuicaoRepository distribuicaoRepository)
        {
            _distribuicaoRepository = distribuicaoRepository;
        }

        public async Task<bool> InserirInformacoes(List<FuncionarioDto> funcionarios)
        {
            try
            {
                if (funcionarios.Count == 0)
                    return true;
                bool resultadoInsert = await _distribuicaoRepository.InserirInformacoes(funcionarios);

                return resultadoInsert;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
