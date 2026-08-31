namespace ExpenseTracker.Dtos;

public record UserDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Username { get; set; }
    public bool IsPremium { get; set; }
    public DateTime CreatedAt { get; set; }
}
