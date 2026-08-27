using ExpenseTracker.Dtos;
using ExpenseTracker.Models;

namespace ExpenseTracker.Mappers;

public static class UserMapper
{
    public static UserDto ToDto(User user) =>
    new UserDto
    {
        Id = user.Id,
        Name = user.Name,
        LastName = user.LastName,
        Username = user.Username,
        CreatedAt = user.CreatedAt
    };

}
