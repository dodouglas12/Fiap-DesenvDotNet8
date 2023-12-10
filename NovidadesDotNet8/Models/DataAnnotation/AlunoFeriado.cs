using System.ComponentModel.DataAnnotations;

namespace NovidadesDotNet8.Models.DataAnnotation
{
    public class AlunoFeriado
    {
        /// <summary>
        /// Validação de valores permitidos
        /// </summary>
        [Required]
        [AllowedValues("Natal", "Ano Novo", ErrorMessage = "Esse feriado o aluno deverá ter aula")]
        public string Feriado { get; set; }

        /// <summary>
        /// Validação de valores não permitidos
        /// </summary>
        [Required]
        [DeniedValues("string", "", null, ErrorMessage = "Necessário informar um valor")]
        public string NomeAluno { get; set; }
    }
}
