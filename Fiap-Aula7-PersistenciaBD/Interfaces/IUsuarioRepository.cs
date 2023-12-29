using Fiap_Aula7_PersistenciaBD.Models;

namespace Fiap_Aula7_PersistenciaBD.Interfaces
{
    public interface IUsuarioRepository
    {
        IList<Usuario> RetornaUsuario();

        Usuario? RetornaUsuarioPorId(int id);

        void DeletarUsuario(int id);

        Usuario CadastrarUsuario(Usuario usuario);
    }
}
