using CulinaryNotes.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CulinaryNotes.DataAccess.Context;

public class CulinaryNotesDbContext : DbContext
{
    public DbSet<IngredientEntity> Ingredients { get; set; }
    public DbSet<RecipeEntity> Recipes { get; set; }
    public DbSet<RecipeIngredientEntity> RecipeIngredients { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<RecipeCategoryEntity> CategoryEntities { get; set; }
    public DbSet<ImageEntity> Images { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }

    public CulinaryNotesDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Email).IsUnique();
            entity.Property(e => e.Email).HasMaxLength(255).IsRequired();
            entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
        
            entity.Property(e => e.UserRole);
            
            // CHECK CONSTRAINT для email
            entity.HasCheckConstraint("CH_Users_Email", "\"Email\" LIKE '%@%.%'");
        });
        
        modelBuilder.Entity<RecipeEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).HasMaxLength(200).IsRequired();
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Instructions).HasColumnType("text");
            entity.Property(e => e.IsPublic).HasDefaultValue(false);
        
            entity.HasOne(r => r.User)
                .WithMany(u => u.Recipes)
                .HasForeignKey(r => r.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
              
            // CHECK CONSTRAINT для дат
            entity.HasCheckConstraint("CH_Recipes_Dates", "\"CreationTime\" <= \"ModificationTime\"");
        });
        
        modelBuilder.Entity<CategoryEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Name).IsUnique();
            entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
        });
        
        modelBuilder.Entity<RecipeCategoryEntity>(entity =>
        {
            entity.HasKey(rc => rc.Id);
        
            // Составной уникальный индекс
            entity.HasIndex(rc => new { rc.RecipeId, rc.CategoryId })
                .IsUnique();
        
            // Внешние ключи
            entity.HasOne(rc => rc.Recipe)
                .WithMany(r => r.Categories)
                .HasForeignKey(rc => rc.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);
              
            entity.HasOne(rc => rc.Category)
                .WithMany(c => c.Recipes)
                .HasForeignKey(rc => rc.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<IngredientEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Calories).HasPrecision(10, 2);
            entity.Property(e => e.Proteins).HasPrecision(10, 2);
            entity.Property(e => e.Fats).HasPrecision(10, 2);
            entity.Property(e => e.Carbohydrates).HasPrecision(10, 2);
            
        });
        
        modelBuilder.Entity<RecipeIngredientEntity>(entity =>
        {
            entity.HasKey(ri => ri.Id);
            entity.Property(ri => ri.Quantity).HasPrecision(10, 2).IsRequired(); //10 цифр всего, 2 после запятой
            entity.Property(ri => ri.Notes).HasMaxLength(500);
        
            // Составной уникальный индекс
            entity.HasIndex(ri => new { ri.RecipeId, ri.IngredientId })
                .IsUnique();
        
            // Внешние ключи
            entity.HasOne(ri => ri.Recipe)
                .WithMany(r => r.Ingredients)
                .HasForeignKey(ri => ri.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);
              
            entity.HasOne(ri => ri.Ingredient)
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(ri => ri.IngredientId)
                .OnDelete(DeleteBehavior.Restrict);
              
            // CHECK CONSTRAINT для количества
            entity.HasCheckConstraint("CH_RecipeIngredients_Quantity", "\"Quantity\" > 0");
        });
        
        modelBuilder.Entity<ImageEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(255).IsRequired();
            entity.Property(e => e.Data).HasColumnType("bytea").IsRequired(); // bytea для PostgreSQL
            
            entity.Property(e => e.FileExtension)
                .HasConversion<int>(); 
        
            // Внешний ключ на Recipes
            entity.HasOne(i => i.Recipe)
                .WithMany(r => r.Images)
                .HasForeignKey(i => i.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}