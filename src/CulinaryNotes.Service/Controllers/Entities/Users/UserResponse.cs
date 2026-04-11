namespace CulinaryNotes.Controllers.Entities.Users;

public class UserResponse
{
    public Guid ExternalId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
}