using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VendaVeiculosAPI.Models;
using VendaVeiculosAPI.Utils;

namespace VendaVeiculosAPI.Services.Impl
{
    public class TokenService
    {
        public static string GenerateToken(Usuario usuario)
        {
            //Instancia classe para gerar token
            var tokenHandler = new JwtSecurityTokenHandler();

            //Chave de segurança do token
            var key = Encoding.ASCII.GetBytes(Key._secretKey);

            //Configurações do token (payload)
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //Regras de acesso do usuário (claims) - nome e email
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nome.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString())
                }),

                //Tempo de expiração do token
                Expires = DateTime.UtcNow.AddHours(1),

                //Chave de segurança do token e algoritmo de criptografia
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
