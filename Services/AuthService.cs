using ExpenseTracker.Data;
using ExpenseTracker.Dtos;
using ExpenseTracker.Interfaces;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Common.Results;
using ExpenseTracker.Common.Results.Errors;

namespace ExpenseTracker.Services;

public class AuthService(ApplicationDbContext _context, TokenService _tokenService, IPasswordHasher _passwordHasher)
{

    public async Task<Result<AuthResponseDto>> Register(RegisterDto registerDto)
    {
        var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == registerDto.Username);

        if (existingUser is not null)
        {
            return Result<AuthResponseDto>.Failure(AuthErrors.UsernameAlreadyExists);
        }

        var user = new User
        {
            Username = registerDto.Username,
            Password = _passwordHasher.Hash(registerDto.Password),
            Email = registerDto.Email
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        var response = new AuthResponseDto
        {
            Success = true,
            Message = "Registration successful."
        };

        return Result<AuthResponseDto>.Success(response);
    }

    public async Task<Result<AuthResponseDto>> Login(LoginRequestDto loginDto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == loginDto.Username);

        if (user is null)
        {
            return Result<AuthResponseDto>.Failure(AuthErrors.InvalidCredentials);
        }

        var passwordValid = _passwordHasher.Verify(
            loginDto.Password,
            user.Password
            );

        if (!passwordValid)
        {
            return Result<AuthResponseDto>.Failure(AuthErrors.InvalidCredentials);
        }

        var token = _tokenService.GenerateToken(user);

        var result = new AuthResponseDto
        {
            Message = "Login Successful",
            Token = token
        };

        return Result<AuthResponseDto>.Success(result);
    }
}
