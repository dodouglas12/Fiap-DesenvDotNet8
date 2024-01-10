using Fiap_Aula3_CadastroAlunosAPI.Interfaces;
using Fiap_Aula3_CadastroAlunosAPI.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Fiap_Aula3_CadastroAlunosAPI.Implementations
{
    public class AlunoCadastro : IAlunoCadastro
    {
        private readonly IBancoDados _bancoDados;
        public AlunoCadastro(IBancoDados bancoDados)
        {
            _bancoDados = bancoDados;
        }

        public Aluno CriarAluno(Aluno dadosAluno)
        {
            throw new NotImplementedException();
        }

        public Aluno RetornarAluno(int id)
        {
            throw new NotImplementedException();
        }
    }
}
