using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using Fiap_Aula8_DocumentandoAPI.Enums;
using Fiap_Aula8_DocumentandoAPI.Interfaces;
using Fiap_Aula8_DocumentandoAPI.Models;

namespace Fiap_Aula8_DocumentandoAPI.Controllers
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
        /// <param name="id">Id do Usuário cadastrado na basede dados</param>
        /// <returns>Não é retornado nenhum valor. Somente a confirmação da exclusão</returns>
        /// <response code="204">Solicitação executada com sucesso</response>
        /// <response code="400">Falha ao processar requisição</response>
        /// <response code="500">Falha ao processar requisição</response>
        [HttpDelete("DeleteUsuarioPorId")]
        [Authorize(Roles = PemissaoSistema.Administrador)]
        public IActionResult DeleteUsuarioPorId(int id)
        {
            _usuarioRepository.DeletarUsuario(id);
            return NoContent();
        }

        /// <summary>
        /// Cadastra um novo usuário na base de dados
        /// </summary>
        /// <remarks> 
        /// Exemplo de requisição:
        /// Obs.: Não é necessário enviar o Id nessa requisição
        ///     {
        ///         "Username": "Nome do Usuário",
        /// 	    "Password": "Senha do Usuário",
        /// 	    "PermissaoSistema": "Tipo de Permissão"
        ///     }
        /// </remarks>
        /// <param name="usuario">Objeto Usuario</param>
        /// <returns>Retorna o usuário cadastrado</returns>
        /// <response code="201">Usuário cadastrado na base de dados</response>
        /// <response code="400">Falha ao processar a requisição</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpPost("CadastraUsuario")]
        [AllowAnonymous]
        public IActionResult CadastraUsuario(Usuario usuario)
        {
            var usuarioCadastrado = _usuarioRepository.CadastrarUsuario(usuario);
            return Created("", usuarioCadastrado);
        }
    }
}
