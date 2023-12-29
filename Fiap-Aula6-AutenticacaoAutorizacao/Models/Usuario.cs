using Fiap_Aula6_AutenticacaoAutorizacao.Enums;

namespace Fiap_Aula6_AutenticacaoAutorizacao.Models
{
    // Lista que vamos usar em memória para simular a consulta de usuários cadastrados
    public static class ListaUsuario
    {
        public static IList<Usuario> Usuarios { get; set; }
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public TipoPemissaoSistema PermissaoSistema { get; set; }
    }
}
