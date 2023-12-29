using Fiap_Aula9_TrabalhandoCache.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap_Aula9_TrabalhandoCache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly ITesteCache _testeCache;
        public CacheController(ITesteCache testeCache)
        {
            _testeCache = testeCache;
        }

        [HttpGet]
        public IActionResult Get() 
        { 
            var resultado = _testeCache.RetornaValorCache();
            return Ok(resultado);
        }
    }
}
