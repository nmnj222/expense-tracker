using ExpenseTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers;

[ApiController]
[Route("api/reminders")]
public class RemindersController(ReminderChannelService _reminderService) : ControllerBase
{
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

        await foreach (var message in _reminderService.Reader.ReadAllAsync(cancellationToken))
        {
            var sseMessage = $"data: {message}\n\n";

            await Response.WriteAsync(sseMessage);
            await Response.Body.FlushAsync(cancellationToken);

        }
    }
}
