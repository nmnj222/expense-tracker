namespace ExpenseTracker.Dtos
{
    public record AuthResponseDto
    {

        public bool Success { get; set; }
        public required string Message { get; set; }
        public string? Token { get; set; }
    }
}
