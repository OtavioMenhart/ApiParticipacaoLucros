using ApiParticipacaoLucros.Data.Context;
using ApiParticipacaoLucros.Domain.Dtos;
using ApiParticipacaoLucros.Domain.Repositories.Distribuicao;
using FireSharp;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiParticipacaoLucros.Data.Repositories.Distribuicao
{
    public class DistribuicaoRepository : IDistribuicaoRepository
    {
        private FirebaseContext fbCtx = new FirebaseContext();
        private FirebaseClient _client;

        public DistribuicaoRepository()
        {
            _client = fbCtx.InstanciarClientFirebase();
        }

        

        public async Task<bool> InserirInformacoes(List<FuncionarioDto> funcionarios)
        {
            try
            {
                foreach (FuncionarioDto funcionario in funcionarios)
                {
                    SetResponse response = await _client.SetTaskAsync("Funcionarios/" + funcionario.matricula, funcionario);
                    FuncionarioDto result = response.ResultAs<FuncionarioDto>();

                    if (result is null)
                        return false;
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
