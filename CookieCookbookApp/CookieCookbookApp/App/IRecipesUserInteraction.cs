﻿using CookieCookbookApp.Ingredients.Abstracts;
using CookieCookbookApp.Recipes;

namespace CookieCookbookApp.App;

public interface IRecipesUserInteraction
{
    void ShowMessage(string message);
    void Exit();
    void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
    void PromptToCreateRecipe();
    IEnumerable<Ingredient> ReadIngredientsFromUser();
}