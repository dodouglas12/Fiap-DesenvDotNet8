using Fiap_Aula6_AutenticacaoAutorizacao.Interfaces;
using Fiap_Aula6_AutenticacaoAutorizacao.Models;

namespace Fiap_Aula6_AutenticacaoAutorizacao.Repository
{
    // Códigos trabalhando com registro em memória - Utilizar somente para compreensão da utilização do JWT
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuario CadastrarUsuario(Usuario usuario)
        {
            var ultimoIdMemoria = 0;

            if (ListaUsuario.Usuarios.Any())
                ultimoIdMemoria = ListaUsuario.Usuarios.Select(x => x.Id).Max() + 1;

            usuario.Id = ultimoIdMemoria;
            ListaUsuario.Usuarios.Add(usuario);

            return usuario;
        }

        public void DeletarUsuario(int id)
        {
            var usuarioExclusao = RetornaUsuarioPorId(id);

            if (usuarioExclusao is null || usuarioExclusao.Id.Equals(0))
                return;

            ListaUsuario.Usuarios.Remove(usuarioExclusao);
        }

        public Usuario? RetornaUsuarioPorId(int id)
        {
            var usuario = ListaUsuario.Usuarios.FirstOrDefault(x => x.Id.Equals(id));

            return usuario?.Id > 0 ? usuario : null;
        }

        public IList<Usuario> RetornaUsuario()
        {
            return ListaUsuario.Usuarios;
        }
    }
}
