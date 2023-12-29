using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using Fiap_Aula6_AutenticacaoAutorizacao.Enums;
using Fiap_Aula6_AutenticacaoAutorizacao.Interfaces;
using Fiap_Aula6_AutenticacaoAutorizacao.Models;

namespace Fiap_Aula6_AutenticacaoAutorizacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Necessita de autenticação via token independente da Role
        /// </summary>
        /// <returns></returns>
        [HttpGet("RetornaTodosUsuarios")]
        [Authorize]
        public IActionResult RetornaTodosUsuarios()
        {
            return Ok(_usuarioRepository.RetornaUsuario());
        }

        /// <summary>
        /// Somente usuário do tipo atendimento acessam
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("RetornaUsuarioPorId")]
        [Authorize(Roles = PemissaoSistema.Atendimento)]
        public IActionResult RetornaUsuarioPorId(int id)
        {
            return Ok(_usuarioRepository.RetornaUsuarioPorId(id));
        }

        /// <summary>
        /// Somente usuário do tipo Adm acessam
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteUsuarioPorId")]
        [Authorize(Roles = PemissaoSistema.Administrador)]
        public IActionResult DeleteUsuarioPorId(int id)
        {
            _usuarioRepository.DeletarUsuario(id);
            return NoContent();
        }

        /// <summary>
        /// Qualquer usuário pode executar esse endpoint
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost("CadastraUsuario")]
        [AllowAnonymous]
        public IActionResult CadastraUsuario(Usuario usuario)
        {
            var usuarioCadastrado = _usuarioRepository.CadastrarUsuario(usuario);
            return Created("", usuarioCadastrado);
        }
    }
}
