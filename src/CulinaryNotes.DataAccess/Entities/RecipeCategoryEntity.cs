using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryNotes.DataAccess.Entities;

[Table("RecipeCategory")]
public class RecipeCategoryEntity : BaseEntity
{
    public int RecipeId { get; set; }
    public virtual RecipeEntity Recipe { get; set; }
    
    public int CategoryId { get; set; }
    public virtual CategoryEntity Category { get; set; }
}