using ApiParticipacaoLucros.Domain.Dtos;
using ApiParticipacaoLucros.Domain.Interfaces.Services.Distribuicao;
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
    public class DistribuicaoController : ControllerBase
    {
        private IDistribuicaoService _distribuicaoService;

        public DistribuicaoController(IDistribuicaoService distribuicaoService)
        {
            _distribuicaoService = distribuicaoService;
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
                await _distribuicaoService.InserirInformacoes(listaFuncionarios);
                return StatusCode((int)HttpStatusCode.Created, "Sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
