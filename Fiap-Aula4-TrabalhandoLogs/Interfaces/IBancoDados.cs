using Fiap_Aula4_TrabalhandoLogs.Models;

namespace Fiap_Aula4_TrabalhandoLogs.Interfaces
{
    public interface IBancoDados
    {
        int Inserir<T>();
        object Retornar(int id);
    }
}
