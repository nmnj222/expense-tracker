using ExpenseTracker.Data;
using ExpenseTracker.Dtos;
using ExpenseTracker.Mappers;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Common.Results;
using ExpenseTracker.Common.Results.Errors;

namespace ExpenseTracker.Services;

public class UserService(ApplicationDbContext _context)
{
    public async Task<Result<UserDto>> GetMe(int Id)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == Id);

        if (user is null)
        {
            return Result<UserDto>.Failure(UserErrors.NotFound(Id));
        }

        return Result<UserDto>.Success(UserMapper.ToDto(user));
    }

    public async Task<Result<UserDto>> UpdateUser(int id, UpdateUserDto updateUserDto)
    {
        User? user = await _context.Users.FindAsync(id);

        if (user is null)
        {
            return Result<UserDto>.Failure(UserErrors.NotFound(id));
        }

        user.Username = updateUserDto.Username;
        user.Email = updateUserDto.Email;
        user.Name = updateUserDto.Name;
        user.LastName = updateUserDto.LastName;
        user.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return Result<UserDto>.Success(UserMapper.ToDto(user));
    }

    private static UserDto UserToDto(User user) =>
        new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            LastName = user.LastName,
            Username = user.Username,
            CreatedAt = user.CreatedAt
        };
}
