using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CulinaryNotes.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CH_Ingredients_Nutrition",
                table: "Ingredient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CH_Ingredients_Nutrition",
                table: "Ingredient",
                sql: "\"Calories\" >= 0 AND \"Proteins\" >= 0 AND \"Fats\" >= 0 AND \"Carbohydrates\" >= 0");
        }
    }
}
