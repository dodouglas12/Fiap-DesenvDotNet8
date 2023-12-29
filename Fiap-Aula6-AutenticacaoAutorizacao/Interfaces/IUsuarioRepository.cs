using Fiap_Aula6_AutenticacaoAutorizacao.Models;

namespace Fiap_Aula6_AutenticacaoAutorizacao.Interfaces
{
    public interface IUsuarioRepository
    {
        IList<Usuario> RetornaUsuario();

        Usuario? RetornaUsuarioPorId(int id);

        void DeletarUsuario(int id);

        Usuario CadastrarUsuario(Usuario usuario);
    }
}
