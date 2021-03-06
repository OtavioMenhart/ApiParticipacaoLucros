﻿using ApiParticipacaoLucros.Data.Context;
using ApiParticipacaoLucros.Domain.Dtos;
using ApiParticipacaoLucros.Domain.Repositories.Funcionario;
using FireSharp;
using FireSharp.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiParticipacaoLucros.Data.Repositories.Funcionario
{
    public class FuncionarioRepository : BaseRepository<FuncionarioDto>, IFuncionarioRepository
    {
        public async Task<FuncionarioDto> AtualizarFuncionario(FuncionarioDto funcionario)
        {
            try
            {
                return await UpdateFirebaseAsync("Funcionarios/" + funcionario.matricula, funcionario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Deletar(string matricula = "")
        {
            try
            {
                if (matricula != "")
                    return await DeleteFirebaseAsync("Funcionarios/" + matricula);
                else
                    return await DeleteFirebaseAsync("Funcionarios");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> InserirInformacoes(List<FuncionarioDto> funcionarios)
        {
            try
            {
                foreach (FuncionarioDto funcionario in funcionarios)
                {
                    FuncionarioDto verificacao = await ObterPorMatricula(funcionario.matricula);
                    if (verificacao != null)
                        continue;

                    funcionario.matricula = funcionario.matricula.PadLeft(7, '0');
                    FuncionarioDto result = await InsertFirebaseAsync("Funcionarios/" + funcionario.matricula, funcionario);
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

        public async Task<FuncionarioDto> ObterPorMatricula(string matricula)
        {
            try
            {
                return await GetFirebaseAsync("Funcionarios/" + matricula);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Dictionary<string, FuncionarioDto>> ObterTodos()
        {
            try
            {
                Dictionary<string, FuncionarioDto> resultado = await GetAllFirebaseAsync("Funcionarios/");
                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
