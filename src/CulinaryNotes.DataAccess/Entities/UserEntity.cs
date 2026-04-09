using System.ComponentModel.DataAnnotations.Schema;
using CulinaryNotes.DataAccess.Entities.Primitives;

namespace CulinaryNotes.DataAccess.Entities;

[Table("User")] 
public class UserEntity : BaseEntity
{
    public string Email { get; set; }
    public string Name { get; set; }
    public UserRole UserRole { get; set; }
    public virtual ICollection<RecipeEntity> Recipes { get; set; }
}