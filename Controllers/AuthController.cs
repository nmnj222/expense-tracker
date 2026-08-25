using ExpenseTracker.Common.Results;
using ExpenseTracker.Dtos;
using ExpenseTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(AuthService _authService) : ControllerBase
{

    [HttpPost("register")]
    public async Task<ActionResult<AuthResponseDto>> Register(RegisterDto registerDto)
    {
        var result = await _authService.Register(registerDto);

        if (result.IsFailure)
        {
            return result.Error!.Type switch
            {
                ErrorType.Conflict => Conflict(result.Error),
                _ => StatusCode(500, result.Error)
            };
        }
        return Ok(result.Value);
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponseDto>> Login(LoginRequestDto loginDto)
    {
        var result = await _authService.Login(loginDto);

        if (result.IsFailure)
        {
            return result.Error.Type switch
            {
                ErrorType.Unauthorized => Unauthorized(result.Error),
                _ => StatusCode(500, result.Error)
            };
        }

        return Ok(result.Value);
    }
}
