using System.Text.RegularExpressions;

namespace Common.Domain.Tools;
public static class TextHelper
{
    public static bool IsText(this string value)
    {
        var isNumber = Regex.IsMatch(value, @"^\d+$");
        return !isNumber;
    }

    public static string ToSlug(this string url)
    {
        return url.Trim().ToLower()
            .Replace("$", "")
            .Replace("+", "")
            .Replace("%", "")
            .Replace("?", "")
            .Replace("^", "")
            .Replace("*", "")
            .Replace("@", "")
            .Replace("!", "")
            .Replace("#", "")
            .Replace("&", "")
            .Replace("~", "")
            .Replace("(", "")
            .Replace("=", "")
            .Replace(")", "")
            .Replace("/", "")
            .Replace(@"\", "")
            .Replace(".", "")
            .Replace(" ", "-");
    }
}