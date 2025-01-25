using CookieCookbookApp.Ingredients.Abstracts;

public interface IIngredientsRegister
{
    List<Ingredient> All { get; }

    Ingredient GetById(int id);
}