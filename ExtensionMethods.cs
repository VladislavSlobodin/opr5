namespace opr5;

public static class ExtensionMethods
{
    public static T MaxOrDefault<T>(this IEnumerable<T> enumerable) => enumerable.Any() ? enumerable.Max()! : default!;

    public static string Join<T>(this IEnumerable<T> values, string separator) => string.Join(separator, values);

    public static string Reverse(this string str)
    {
        var chars = str.ToCharArray();
        Array.Reverse(chars);
        return new(chars);
    }
}