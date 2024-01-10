using Fiap_Aula4_TrabalhandoLogs.Models;

namespace Fiap_Aula4_TrabalhandoLogs.Interfaces
{
    public interface IAlunoCadastro
    {
        public Aluno RetornarAluno(int id);
        public Aluno CriarAluno(Aluno dadosAluno);
    }
}
