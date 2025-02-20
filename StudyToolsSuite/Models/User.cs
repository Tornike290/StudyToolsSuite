namespace StudyToolsSuite.Models;

public class User
{
    public int Id { get; set; }
    public required string FirstName { get; set; } 
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string RetypedPassword { get; set; }
    public string? Username { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool? Subscribed { get; set; }
}