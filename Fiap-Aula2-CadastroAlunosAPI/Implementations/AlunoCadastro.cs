using Fiap_Aula2_CadastroAlunosAPI.Interfaces;
using Fiap_Aula2_CadastroAlunosAPI.Models;

namespace Fiap_Aula2_CadastroAlunosAPI.Implementations
{
    public class AlunoCadastro : IAlunoCadastro
    {
        public IList<Aluno> listaAluno { get; set; }

        public AlunoCadastro()
        {
            this.listaAluno = new List<Aluno>();
        }

        public void AtualizarAluno(Aluno dadosAluno)
        {
            throw new NotImplementedException();
        }

        public Aluno CriarAluno(Aluno dadosAluno)
        {
            dadosAluno.Id = listaAluno.Select(x => x.Id).Any() ? listaAluno.Select(x => x.Id).Max() + 1 : 1;
            listaAluno.Add(dadosAluno);
            
            return dadosAluno;
        }

        public void DeletarAluno(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Aluno> ListarAlunos()
        {
            return listaAluno;
        }
    }
}
