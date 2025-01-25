using CookieCookbookApp.Recipes;

namespace CookieCookbookApp.App;

/// <summary>
/// Represents an application for managing cookie recipes, including reading, displaying, and adding new recipes.
/// Utilizes a repository for storing recipes and an interface for user interactions.
/// </summary>
public class CookieRecipeApp
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly IRecipesUserInteraction _recipesUserInteraction;

    public CookieRecipeApp(IRecipesRepository recipesRepository, IRecipesUserInteraction recipesUserInteraction)
    {
        _recipesRepository = recipesRepository;
        _recipesUserInteraction = recipesUserInteraction;
    }

    /// <summary>
    /// Initializes a new instance of the CookieRecipeApp with the provided repository and user interaction interfaces.
    /// </summary>
    /// <param name="recipesRepository">The repository used to read and write recipe data.</param>
    /// <param name="recipesUserInteraction">The interface responsible for user interactions, such as displaying messages and receiving inputs.</param>
    public void Run(string filePath)
    {
        var allRecipes = _recipesRepository.Read(filePath);
        _recipesUserInteraction.PrintExistingRecipes(allRecipes);
        _recipesUserInteraction.PromptToCreateRecipe();
        var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

        if (ingredients?.Count() > 0)
        {
            var recipe = new Recipe(ingredients);
            allRecipes.Add(recipe);
            _recipesRepository.Write(filePath, allRecipes);

            _recipesUserInteraction.ShowMessage("Recipe added:");
            _recipesUserInteraction.ShowMessage(recipe.ToString());


        }
        else
        {
            _recipesUserInteraction.ShowMessage("Not ingredient selected. The recipe will not be saved");
        }

        _recipesUserInteraction.Exit();
    }
}