using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NovidadesDotNet8.Models.Json;
using System.Text.Json;

namespace NovidadesDotNet8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JsonController : ControllerBase
    {
        /// <summary>
        /// Endpoint para teste de mapeamento de membros recebidos
        /// Exemplos de Requisição:
        /// { "Nome": "Teste", "Idade": 18 }
        /// { "Nome": "Teste", "Idade": 18, "Endereco": "Rua Teste" }
        /// </summary>
        [HttpPost("mapeamentoJson")]
        public IActionResult MapeamentoJson(string corpo)
        {
            return Ok(JsonSerializer.Deserialize<PropertyMapping>(corpo));
        }

        /// <summary>
        /// Endpoint para teste de policies do Json
        /// </summary>
        [HttpGet("policiesJson")]
        public IActionResult PoliciesJson(string policie)
        {
            ManipulacaoPolicies[] clientes = [
                new ManipulacaoPolicies { NomeCompleto = "Teste 1", EnderecoResidencia = "Teste 1", TelefoneCelular = "Teste 1" },
                new ManipulacaoPolicies { NomeCompleto = "Teste 2", EnderecoResidencia = "Teste 2", TelefoneCelular = "Teste 2" },
                new ManipulacaoPolicies { NomeCompleto = "Teste 3", EnderecoResidencia = "Teste 3", TelefoneCelular = "Teste 3" }
            ];

            string resultado = string.Empty;

            //Switch aplicado somente para exemplificação didática
            //Lembrando que a definição de policie também funciona para o Deserializer
            switch (policie.ToLower())
            {
                case "pascal":
                    resultado = JsonSerializer.Serialize(clientes);
                    break;
                case "camel":
                    resultado = JsonSerializer.Serialize(clientes,
                        new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                    break;
                case "snake lower":
                    resultado = JsonSerializer.Serialize(clientes,
                        new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower });
                    break;
                case "snake upper":
                    resultado = JsonSerializer.Serialize(clientes,
                        new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseUpper });
                    break;
                case "kebab lower":
                    resultado = JsonSerializer.Serialize(clientes,
                        new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.KebabCaseLower });
                    break;
                case "kebab upper":
                    resultado = JsonSerializer.Serialize(clientes,
                        new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.KebabCaseUpper });
                    break;
                default:
                    break;
            }

            return Ok(resultado);
        }
    }
}
