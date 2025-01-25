using CookieCookbookApp.Ingredients;
using CookieCookbookApp.Ingredients.Abstracts;

public class IngredientsRegister : IIngredientsRegister
{
    public List<Ingredient> All =>
    [
        new WheatFlour(),
        new CoconutFlour(),
        new Butter(),
        new Chocolate(),
        new Sugar(),
        new Cardamom(),
        new Cinnamon(),
        new CocoaPowder()
    ];

    public Ingredient GetById(int id)
    {
        return All.FirstOrDefault(x => x.Id == id);
    }
}