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

        [HttpGet]
        public async Task<ActionResult> ObterDistribuicaoLucros(decimal valor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
