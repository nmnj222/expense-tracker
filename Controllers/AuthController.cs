using ExpenseTracker.Dtos;
using ExpenseTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(AuthService _authService) : ControllerBase
{

    [HttpPost("register")]
    public async Task<ActionResult<AuthResponseDto>> Register (RegisterDto registerDto)
    {
        var result = await _authService.Register(registerDto);

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponseDto>> Login(LoginRequestDto loginDto)
    {
        var result = await _authService.Login(loginDto);

        if (!result.Success)
        {
            return Unauthorized(result.Message);
        }

        return Ok(result);
    }
}
