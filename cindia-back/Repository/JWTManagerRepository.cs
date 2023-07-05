using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using cindia_back.Auth;
using cindia_back.Models.Dto;
using Microsoft.IdentityModel.Tokens;

namespace cindia_back.Repository;

public class JWTManagerRepository:IJWTManagerRepository
{

    private readonly IConfiguration _configuration;

    public JWTManagerRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public Tokens Authenticate(string? tel, string? password)
    {
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, tel)                    
            }),
            Expires = DateTime.UtcNow.AddMinutes(10),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return new Tokens { Token = tokenHandler.WriteToken(token) };
    }
}