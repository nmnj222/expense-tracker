using ExpenseTracker.Models;

namespace ExpenseTracker.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
}
