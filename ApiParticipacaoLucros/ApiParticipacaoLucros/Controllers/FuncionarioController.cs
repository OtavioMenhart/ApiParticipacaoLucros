using ApiParticipacaoLucros.Domain.Dtos;
using ApiParticipacaoLucros.Domain.Interfaces.Services.Funcionario;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiParticipacaoLucros.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private IFuncionarioService _funcionarioService;

        public FuncionarioController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpPost]
        public async Task<ActionResult> InserirInformacoes([FromBody] List<FuncionarioDto> listaFuncionarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                bool resultadoInsercao = await _funcionarioService.InserirInformacoes(listaFuncionarios);

                if (resultadoInsercao)
                    return StatusCode((int)HttpStatusCode.Created, "Sucesso");
                else
                    return BadRequest("Erro ao inserir informações");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> ObterPorMatricula(string matricula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                FuncionarioDto funcionario = await _funcionarioService.ObterPorMatricula(matricula);
                if (funcionario is null)
                    return BadRequest("Matrícula não encontrada");
                else
                    return Ok(funcionario);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarFuncionario([FromBody] FuncionarioDto funcionario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                FuncionarioDto funcionarioAtualizado = await _funcionarioService.AtualizarFuncionario(funcionario);
                if (funcionarioAtualizado is null)
                    return BadRequest("Matrícula não encontrada");
                else
                    return Ok(funcionario);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    
        [HttpDelete]
        public async Task<ActionResult> DeletarFuncionarioPorMatricula(string matricula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                bool resultadoExclusao = await _funcionarioService.Deletar(matricula);
                if (resultadoExclusao)
                    return Ok("Usuário deletado");
                else
                    return BadRequest("Matrícula não encontrada");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeletarTodos()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                bool resultadoExclusao = await _funcionarioService.Deletar();
                if (resultadoExclusao)
                    return Ok("Usuários deletados");
                else
                    return BadRequest("Matrícula não encontrada");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> ObterTodos()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                List<FuncionarioDto> funcionarios = await _funcionarioService.ObterTodos();
                if (funcionarios != null)
                    return Ok(funcionarios);
                else
                    return BadRequest("Sem usuários cadastrados");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
