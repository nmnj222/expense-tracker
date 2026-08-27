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
        Result<AuthResponseDto> authRegisterResult = await _authService.Register(registerDto);

        if (authRegisterResult.IsFailure)
        {
            return authRegisterResult.Error!.Type switch
            {
                ErrorType.Conflict => Conflict(authRegisterResult.Error),
                _ => StatusCode(500, authRegisterResult.Error)
            };
        }
        return Ok(authRegisterResult.Value);
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponseDto>> Login(LoginRequestDto loginDto)
    {
        Result<AuthResponseDto> authLoginResult = await _authService.Login(loginDto);

        if (authLoginResult.IsFailure)
        {
            return authLoginResult.Error!.Type switch
            {
                ErrorType.Unauthorized => Unauthorized(authLoginResult.Error),
                _ => StatusCode(500, authLoginResult.Error)
            };
        }

        return Ok(authLoginResult.Value);
    }
}
