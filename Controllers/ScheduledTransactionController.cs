using ExpenseTracker.Common.Results;
using ExpenseTracker.Dtos;
using ExpenseTracker.Extensions;
using ExpenseTracker.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers;

[Authorize]
[Route("api/scheduled-transaction")]
[ApiController]
public class ScheduledTransactionController(ITransactionService _transactionService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<ScheduledTransactionDto>>> GetUserScheduledTransactions()
    {
        var userId = User.GetUserId();

        Result<List<ScheduledTransactionDto>> scheduledTransactionsResult = await _transactionService.GetUserScheduledTransactions(userId);

        return Ok(scheduledTransactionsResult.Value);
    }

    [HttpPost]
    public async Task<ActionResult<ScheduledTransactionDto>> CreateUserScheduledTransaction(CreateScheduledTransactionDto createScheduledDto)
    {
        var userId = User.GetUserId();

        Result<ScheduledTransactionDto> scheduledTransactionCreateResult = await _transactionService.CreateUserScheduledTransaction(userId, createScheduledDto);

        if (scheduledTransactionCreateResult.IsFailure)
        {
            return BadRequest(scheduledTransactionCreateResult.Error);
        }

        return Ok(scheduledTransactionCreateResult.Value);
    }

    [HttpDelete("{scheduledTransactionId}")]
    public async Task<IActionResult> DeleteUserScheduledTransaction([FromRoute] int scheduledTransactionId)
    {
        var userId = User.GetUserId();

        Result<bool> deleteScheduledTransactionResult = await _transactionService.DeleteUserScheduledTransaction(userId, scheduledTransactionId);

        if (deleteScheduledTransactionResult.IsFailure)
        {
            return NotFound(deleteScheduledTransactionResult.Error);
        }

        return NoContent();
    }

}
