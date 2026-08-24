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
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    //adjust return type mapping

    [HttpGet("me")]
    public async Task<ActionResult<UserDto>> GetMe()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if(userId == null)
        {
            return Unauthorized();
        }

        var user = await _userService.GetMe(int.Parse(userId));

        if(user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPatch("me")]
    public async Task<ActionResult<UserDto>> UpdateUser([FromBody] UpdateUserDto updateUserDto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null)
        {
            return Unauthorized();
        }

        var user = await _userService.UpdateUser(int.Parse(userId), updateUserDto);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }
}
