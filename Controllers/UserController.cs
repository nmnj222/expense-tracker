using ExpenseTracker.Common.Results;
using ExpenseTracker.Dtos;
using ExpenseTracker.Extensions;
using ExpenseTracker.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers;

[Authorize]
[Route("api/user")]
[ApiController]
public class UserController(IUserService _userService) : ControllerBase
{

    [HttpGet("me")]
    public async Task<ActionResult<UserDto>> GetMe()
    {
        var userId = User.GetUserId();
        Console.WriteLine(User.GetIsPremium());

        Result<UserDto> getMeResult = await _userService.GetMe(userId);

        if (getMeResult.IsFailure)
        {
            return NotFound(getMeResult.Error);
        }

        return Ok(getMeResult.Value);
    }

    [HttpPatch("me")]
    public async Task<ActionResult<UserDto>> UpdateUser([FromBody] UpdateUserDto updateUserDto)
    {
        var userId = User.GetUserId();

        Result<UserDto> updateUserResult = await _userService.UpdateUser(userId, updateUserDto);

        if (updateUserResult.IsFailure)
        {
            return NotFound(updateUserResult.Error);
        }

        return Ok(updateUserResult.Value);
    }
}
