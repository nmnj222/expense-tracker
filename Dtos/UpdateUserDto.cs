namespace ExpenseTracker.Dtos;

public record UpdateUserDto
{
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }

}
