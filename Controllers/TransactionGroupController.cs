using ExpenseTracker.Dtos;
using ExpenseTracker.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExpenseTracker.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class TransactionGroupController : ControllerBase
{

    private readonly TransactionGroupService _transactionGroupService;

    public TransactionGroupController(TransactionGroupService transactionGroupService)
    {
        _transactionGroupService = transactionGroupService;
    }

    [HttpGet]
    public async Task<ActionResult<List<TransactionGroupDto>>> GetUserTransactionGroups()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null)
        {
            return Unauthorized();
        }

        var result = await _transactionGroupService.GetUserTransactionGroups(int.Parse(userId));

        return Ok(result.Value);
    }

    [HttpGet("{transactionGroupId}")]
    public async Task<ActionResult<TransactionGroupDetailsDto?>> GetUserTransactionGroupDetails([FromRoute] int transactionGroupId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null)
        {
            return Unauthorized();
        }

        var result = await _transactionGroupService.GetUserTransactionGroupDetails(int.Parse(userId), transactionGroupId);

        if (result.IsFailure)
        {
            return NotFound(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<ActionResult<TransactionGroupDto>> CreateUserTransactionGroup([FromBody] CreateTransactionGroupDto createDto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null)
        {
            return Unauthorized();
        }

        var result = await _transactionGroupService.CreateTransactionGroup(int.Parse(userId), createDto);

        if (result == null)
        {
            return BadRequest();
        }

        return Ok(result.Value);
    }

    [HttpDelete("{transactionGroupId}")]
    public async Task<IActionResult> DeleteTransactionGroup([FromRoute] int transactionGroupId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId is null)
        {
            return Unauthorized();
        }

        var result = await _transactionGroupService.DeleteTransactionGroup(int.Parse(userId), transactionGroupId);

        if (result.IsFailure)
        {
            return NotFound(result.Error);
        }

        return NoContent();
    }
}
