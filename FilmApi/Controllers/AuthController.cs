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
        public string Get(string username, string password)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,username),
                new Claim(JwtRegisteredClaimNames.Name,password),
            };
            var singinKey = "Bubiraribilgiyazilimdir";
            //biranahtar oluştur diyoruz.
            var securityKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(singinKey));
            //bu anahtarı simetrikgüvenlik anahtarı olarak oluşturu diyoruz.
        
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                 issuer: "http://filmprojesi.com",
                 audience: "Bubiraribilgiyazilimidir",
                 claims: claims,
                 expires: DateTime.Now.AddDays(15),
                 notBefore:DateTime.Now,
                 signingCredentials:credentials

                ) ;
            //yukarıda oluşturduğumuz token bilgilisi jwtSecurityToken yaz
            var token= new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return token;
        }
    }
}
