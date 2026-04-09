using System.ComponentModel.DataAnnotations.Schema;
using CulinaryNotes.DataAccess.Entities.Primitives;

namespace CulinaryNotes.DataAccess.Entities;

[Table("Image")]
public class ImageEntity :BaseEntity
{
    public string Name { get; set; }
    public byte[] Data {get; set;}
    public ImageFormat FileExtension { get; set; }
    
    public int RecipeId { get; set; }
    public RecipeEntity Recipe { get; set; }
}