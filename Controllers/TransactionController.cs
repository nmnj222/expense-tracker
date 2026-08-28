using ExpenseTracker.Common.Results;
using ExpenseTracker.Dtos;
using ExpenseTracker.Extensions;
using ExpenseTracker.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class TransactionController(ITransactionService _transactionService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<TransactionDto>>> GetUserTransactions()
    {
        var userId = User.GetUserId();

        Result<List<TransactionDto>> transactionsResult = await _transactionService.GetUserTransactions(userId);

        return Ok(transactionsResult.Value);
    }

    [HttpPost]
    public async Task<ActionResult<TransactionDto>> CreateUserTransaction(CreateTransactionDto createDto)
    {
        var userId = User.GetUserId();
        Result<TransactionDto> transactionCreateResult = await _transactionService.CreateUserTransaction(userId, createDto);

        if (transactionCreateResult.IsFailure)
        {
            return BadRequest(transactionCreateResult.Error);
        }

        return Ok(transactionCreateResult.Value);
    }

    [HttpGet("{transactionId}")]
    public async Task<ActionResult<TransactionDetailsDto>> GetUserTransactionDetail(int transactionId)
    {
        var userId = User.GetUserId();

        Result<TransactionDetailsDto> transactionDetailsResult = await _transactionService.GetUserTransactionDetails(userId, transactionId);

        if (transactionDetailsResult.IsFailure)
        {
            return NotFound(transactionDetailsResult.Error);
        }

        return Ok(transactionDetailsResult.Value);
    }

    [HttpDelete("{transactionId}")]
    public async Task<IActionResult> DeleteUserTransaction([FromRoute] int transactionId)
    {
        var userId = User.GetUserId();

        Result<bool> result = await _transactionService.DeleteUserTransaction(userId, transactionId);

        if (result.IsFailure)
        {
            return NotFound(result.Error);
        }

        return NoContent();
    }
}
