using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Fiap_Aula7_PersistenciaBD.Interfaces;
using Fiap_Aula7_PersistenciaBD.Models;

namespace Fiap_Aula7_PersistenciaBD.Services
{
    public class TokenService : ITokenService
    {

        // Configura a injeção de dependência das configurações do appSettings na nossa service
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration) {
            _configuration = configuration;
        }

        public string GetToken(Usuario usuario)
        {
            // Variável responsável por gerar o token
            var tokenHandler = new JwtSecurityTokenHandler(); 

            // Recupera a chave que criamos no nosso appSettings e convert para um array de bytes
            var chaveCriptografia = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretJWT"));
            
            // O Descriptor é responsável por definir todas as propriedades que o nosso token terá quando descriptografarmos
            var tokenPropriedades = new SecurityTokenDescriptor() 
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Username),
                    new Claim(ClaimTypes.Role, (usuario.PermissaoSistema - 1).ToString()),
                    // É possível adicionar Claims personalizadas, conforme o exemplo abaixo
                    new Claim("ClaimPersonalizada_1", "Nossa claim 1"),
                    new Claim("ClaimPersonalizada_2", "Nossa claim 2")
                }),
                
                // Tempo de expiração do token
                Expires = DateTime.UtcNow.AddHours(8), 
                
                // Adiciona a nossa chave de criptografia
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(chaveCriptografia),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            // Cria o nosso token e devolve pro método solicitante
            var token = tokenHandler.CreateToken(tokenPropriedades);
            return tokenHandler.WriteToken(token);

        }
    }
}
