using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryNotes.DataAccess.Entities;

[Table("RecipeIngredient")]
public class RecipeIngredientEntity : BaseEntity
{
    public double Quantity { get; set; }
    public string Notes { get; set; }
    
    public int RecipeId { get; set; }
    public virtual RecipeEntity Recipe { get; set; }
    
    public int IngredientId { get; set; }
    public virtual IngredientEntity Ingredient { get; set; }
}