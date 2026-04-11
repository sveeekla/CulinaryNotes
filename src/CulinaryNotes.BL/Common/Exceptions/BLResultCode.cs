using System.ComponentModel;
namespace CulinaryNotes.BL.Common.Exceptions;

public enum BLResultCode
{
     // ========== Общие ошибки (1xxx) ==========
    [Description("Validation error.")] 
    ValidationError = 1001,
    
    [Description("Unauthorized access.")] 
    Unauthorized = 1002,
    
    [Description("Forbidden access.")] 
    Forbidden = 1003,
    
    [Description("Internal server error.")] 
    InternalServerError = 1004,
    
    [Description("Invalid operation.")] 
    InvalidOperation = 1005,

    // ========== Ошибки пользователей (2xxx) ==========
    [Description("User not found.")] 
    UserNotFound = 2001,
    
    [Description("User already exists.")] 
    UserAlreadyExists = 2002,
    
    [Description("Email or password is incorrect.")]
    EmailOrPasswordIsIncorrect = 2003,
    
    [Description("User creation failure.")]
    UserCreationFailure = 2004,
    
    [Description("User update failure.")]
    UserUpdateFailure = 2005,
    
    [Description("User deletion failure.")]
    UserDeletionFailure = 2006,
    
    [Description("Invalid email format.")]
    InvalidEmailFormat = 2007,
    
    [Description("Password is too weak.")]
    WeakPassword = 2008,
    
    [Description("User is blocked.")]
    UserBlocked = 2009,

    // ========== Ошибки рецептов (3xxx) ==========
    [Description("Recipe not found.")]
    RecipeNotFound = 3001,
    
    [Description("Recipe already exists.")]
    RecipeAlreadyExists = 3002,
    
    [Description("Recipe creation failure.")]
    RecipeCreationFailure = 3003,
    
    [Description("Recipe update failure.")]
    RecipeUpdateFailure = 3004,
    
    [Description("Recipe deletion failure.")]
    RecipeDeletionFailure = 3005,
    
    [Description("You can only edit your own recipes.")]
    ForbiddenEditRecipe = 3006,
    
    [Description("You can only delete your own recipes.")]
    ForbiddenDeleteRecipe = 3007,
    
    [Description("Recipe title is required.")]
    RecipeTitleRequired = 3008,
    
    [Description("Recipe must have at least one ingredient.")]
    RecipeMustHaveIngredients = 3009,
    
    [Description("Recipe must have at least one step.")]
    RecipeMustHaveSteps = 3010,
    
    [Description("Cooking time must be positive.")]
    InvalidCookingTime = 3011,
    
    [Description("Invalid difficulty level.")]
    InvalidDifficulty = 3012,

    // ========== Ошибки ингредиентов (4xxx) ==========
    [Description("Ingredient not found.")]
    IngredientNotFound = 4001,
    
    [Description("Ingredient already exists.")]
    IngredientAlreadyExists = 4002,
    
    [Description("Ingredient creation failure.")]
    IngredientCreationFailure = 4003,
    
    [Description("Ingredient update failure.")]
    IngredientUpdateFailure = 4004,
    
    [Description("Ingredient deletion failure.")]
    IngredientDeletionFailure = 4005,
    
    [Description("Ingredient name is required.")]
    IngredientNameRequired = 4006,
    
    [Description("Invalid grams value.")]
    InvalidGramsValue = 4007,
    
    [Description("Grams must be positive.")]
    GramsMustBePositive = 4008,

    // ========== Ошибки категорий (5xxx) ==========
    [Description("Category not found.")]
    CategoryNotFound = 5001,
    
    [Description("Category already exists.")]
    CategoryAlreadyExists = 5002,
    
    [Description("Category creation failure.")]
    CategoryCreationFailure = 5003,
    
    [Description("Category update failure.")]
    CategoryUpdateFailure = 5004,
    
    [Description("Category deletion failure.")]
    CategoryDeletionFailure = 5005,
    
    [Description("Category name is required.")]
    CategoryNameRequired = 5006,
    
    [Description("Cannot delete category with recipes.")]
    CategoryHasRecipes = 5007,
    // ========== Ошибки изображений (6xxx) ==========
    [Description("Image not found.")]
    ImageNotFound = 6001,
    
    [Description("Image already exists.")]
    ImageAlreadyExists = 6002,
    
    [Description("Image upload failure.")]
    ImageUploadFailure = 6003,
    
    [Description("Image deletion failure.")]
    ImageDeletionFailure = 6004,
    
    [Description("Invalid image format.")]
    InvalidImageFormat = 6005,
    
    [Description("Image size exceeds limit.")]
    ImageSizeExceedsLimit = 6006,

    // ========== Ошибки питания и ChatGPT (7xxx) ==========
    [Description("Nutrition data not available.")]
    NutritionDataUnavailable = 7001,
    
    [Description("ChatGPT API error.")]
    ChatGPTApiError = 7002,
    
    [Description("Failed to calculate nutrition.")]
    NutritionCalculationFailure = 7003,
    
    [Description("ChatGPT API key not configured.")]
    ChatGptApiKeyMissing = 7004,
    
    [Description("ChatGPT request timeout.")]
    ChatGptTimeout = 7005,
    
    [Description("Identity server error.")]
    IdentityServerError = 8001
    
}