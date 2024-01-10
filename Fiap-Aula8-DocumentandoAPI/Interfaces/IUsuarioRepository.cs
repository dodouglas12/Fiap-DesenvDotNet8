using Fiap_Aula8_DocumentandoAPI.Models;

namespace Fiap_Aula8_DocumentandoAPI.Interfaces
{
    public interface IUsuarioRepository
    {
        IList<Usuario> RetornaUsuario();

        Usuario? RetornaUsuarioPorId(int id);

        void DeletarUsuario(int id);

        Usuario CadastrarUsuario(Usuario usuario);
    }
}
