using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryNotes.DataAccess.Entities;

[Table("Category")]
public class CategoryEntity : BaseEntity
{
    public string Name { get; set; }
    
    public virtual ICollection<RecipeCategoryEntity> Recipes { get; set; }
}