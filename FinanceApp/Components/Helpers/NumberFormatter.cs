namespace FinanceApp.Components.Helpers;

public static class NumberFormatter
{
    public static string FormatWithSpaces(string str)
    {
        if (str.Contains(','))
        {
            string[] splitString = str.Split(',');
            char[] stringReverse = splitString[0].ToCharArray();
            Array.Reverse(stringReverse);
            str = new string(stringReverse);
            string result = "";
            for (int i = 1; i <= str.Length; i++)
            {
                if (i % 3 == 0)
                {
                    result += str[i - 1];
                    result += " ";
                }
                else
                {
                    result += str[i - 1];
                }
            }
            char[] chars = result.ToCharArray();
            Array.Reverse(chars);
            return new string(chars) + "," + splitString[1];
        }
        else
        {
            char[] stringReverse = str.ToCharArray();
            Array.Reverse(stringReverse);
            str = new string(stringReverse);
            string result = "";
            for (int i = 1; i <= str.Length; i++)
            {
                if (i % 3 == 0)
                {
                    result += str[i - 1];
                    result += " ";
                }
                else
                {
                    result += str[i - 1];
                }
            }
            char[] chars = result.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
}
