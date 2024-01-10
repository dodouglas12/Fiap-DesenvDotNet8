using Fiap_Aula8_DocumentandoAPI.Models;

namespace Fiap_Aula8_DocumentandoAPI.Interfaces
{
    public interface ITokenService
    {
        public string GetToken(Usuario usuario);
    }
}
