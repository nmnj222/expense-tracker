using ExpenseTracker.Interfaces;
using ExpenseTracker.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExpenseTracker.Services;

public class TokenService(IConfiguration config) : ITokenService
{

    public readonly IConfiguration _config = config;
    private readonly string _secretKey = config["ApiSettings:Secret"];
    private readonly string _issuer = config["ApiSettings:Issuer"]!;
    private readonly string _audience = config["ApiSettings:Audience"]!;
    private readonly int _accessTokenExpiryMinutes =
            config.GetValue<int>("ApiSettings:AccessTokenExpiryMinutes", 60);

    

    public string GenerateToken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Email, user.Email)
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_accessTokenExpiryMinutes),
            signingCredentials: creds
            );

        return new JwtSecurityTokenHandler().WriteToken(token);

    }
}
