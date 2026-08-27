using ExpenseTracker.Common.Results;
using ExpenseTracker.Dtos;
using ExpenseTracker.Models;
using ExpenseTracker.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExpenseTracker.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UserController(UserService _userService) : ControllerBase
{
    //adjust return type mapping

    [HttpGet("me")]
    public async Task<ActionResult<UserDto>> GetMe()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null)
        {
            return Unauthorized();
        }

        Result<UserDto> getMeResult = await _userService.GetMe(int.Parse(userId));

        if (getMeResult.IsFailure)
        {
            return NotFound(getMeResult.Error);
        }

        return Ok(getMeResult.Value);
    }

    [HttpPatch("me")]
    public async Task<ActionResult<UserDto>> UpdateUser([FromBody] UpdateUserDto updateUserDto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null)
        {
            return Unauthorized();
        }

        Result<UserDto> updateUserResult = await _userService.UpdateUser(int.Parse(userId), updateUserDto);

        if (updateUserResult.IsFailure)
        {
            return NotFound(updateUserResult.Error);
        }

        return Ok(updateUserResult.Value);
    }
}
