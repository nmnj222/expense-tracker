using ExpenseTracker.Interfaces;
using ExpenseTracker.Services;

namespace ExpenseTracker.Extensions;

public static class ServiceCollectionExtensions
{

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAuthorization();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITransactionGroupService, TransactionGroupService>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }
}
