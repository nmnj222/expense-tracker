namespace ExpenseTracker.Common.Results.Errors
{
    public static class AuthErrors
    {

        public static Error InvalidCredentials => new("Auth.InvalidCredentials", "Invalid username or password", ErrorType.Unauthorized);
        public static Error UsernameAlreadyExists => new("Auth.UsernameAlreadyExists", "Username already exists", ErrorType.Conflict);
    }
}
