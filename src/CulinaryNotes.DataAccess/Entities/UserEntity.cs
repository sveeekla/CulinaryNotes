using System.ComponentModel.DataAnnotations.Schema;
using CulinaryNotes.DataAccess.Entities.Primitives;
using Microsoft.AspNetCore.Identity;
namespace CulinaryNotes.DataAccess.Entities;

[Table("User")] 
public class UserEntity : IdentityUser<int> , IBaseEntity
{
    public string Email { get; set; }
    public string Name { get; set; }
    public UserRole UserRole { get; set; }
    public Guid ExternalId { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }
    public virtual ICollection<RecipeEntity> Recipes { get; set; }
}

public class UserRoleEntity : IdentityRole<int>
{
}