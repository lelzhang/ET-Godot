namespace GodotUtils;

using System;
using System.Linq;
using System.Globalization;
using System.Text.RegularExpressions;

public static class ExtensionsString
{
    public static bool IsAddress(this string v) =>
        v != null && (Regex.IsMatch(v, @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}") || v.Contains("localhost"));

    public static string AddSpaceBeforeEachCapital(this string v) =>
        string.Concat(v.Select(x => char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');

    public static string ToTitleCase(this string v) =>
        CultureInfo.CurrentCulture.TextInfo.ToTitleCase(v.ToLower());

    public static bool IsMatch(this string v, string expression) =>
        Regex.IsMatch(v, expression);

    public static bool IsNum(this string v) =>
        int.TryParse(v, out _);

    public static string SmallWordsToUpper(this string v, int maxLength = 2, Func<string, bool> filter = null)
    {
        string[] words = v.Split(' ');

        for (int i = 0; i < words.Length; i++)
            if (words[i].Length <= maxLength && (filter == null || filter(words[i])))
                words[i] = words[i].ToUpper();

        return string.Join(" ", words);
    }

    public static bool IsDigitsOnly(this string v)
    {
        foreach (char c in v)
        {
            if (c < '0' || c > '9')
                return false;
        }

        return true;
    }
}
