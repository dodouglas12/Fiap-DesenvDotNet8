using Fiap_Aula7_PersistenciaBD.Models;

namespace Fiap_Aula7_PersistenciaBD.Interfaces
{
    public interface ITokenService
    {
        public string GetToken(Usuario usuario);
    }
}
