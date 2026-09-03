namespace ExpenseTracker.Common.Results.Errors;

public static class ReminderErrors
{
    public static Error NotFound(int id)
=> new(
     "Reminder.NotFound",
    $"Reminder with ID {id} was not found.",
    ErrorType.NotFound
);

    public static Error NotFound()
    => new(
         "Reminder.NotFound",
        $"Reminder was not found.",
        ErrorType.NotFound
    );
}
