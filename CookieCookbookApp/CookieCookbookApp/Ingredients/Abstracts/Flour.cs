﻿namespace CookieCookbookApp.Ingredients.Abstracts;

public abstract class Flour : Ingredient
{
    public override string PreparationInstructions => $"Sieve. {base.PreparationInstructions}";
}
