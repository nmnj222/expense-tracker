using ExpenseTracker.Interfaces;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ExpenseTracker.Services;

public class PasswordHasher(IConfiguration _configuration) : IPasswordHasher
{

    public string Hash(string password)
    {
        var pepper = _configuration["PasswordPepper"];

        if (string.IsNullOrEmpty(pepper))
        {
            throw new InvalidOperationException("Password pepper is not configured");
        }
        return BCrypt.Net.BCrypt.HashPassword(password + pepper);
    }

    public bool Verify(string password, string hash)
    {
        var pepper = _configuration["PasswordPepper"];

        if (string.IsNullOrEmpty(pepper))
        {
            throw new InvalidOperationException("Password pepper is not configured");
        }
        return BCrypt.Net.BCrypt.Verify(password + pepper, hash);
    }
}
