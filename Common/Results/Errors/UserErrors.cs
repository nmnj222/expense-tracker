namespace ExpenseTracker.Common.Results.Errors;

public static class UserErrors
{
    public static Error NotFound(int id)
        => new(
            "User.NotFound",
            $"User with ID {id} was not found.",
            ErrorType.NotFound
        );

}
