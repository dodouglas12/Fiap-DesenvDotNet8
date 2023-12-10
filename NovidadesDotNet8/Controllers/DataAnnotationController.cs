using Microsoft.AspNetCore.Mvc;
using NovidadesDotNet8.Models.DataAnnotation;
using System.ComponentModel.DataAnnotations;

namespace NovidadesDotNet8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataAnnotationController : ControllerBase
    {
        [HttpPost("AllowedValues")]
        public string AllowedValues([FromBody] AlunoFeriado alunoFeriado)
        {
            //Resultado das Validações
            var resultadoValidacoes = new List<ValidationResult>();

            //Nesse cenário, caso alguma validação seja ativada, irá retornar erro 400
            Validator.TryValidateObject(alunoFeriado,
                                        new ValidationContext(alunoFeriado),
                                        resultadoValidacoes,
                                        validateAllProperties: true);

            //Campos informados corretamente
            return "Sucesso";
        }

        [HttpPost("Base64String")]
        public string Base64String([FromBody] Base64String base64String)
        {
            //Resultado das Validações
            var resultadoValidacoes = new List<ValidationResult>();

            //Nesse cenário, caso alguma validação seja ativada, irá retornar erro 400
            Validator.TryValidateObject(base64String,
                                        new ValidationContext(base64String),
                                        resultadoValidacoes,
                                        validateAllProperties: true);

            //Campos informados corretamente
            return "Sucesso";
        }

        [HttpPost("ValorExclusivo")]
        public string ValorExclusivo([FromBody] ValorExclusivo valorExclusivo)
        {
            //Resultado das Validações
            var resultadoValidacoes = new List<ValidationResult>();

            //Nesse cenário, caso alguma validação seja ativada, irá retornar erro 400
            Validator.TryValidateObject(valorExclusivo,
                                        new ValidationContext(valorExclusivo),
                                        resultadoValidacoes,
                                        validateAllProperties: true);

            //Campos informados corretamente
            return "Sucesso";
        }
    }
}
