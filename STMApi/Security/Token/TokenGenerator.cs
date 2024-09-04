using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace STMApi.Security.Token
{
    public static class TokenGenerator
    {

        public static string GenerateToken(ClaimsIdentity claimsIdentity)
        {
            var configure = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var key = Encoding.ASCII.GetBytes(configure["JwtBearerTokenSetting:SecretKey"]);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = configure["JwtBearerTokenSetting:Audience"],
                Issuer = configure["JwtBearerTokenSetting:Issuer"],
                Expires = DateTime.UtcNow.AddSeconds(60)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }
    }
}
