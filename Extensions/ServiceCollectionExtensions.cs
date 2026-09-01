using Coravel;
using ExpenseTracker.Interfaces;
using ExpenseTracker.Jobs;
using ExpenseTracker.Repositories;
using ExpenseTracker.Services;

namespace ExpenseTracker.Extensions;

public static class ServiceCollectionExtensions
{

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAuthorization();
        services.AddScheduler();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITransactionGroupService, TransactionGroupService>();
        services.AddScoped<ITransactionService, TransactionService>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddTransient<ProcessScheduledTransactions>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();

        return services;
    }
}
