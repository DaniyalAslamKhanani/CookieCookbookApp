﻿using CookieCookbookApp.Ingredients.Abstracts;

namespace CookieCookbookApp.Ingredients;

public class Chocolate : Ingredient
{
    public override int Id => 4;
    public override string Name => "Chocolate";
    public override string PreparationInstructions => "Melt in a water bath. Add to other ingredients.";
}
