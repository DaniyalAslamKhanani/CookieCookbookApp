
using System.Text.Json;

namespace CookieCookbookApp.DataAccess;

public class StringsJsonRepository : StringsRepository
{
    protected override string StringsToText(List<string> strings)
    {
        return JsonSerializer.Serialize(strings);
    }

    protected override List<string> TextToStrings(string text)
    {
        return JsonSerializer.Deserialize<List<string>>(text);
    }
}