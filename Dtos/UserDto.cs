namespace ExpenseTracker.Dtos;

public class UserDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Username { get; set; }
    public bool isPremium { get; set; }
    public DateTime CreatedAt { get; set; }
}
