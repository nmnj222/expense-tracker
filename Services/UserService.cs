using ExpenseTracker.Data;
using ExpenseTracker.Dtos;
using ExpenseTracker.Mappers;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Services;

public class UserService(ApplicationDbContext _context)
{

    public async Task<UserDto?> GetMe(int Id)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == Id);

        return user == null ? null : UserMapper.ToDto(user);
    }

    public async Task<UserDto?> UpdateUser(int id, UpdateUserDto updateUserDto)
    {
        User? user = await _context.Users.FindAsync(id);

        if (user is null)
        {
            return null;
        }

        user.Username = updateUserDto.Username;
        user.Email = updateUserDto.Email;
        user.Name = updateUserDto.Name;
        user.LastName = updateUserDto.LastName;
        user.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return UserMapper.ToDto(user);
    }
}
