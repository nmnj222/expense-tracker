using ExpenseTracker.Common.Results;
using ExpenseTracker.Dtos;

namespace ExpenseTracker.Interfaces;

public interface IUserService
{
    Task<Result<UserDto>> GetMe(int Id);
    Task<Result<UserDto>> UpdateUser(int id, UpdateUserDto updateUserDto);
}
