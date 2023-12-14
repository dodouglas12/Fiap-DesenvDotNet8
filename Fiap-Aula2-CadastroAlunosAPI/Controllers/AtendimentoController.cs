using Fiap_Aula2_CadastroAlunosAPI.Interfaces;
using Fiap_Aula2_CadastroAlunosAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap_Aula2_CadastroAlunosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AtendimentoController : ControllerBase
    {
        private readonly IAlunoCadastro _alunoCadastro;

        public AtendimentoController(IAlunoCadastro alunoCadastro)
        {
            _alunoCadastro = alunoCadastro;
        }

        /// <summary>
        /// Endpoint para retornar os alunos cadastrados - Inicialmente uma Lista em memória
        /// </summary>
        [HttpGet("aluno")]
        public IActionResult GetAluno() {
            return Ok(_alunoCadastro.ListarAlunos());
        }

        /// <summary>
        /// Endpoint para cadastrar um aluno - Ínicialmente em Memória
        /// </summary>
        [HttpPost("inserirAluno")]
        public IActionResult PostInserirAluno([FromBody] Aluno aluno)
        {
            _alunoCadastro.CriarAluno(aluno);
            return Ok(aluno);
        }

        /// <summary>
        /// Endpoint para atualizar um aluno - Ínicialmente em Memória
        /// </summary>
        [HttpPut("atualizacaoAluno")]
        public IActionResult PutAtualizacaoAluno([FromBody] Aluno aluno)
        {
            return NoContent();
        }

        /// <summary>
        /// Endpoint para deletar um aluno - Ínicialmente em Memória
        /// </summary>
        [HttpDelete("deleteAluno")]
        public IActionResult DeleteAluno(string idAluno)
        {
            return NoContent();
        }
    }
}
