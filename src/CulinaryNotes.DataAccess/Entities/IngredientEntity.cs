using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryNotes.DataAccess.Entities;
[Table("Ingredient")]
public class IngredientEntity : BaseEntity
{
    public double Calories { get; set; }    
    public double Proteins { get; set; }    
    public double Fats { get; set; }        
    public double Carbohydrates { get; set; } 
    
    public virtual ICollection<RecipeIngredientEntity> RecipeIngredients { get; set; }
}