using Microsoft.AspNetCore.Mvc;
using Fiap_Aula8_DocumentandoAPI.Interfaces;
using Fiap_Aula8_DocumentandoAPI.Models;

namespace Fiap_Aula8_DocumentandoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        // Injeção da nossa interface para geração de Token
        private readonly ITokenService _tokenService;
        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario) 
        {
            var token = _tokenService.GetToken(usuario);

            if (!string.IsNullOrWhiteSpace(token))
            {
                return Ok(token);
            }

            return Unauthorized();
        }
    }
}
