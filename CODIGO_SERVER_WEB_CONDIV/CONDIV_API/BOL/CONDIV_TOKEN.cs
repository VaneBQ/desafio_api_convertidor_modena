using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.BOL
{
    public class CONDIV_TOKEN
    {
        public string CREAR_TOKEN(int ID_USUARIO, string CO_USUARIO)
        {
            string token_retorno = "";
            var _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration.GetSection("Jwt")["Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("ID", ID_USUARIO.ToString()),
                        new Claim("USUARIO", CO_USUARIO)
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt")["Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration.GetSection("Jwt")["Issuer"],
                _configuration.GetSection("Jwt")["Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);
            var tokenHandler = new JwtSecurityTokenHandler();
            token_retorno = tokenHandler.WriteToken(token);
            return token_retorno;
        }
    }
}
