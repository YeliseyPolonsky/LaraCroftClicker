using System.Globalization;

public class Formater
{
    private static string[] _postfixes = new[]
    {
        "","K","M","B","T","Q","S","U","Y"
    };

    public static string Format(double value)
    {
        int postfixIndex = 0;

        for (int i = 0; i < _postfixes.Length; i++)
        {
            if (value > 1000)
            {
                value = value / 1000;
                postfixIndex++;
            }
            else
            {
                break;
            }
        }

        string postFix = _postfixes[postfixIndex];
        return value.ToString("0.##", CultureInfo.CreateSpecificCulture("en-GB")) + postFix;
    }
}