using ExpenseTracker.Common.Results;
using ExpenseTracker.Dtos;
using ExpenseTracker.Extensions;
using ExpenseTracker.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class TransactionGroupController(TransactionGroupService _transactionGroupService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<TransactionGroupDto>>> GetUserTransactionGroups()
    {
        var userId = User.GetUserId();

        Result<List<TransactionGroupDto>> transactionGroupResult = await _transactionGroupService.GetUserTransactionGroups(userId);

        return Ok(transactionGroupResult.Value);
    }

    [HttpGet("{transactionGroupId}")]
    public async Task<ActionResult<TransactionGroupDetailsDto?>> GetUserTransactionGroupDetails([FromRoute] int transactionGroupId)
    {
        var userId = User.GetUserId();

        Result<TransactionGroupDetailsDto> transactionGroupDetailsResult = await _transactionGroupService.GetUserTransactionGroupDetails(userId, transactionGroupId);

        if (transactionGroupDetailsResult.IsFailure)
        {
            return NotFound(transactionGroupDetailsResult.Error);
        }

        return Ok(transactionGroupDetailsResult.Value);
    }

    [HttpPost]
    public async Task<ActionResult<TransactionGroupDto>> CreateUserTransactionGroup([FromBody] CreateTransactionGroupDto createDto)
    {
        var userId = User.GetUserId();

        Result<TransactionGroupDto> createTransactionGroupResult = await _transactionGroupService.CreateTransactionGroup(userId, createDto);

        if (createTransactionGroupResult == null)
        {
            return BadRequest();
        }

        return Ok(createTransactionGroupResult.Value);
    }

    [HttpDelete("{transactionGroupId}")]
    public async Task<IActionResult> DeleteTransactionGroup([FromRoute] int transactionGroupId)
    {
        var userId = User.GetUserId();

        var result = await _transactionGroupService.DeleteTransactionGroup(userId, transactionGroupId);

        if (result.IsFailure)
        {
            return NotFound(result.Error);
        }

        return NoContent();
    }
}
