namespace CookieCookbookApp.FileAccess;

public static class FileFormatExtensions
{
    public static string AsFileExtension(this FileFormat fileFormat)
    {
        return fileFormat.ToString().ToLower();
    }
}