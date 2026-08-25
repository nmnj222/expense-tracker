using ExpenseTracker.Data;
using ExpenseTracker.Dtos;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.NativeInterop;

namespace ExpenseTracker.Services;

public class AuthService(ApplicationDbContext _context, TokenService _tokenService)
{

    public async Task<AuthResponseDto> Register(RegisterDto registerDto)
    {
        var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == registerDto.Username);

        if (existingUser != null)
        {
            return new AuthResponseDto
            {
                Success = false,
                Message = "Username already exists."
            };
        }

        var user = new User
        {
            Username = registerDto.Username,
            Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
            Email = registerDto.Email
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return new AuthResponseDto
        {
            Success = true,
            Message = "Registration successful."
        };
    }

    public async Task<AuthResponseDto> Login(LoginRequestDto loginDto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == loginDto.Username);

        if (user == null)
        {
            return new AuthResponseDto
            {
                Success = false,
                Message = "Invalid username or password."
            };
        }

        var passwordValid = BCrypt.Net.BCrypt.Verify(
            loginDto.Password,
            user.Password
            );

        if (!passwordValid)
        {
            return new AuthResponseDto
            {
                Success = false,
                Message = "Invalid username or password."
            };
        }

        var token = _tokenService.GenerateToken(user);

        return new AuthResponseDto
        {
            Success = true,
            Message = "Login successful.",
            Token = token
        };
    }
}
