using Fiap_Aula3_CadastroAlunosAPI.Models;

namespace Fiap_Aula3_CadastroAlunosAPI.Interfaces
{
    public interface IAlunoCadastro
    {
        public Aluno RetornarAluno(int id);
        public Aluno CriarAluno(Aluno dadosAluno);
    }
}
