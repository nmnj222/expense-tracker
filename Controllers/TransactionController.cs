using ExpenseTracker.Common.Results;
using ExpenseTracker.Dtos;
using ExpenseTracker.Extensions;
using ExpenseTracker.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers;

[Authorize]
[Route("api/transaction")]
[ApiController]
public class TransactionController(ITransactionService _transactionService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<TransactionDto>>> GetUserTransactions([FromQuery] TransactionFilterDto filterDto)
    {
        var userId = User.GetUserId();

        Result<PagedResult<TransactionDto>> transactionsResult = await _transactionService.GetUserTransactions(userId, filterDto);

        return Ok(transactionsResult.Value);
    }

    [HttpPost]
    public async Task<ActionResult<TransactionDto>> CreateUserTransaction(CreateTransactionDto createDto)
    {
        var userId = User.GetUserId();
        var isUserPremium = User.GetIsPremium();

        Result<TransactionDto> transactionCreateResult = await _transactionService.CreateUserTransaction(userId, isUserPremium, createDto);

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

        Result<bool> deleteTransactionResult = await _transactionService.DeleteUserTransaction(userId, transactionId);

        if (deleteTransactionResult.IsFailure)
        {
            return NotFound(deleteTransactionResult.Error);
        }

        return NoContent();
    }
}
