using CulinaryNotes.BL.Features.Users.Entities;

namespace CulinaryNotes.Controllers.Entities.Users;

public class UsersListResponse
{
    public List<UserModel> Users { get; set; }
}