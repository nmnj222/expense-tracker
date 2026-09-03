using Coravel;
using ExpenseTracker.Jobs;

namespace ExpenseTracker.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/openapi/v1.json", "Expense Tracker API v1");
            });
        }

        app.Services.UseScheduler(scheduler =>
        {
            scheduler.Schedule<ProcessScheduledTransactions>()
            .HourlyAt(1);
        });

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        return app;
    }
}
