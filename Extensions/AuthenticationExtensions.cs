using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
namespace ExpenseTracker.Extensions;

public static class AuthenticationExtensions
{
    public static IServiceCollection AddAuthenticationAndAuthorization(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = configuration["ApiSettings:Issuer"],
                ValidAudience = configuration["ApiSettings:Audience"],

                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["ApiSettings:Secret"]!))
            };

            options.Events = new JwtBearerEvents
            {
                OnTokenValidated = context =>
                {
                    var userIdClaim = context.Principal?.FindFirstValue(ClaimTypes.NameIdentifier);

                    if (!int.TryParse(userIdClaim, out _))
                    {
                        context.Fail("Invalid user ID claim.");
                    }
                    return Task.CompletedTask;
                }
            };
        });

        return services;
    }
}
