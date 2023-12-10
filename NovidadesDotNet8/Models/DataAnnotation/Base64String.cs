using System.ComponentModel.DataAnnotations;

namespace NovidadesDotNet8.Models.DataAnnotation
{
    public class Base64String
    {
        /// <summary>
        /// Validação de base64 - Exemplo: UHJpbWVpcm8gaXRlbQ==
        /// </summary>
        [Base64String(ErrorMessage = "String base64 invalida")]
        public string Arquivo { get; set; }
    }
}
