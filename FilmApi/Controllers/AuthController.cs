using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FilmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        string signingKey = "Bubiraribilgiyazilimdir";
        public string Get(string username, string userId)
        {
            // JWT token creation section
            var claims = new[]
            {
        new Claim(ClaimTypes.Name, username),
        new Claim(JwtRegisteredClaimNames.Sub, userId), // User ID
        };

            // Create a key from the signing key
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));

            // Generate signing credentials
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Create the JWT token
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: "http://filmprojesi.com",
                audience: "Bubiraribilgiyazilimidir",
                claims: claims,
                expires: DateTime.Now.AddDays(15),
                notBefore: DateTime.Now,
                signingCredentials: credentials
            );

            // Return the token as a string
            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return token;
        }

        [HttpGet("ValidationToken")]
        public bool Validationtoken(string token)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
            try
            {
                JwtSecurityTokenHandler handler = new();
                handler.ValidateToken(token, new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityKey,
                    ValidateLifetime = true,
                    ValidateAudience = true,
                    ValidateIssuer = false

                }, out SecurityToken validatedToken);
                var jwtToken = (SecurityToken)validatedToken;
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
