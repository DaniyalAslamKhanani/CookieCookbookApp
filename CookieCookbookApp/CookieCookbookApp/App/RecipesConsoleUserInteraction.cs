using CookieCookbookApp.Ingredients.Abstracts;
using CookieCookbookApp.Recipes;

namespace CookieCookbookApp.App;

public class RecipesConsoleUserInteraction : IRecipesUserInteraction
{
    private readonly IngredientsRegister _ingredientsRegister;

    public RecipesConsoleUserInteraction(IngredientsRegister recipesRegister)
    {
        _ingredientsRegister = recipesRegister;
    }

    public void Exit()
    {
        ShowMessage("Press any key to close.");
        Console.ReadKey();
    }

    public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
    {
        if (allRecipes.Count() > 0)
        {
            ShowMessage("Existing recipes are:" + Environment.NewLine);

            var counter = 1;

            foreach (Recipe recipe in allRecipes)
            {
                ShowMessage($"*****{counter}*****:");
                ShowMessage(recipe.ToString());
                ShowMessage(string.Empty);
                counter++;
            }
        }
    }

    public void PromptToCreateRecipe()
    {
        foreach (var ingredients in _ingredientsRegister.All)
        {
            ShowMessage(ingredients.ToString());
        }
    }

    public IEnumerable<Ingredient> ReadIngredientsFromUser()
    {
        var shallStop = false;
        var ingredients = new List<Ingredient>();

        while (!shallStop)
        {
            ShowMessage("Add an ingredient by its ID, " +
                "or type anything else if finished.");

            var userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int id))
            {
                var selectedIngredient = _ingredientsRegister.GetById(id);
                if (selectedIngredient is not null)
                {
                    ingredients.Add(selectedIngredient);
                }
                else
                {
                    ShowMessage("Please type the id in the range of specified list of ingredients");
                }
            }
            else
            {
                shallStop = true;
            }
        }

        return ingredients;
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}