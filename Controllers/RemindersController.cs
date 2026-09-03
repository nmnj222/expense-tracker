using ExpenseTracker.Common.Results;
using ExpenseTracker.Dtos;
using ExpenseTracker.Extensions;
using ExpenseTracker.Interfaces;
using ExpenseTracker.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers;

[ApiController]
[Route("api/reminders")]
public class RemindersController(ReminderChannelService _reminderChannelService, IReminderService _reminderService) : ControllerBase
{
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<List<ReminderDto>>> GetUserReminders()
    {
        var userId = User.GetUserId();

        Result<List<ReminderDto>> remindersResult = await _reminderService.GetUserReminders(userId);

        return Ok(remindersResult.Value);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<ReminderDto>> CreateUserReminder([FromBody] CreateReminderDto createDto)
    {
        var userId = User.GetUserId();

        Result<ReminderDto> createReminderResult = await _reminderService.CreateUserReminder(userId, createDto);

        if (createReminderResult == null)
        {
            return BadRequest();
        }

        return Ok(createReminderResult.Value);
    }

    [Authorize]
    [HttpDelete("{reminderId}")]
    public async Task<ActionResult<bool>> DeleteUserReminder([FromRoute] int reminderId)
    {
        var userId = User.GetUserId();

        Result<bool> deleteReminderResult = await _reminderService.DeleteUserReminder(userId, reminderId);

        if (deleteReminderResult.IsFailure)
        {
            return NotFound(deleteReminderResult.Error);
        }

        return NoContent();
    }

    [HttpGet("monthly-cap")]
    public async Task MonthlyCapReminders()
    {
        Console.WriteLine(">>> MONTHLY CAP ENDPOINT HIT");

        Response.ContentType = "text/event-stream";
        Response.Headers.Append("Cache-Control", "no-cache");

        await Response.StartAsync();

        await Response.WriteAsync(": connected\n\n");
        await Response.Body.FlushAsync();

        var cancellationToken = HttpContext.RequestAborted;

        await foreach (var message in _reminderChannelService.Reader.ReadAllAsync(cancellationToken))
        {
            var sseMessage = $"data: {message}\n\n";

            await Response.WriteAsync(sseMessage);
            await Response.Body.FlushAsync(cancellationToken);

        }
    }
}
