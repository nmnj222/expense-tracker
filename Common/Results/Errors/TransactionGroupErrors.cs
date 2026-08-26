namespace ExpenseTracker.Common.Results.Errors
{
    public class TransactionGroupErrors
    {
        public static Error NotFound(int id)
        => new(
             "TransactionGroup.NotFound",
            $"Transaction Group with ID {id} was not found.",
            ErrorType.NotFound
        );
    }
}
