using CookieCookbookApp.App;
using CookieCookbookApp.DataAccess;
using CookieCookbookApp.FileAccess;

const string fileName = "recipes";
const FileFormat format = FileFormat.Json;

var ingredientsRegister = new IngredientsRegister();

IStringsRepository stringsRepository = format == FileFormat.Txt ? new StringsTextualRepository() 
                                            : new StringsJsonRepository();

var cookieReceipeApp = new CookieRecipeApp(new RecipesRepository(stringsRepository, ingredientsRegister),
                                            new RecipesConsoleUserInteraction(ingredientsRegister));
var file = new FileMetaData(fileName, format);

cookieReceipeApp.Run(file.ToPath());
