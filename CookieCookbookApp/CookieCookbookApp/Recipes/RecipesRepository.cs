using CookieCookbookApp.DataAccess;
using CookieCookbookApp.Ingredients.Abstracts;
using CookieCookbookApp.Recipes;

public class RecipesRepository : IRecipesRepository
{
    private readonly IStringsRepository _stringsRepository;
    private readonly IIngredientsRegister _ingredientsRegister;
    private static readonly string Separator = ",";
    public RecipesRepository(IStringsRepository stringRepository, IIngredientsRegister ingredientsRegister)
    {
        _stringsRepository = stringRepository;
        _ingredientsRegister = ingredientsRegister;
    }

    public List<Recipe> Read(string filePath)
    {
        var recipes = new List<Recipe>();
        if (File.Exists(filePath))
        {
            var strings = _stringsRepository.Read(filePath);
           
            foreach (var recipeFromFile in strings)
            {
                var recipe = RecipeFromString(recipeFromFile);
                recipes.Add(recipe);
            }

            return recipes;
        }

        return recipes;
    }

    private Recipe RecipeFromString(string recipeFromFile)
    {
        var textualIds = recipeFromFile.Split(Separator);
        var ingredients = new List<Ingredient>();

        foreach (var textualId in textualIds)
        {
            var id = int.Parse(textualId);
            var ingredient = _ingredientsRegister.GetById(id);
            ingredients.Add(ingredient);
        }

        return new Recipe(ingredients);
    }

    public void Write(string filePath, List<Recipe> allRecipes)
    {
        var recipesAsStrings = new List<string>();
        foreach (var recipe in allRecipes)
        {
            recipesAsStrings.Add(string.Join(Separator, recipe.Ingredients.Select(r => r.Id)));
        }
        _stringsRepository.Write(filePath, recipesAsStrings);
    }
}
