using System.ComponentModel.DataAnnotations.Schema;
using Fiap_Aula7_PersistenciaBD.Enums;

namespace Fiap_Aula7_PersistenciaBD.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public TipoPemissaoSistema PermissaoSistema { get; set; }
    }
}
