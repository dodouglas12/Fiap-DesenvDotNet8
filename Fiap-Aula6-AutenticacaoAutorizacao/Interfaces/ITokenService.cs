using Fiap_Aula6_AutenticacaoAutorizacao.Models;

namespace Fiap_Aula6_AutenticacaoAutorizacao.Interfaces
{
    public interface ITokenService
    {
        public string GetToken(Usuario usuario);
    }
}
