using Microsoft.IdentityModel.Tokens;
using BookApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookApi.Helper
{
    public class GenerateToken
    {

        public  string GenerateTokenJwt(int id)
        {
            try
            {
                var mySecret = "ayse1258aayyssee";
                var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));

                var myIssuer = "https://github.com/AysenurGunes";//temporary
                var myAudience = "https://github.com/AysenurGunes";//temporary

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
            new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    Issuer = myIssuer,
                    Audience = myAudience,
                    SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
