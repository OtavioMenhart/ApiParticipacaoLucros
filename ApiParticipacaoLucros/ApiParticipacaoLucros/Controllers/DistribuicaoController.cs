using ApiParticipacaoLucros.Domain.Dtos;
using ApiParticipacaoLucros.Domain.Interfaces.Services.Distribuicao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

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

        [HttpGet]
        [Route("{valor}", Name = "ObterDistribuicaoLucros")]
        public async Task<ActionResult> ObterDistribuicaoLucros(decimal valor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                object participacoes = await _distribuicaoService.ObterDistribuicaoLucros(valor);
                if (participacoes is ParticipacoesDto)
                    return Ok(participacoes);                
                else
                    return BadRequest(participacoes);

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
