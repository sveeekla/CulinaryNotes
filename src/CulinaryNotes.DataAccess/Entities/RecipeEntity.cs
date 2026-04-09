using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryNotes.DataAccess.Entities;

[Table("Recipe")] 
public class RecipeEntity : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Instructions { get; set; }
    public bool IsPublic { get; set; }
    public virtual ICollection<RecipeIngredientEntity> Ingredients { get; set; }
    
    public virtual ICollection<ImageEntity> Images { get; set; }
    
    public virtual ICollection<RecipeCategoryEntity> Categories { get; set; }
    
    public int AuthorId { get; set; }
    public UserEntity User { get; set; }
    

}