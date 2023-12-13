using Microsoft.AspNetCore.Mvc;
using NovidadesDotNet8.Implementations.InjecaoDependencia;
using NovidadesDotNet8.Interfaces.InjecaoDependencia;
using System.Runtime.CompilerServices;

namespace NovidadesDotNet8.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class InjecaoDependenciaController : ControllerBase
    {
        private readonly ITesteInjecao _injecaoSingletonUm;
        private readonly ITesteInjecao _injecaoSingletonDois;
        private readonly ITesteInjecao _injecaoScopedUm;
        private readonly ITesteInjecao _injecaoScopedDois;
        private readonly ITesteInjecao _injecaoTransientUm;
        private readonly ITesteInjecao _injecaoTransientDois;

        /// <summary>
        /// Faz a injeção de dependências no construtor
        /// </summary>
        public InjecaoDependenciaController(
            [FromKeyedServices("InjecaoSingletonUm")] ITesteInjecao injecaoSingletonUm,
            [FromKeyedServices("InjecaoSingletonDois")] ITesteInjecao injecaoSingletonDois,
            [FromKeyedServices("InjecaoScopedUm")] ITesteInjecao injecaoScopedUm,
            [FromKeyedServices("InjecaoScopedDois")] ITesteInjecao injecaoScopedDois,
            [FromKeyedServices("InjecaoTransientUm")] ITesteInjecao injecaoTransientUm,
            [FromKeyedServices("InjecaoTransientDois")] ITesteInjecao injecaoTransientDois)
        {
            _injecaoSingletonUm = injecaoSingletonUm;
            _injecaoSingletonDois = injecaoSingletonDois;
            _injecaoScopedUm = injecaoScopedUm;
            _injecaoScopedDois = injecaoScopedDois;
            _injecaoTransientUm = injecaoTransientUm;
            _injecaoTransientDois = injecaoTransientDois;
        }

        /// <summary>
        /// Comparamos os IDs gerados na injeção de dependência para validarmos a aplicabilidade - Tipo Singleton
        /// Execute o endpoint mais de uma vez para entender a funcionalidade
        /// </summary>
        [HttpGet("singleton")]
        public IActionResult ValoresSingleton(
            [FromKeyedServices("InjecaoSingletonUm")] ITesteInjecao injecaoSingletonUmComparacao,
            [FromKeyedServices("InjecaoSingletonDois")] ITesteInjecao injecaoSingletonDoisComparacao)
        {
            var comparacao = new Comparacao
            {
                ComparacaoInstanciaUm = new ComparacaoInstancia
                {
                    KeyInjecao = "InjecaoSingletonUm",
                    InstanciaGeradaConstrutor = _injecaoSingletonUm.IdInstanciaValidacao,
                    InstanciaGeradaParametro = injecaoSingletonUmComparacao.IdInstanciaValidacao
                },
                ComparacaoInstanciaDois = new ComparacaoInstancia
                {
                    KeyInjecao = "InjecaoSingletonDois",
                    InstanciaGeradaConstrutor = _injecaoSingletonDois.IdInstanciaValidacao,
                    InstanciaGeradaParametro = injecaoSingletonDoisComparacao.IdInstanciaValidacao
                }
            };

            return Ok(comparacao);
        }

        /// <summary>
        /// Comparamos os IDs gerados na injeção de dependência para validarmos a aplicabilidade - Tipo Scoped
        /// Execute o endpoint mais de uma vez para entender a funcionalidade
        /// </summary>
        [HttpGet("scoped")]
        public IActionResult ValoresScoped(
            [FromKeyedServices("InjecaoScopedUm")] ITesteInjecao injecaoScopedUmComparacao,
            [FromKeyedServices("InjecaoScopedDois")] ITesteInjecao injecaoScopedDoisComparacao)
        {
            var comparacao = new Comparacao
            {
                ComparacaoInstanciaUm = new ComparacaoInstancia
                {
                    KeyInjecao = "InjecaoScopedUm",
                    InstanciaGeradaConstrutor = _injecaoScopedUm.IdInstanciaValidacao,
                    InstanciaGeradaParametro = injecaoScopedUmComparacao.IdInstanciaValidacao
                },
                ComparacaoInstanciaDois = new ComparacaoInstancia
                {
                    KeyInjecao = "InjecaoScopedDois",
                    InstanciaGeradaConstrutor = _injecaoScopedDois.IdInstanciaValidacao,
                    InstanciaGeradaParametro = injecaoScopedDoisComparacao.IdInstanciaValidacao
                }
            };

            return Ok(comparacao);
        }

        /// <summary>
        /// Comparamos os IDs gerados na injeção de dependência para validarmos a aplicabilidade - Tipo Transient
        /// Execute o endpoint mais de uma vez para entender a funcionalidade
        /// </summary>
        [HttpGet("transient")]
        public IActionResult ValoresTransient(
            [FromKeyedServices("InjecaoTransientUm")] ITesteInjecao injecaoTransientUmComparacao,
            [FromKeyedServices("InjecaoTransientDois")] ITesteInjecao injecaoTransientDoisComparacao)
        {
            var comparacao = new Comparacao
            {
                ComparacaoInstanciaUm = new ComparacaoInstancia
                {
                    KeyInjecao = "InjecaoTransientUm",
                    InstanciaGeradaConstrutor = _injecaoTransientUm.IdInstanciaValidacao,
                    InstanciaGeradaParametro = injecaoTransientUmComparacao.IdInstanciaValidacao
                },
                ComparacaoInstanciaDois = new ComparacaoInstancia
                {
                    KeyInjecao = "InjecaoTransientDois",
                    InstanciaGeradaConstrutor = _injecaoTransientDois.IdInstanciaValidacao,
                    InstanciaGeradaParametro = injecaoTransientDoisComparacao.IdInstanciaValidacao
                }
            };

            return Ok(comparacao);
        }
    }
}
