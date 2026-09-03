using ExpenseTracker.Common.Results;
using ExpenseTracker.Dtos;
using ExpenseTracker.Extensions;
using ExpenseTracker.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace ExpenseTracker.Controllers;

[ApiController]
[Route("api/reminders")]
public class RemindersController(IReminderService _reminderService) : ControllerBase
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

    [Authorize]
    [HttpGet("notifications")]
    public async Task StreamNotifications()
    {

        var userId = User.GetUserId();
        var cancellationToken = HttpContext.RequestAborted;

        Response.ContentType = "text/event-stream";
        Response.Headers.Append("Cache-Control", "no-cache");

        await Response.StartAsync();

        await Response.WriteAsync(": connected\n\n");
        await Response.Body.FlushAsync(cancellationToken);

        while (!cancellationToken.IsCancellationRequested)
        {
            var notifications = await _reminderService.GetUnreadNotifications(userId, cancellationToken);

            foreach (var notification in notifications)
            {
                var json = JsonSerializer.Serialize(notification);

                await Response.WriteAsync($"data: {json}\n\n", cancellationToken);

                await Response.Body.FlushAsync(cancellationToken);
            }

            if (notifications.Count > 0)
            {
                await _reminderService.MarkAsRead(notifications, cancellationToken);
            }

            await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);

        }
    }
}
