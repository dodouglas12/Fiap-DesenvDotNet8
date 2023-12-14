using Fiap_Aula2_CadastroAlunosAPI.Models;

namespace Fiap_Aula2_CadastroAlunosAPI.Interfaces
{
    public interface IAlunoCadastro
    {
        /// <summary>
        /// Propriedade para leitura
        /// </summary>
        IList<Aluno> listaAluno { get; set; }

        //Contratos que serão utilizados na nossa implementação
        public IEnumerable<Aluno> ListarAlunos();
        public Aluno CriarAluno(Aluno dadosAluno);
        public void AtualizarAluno(Aluno dadosAluno);
        public void DeletarAluno(int Id);
    }
}
