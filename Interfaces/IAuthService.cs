using ExpenseTracker.Common.Results;
using ExpenseTracker.Dtos;

namespace ExpenseTracker.Interfaces;

public interface IAuthService
{
    Task<Result<AuthResponseDto>> Register(RegisterDto registerDto);
    Task<Result<AuthResponseDto>> Login(LoginRequestDto loginDto);
}
