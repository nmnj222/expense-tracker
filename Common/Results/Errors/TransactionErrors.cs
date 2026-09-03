namespace ExpenseTracker.Common.Results.Errors;

public static class TransactionErrors
{

    public static Error NotFound(int id) =>
    new(
            "Transaction.NotFound",
            $"Transaction with ID {id} was not found.",
            ErrorType.NotFound
     );

    public static Error BadRequestScheduledAtMissing() =>
    new(
        "Transaction.BadRequest",
        "Transaction marked as scheduled is required to have a schedule date.",
        ErrorType.BadRequest
     );

    public static Error BadRequestScheduledExcess() =>
    new(
        "Transaction.BadRequest",
        "Transaction not marked as scheduled can't have a schedule date.",
        ErrorType.BadRequest
    );
}
