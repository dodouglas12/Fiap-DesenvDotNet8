using System.ComponentModel.DataAnnotations.Schema;
using Fiap_Aula8_DocumentandoAPI.Enums;

namespace Fiap_Aula8_DocumentandoAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public TipoPemissaoSistema PermissaoSistema { get; set; }
    }
}
