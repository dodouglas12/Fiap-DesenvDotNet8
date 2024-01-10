using Fiap_Aula3_CadastroAlunosAPI.Interfaces;
using Fiap_Aula3_CadastroAlunosAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap_Aula3_CadastroAlunosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AtendimentoController : ControllerBase
    {
        //Forma 1 de Injeção
        private readonly IAlunoCadastro _alunoCadastro;
        public AtendimentoController(IAlunoCadastro alunoCadastro)
        {
            _alunoCadastro = alunoCadastro;
        }

        //Forma 3 de injeção
        [HttpGet("aluno")]
        public IActionResult GetAluno(IServiceProvider serviceProvider, int id) {
            var alunoCadastro = serviceProvider.GetRequiredService<IAlunoCadastro>();
            return Ok();
        }

        //Forma 2 de injeção
        [HttpPost("inserirAluno")]
        public IActionResult PostInserirAluno([FromKeyedServices("Forma2")] IAlunoCadastro alunoCadastro, [FromBody] Aluno aluno)
        {
            alunoCadastro.CriarAluno(aluno);
            return Ok(aluno);
        }
    }
}
