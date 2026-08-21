using ExpenseTracker.Dtos;
using ExpenseTracker.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet]
    public async Task<ActionResult<UserDto>> GetUsers()
    {
        var users = await _userService.GetUsers();
        return Ok(users);
    }

    //adjus return type mapping
    [HttpPost]
    public async Task<ActionResult<UserDto>> CreateUser(CreateUserDto createUserDto)
    {
        var user = await _userService.CreateUser(createUserDto);

        return Ok(user);
    }


    //adjus return type mapping
    [HttpPatch("{id}")]
    public async Task<ActionResult<UserDto>> UpdateUser([FromRoute] int id, [FromBody] UpdateUserDto updateUserDto)
    {
        UserDto? user = await _userService.UpdateUser(id, updateUserDto);

        if(user is null)
        {
            return NotFound();
        }
        return Ok(user);
    }
}
