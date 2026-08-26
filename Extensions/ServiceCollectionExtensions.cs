using ExpenseTracker.Interfaces;
using ExpenseTracker.Services;

namespace ExpenseTracker.Extensions;

public static class ServiceCollectionExtensions
{

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAuthorization();
        services.AddScoped<AuthService>();
        services.AddScoped<TokenService>();
        services.AddScoped<UserService>();
        services.AddScoped<TransactionGroupService>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }
}
