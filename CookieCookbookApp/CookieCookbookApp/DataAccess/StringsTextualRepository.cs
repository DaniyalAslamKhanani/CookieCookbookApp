using CookieCookbookApp.DataAccess;

public class StringsTextualRepository : StringsRepository
{
    private static readonly string Separator = Environment.NewLine;

    protected override string StringsToText(List<string> strings)
    {
        return string.Join(Separator, strings);
    }

    protected override List<string> TextToStrings(string text)
    {
        return text.Split(Separator).ToList();
    }
}
