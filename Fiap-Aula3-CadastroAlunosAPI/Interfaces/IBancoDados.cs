using Fiap_Aula3_CadastroAlunosAPI.Models;

namespace Fiap_Aula3_CadastroAlunosAPI.Interfaces
{
    public interface IBancoDados
    {
        int Inserir<T>();
        object Retornar(int id);
    }
}
