namespace Todos.Api.Utils;

public class Formatters
{
    // method that takes two strings and returns a string
    public static string FormatName(string firstName, string lastName)
    {
        return $"{lastName}, {firstName}";
    }

    public static bool IsLongName(string name)
    {
        return name.Length > 10;
    }
}
