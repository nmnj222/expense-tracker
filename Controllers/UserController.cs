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

        Result<UserDto> result = await _userService.GetMe(int.Parse(userId));

        if (result.IsFailure)
        {
            return NotFound(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpPatch("me")]
    public async Task<ActionResult<UserDto>> UpdateUser([FromBody] UpdateUserDto updateUserDto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null)
        {
            return Unauthorized();
        }

        Result<UserDto> result = await _userService.UpdateUser(int.Parse(userId), updateUserDto);

        if (result.IsFailure)
        {
            return NotFound(result.Error);
        }

        return Ok(result.Value);
    }
}
