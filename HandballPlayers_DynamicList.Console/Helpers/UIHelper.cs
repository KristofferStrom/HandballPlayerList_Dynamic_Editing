namespace HandballPlayers_DynamicList.Console.Helpers;

public static class UIHelper
{
    public static string CreateDivider(int length)
    {
        string divider = "";
        for (int i = 0; i < length; i++)
        {
            divider += "-";
        }

        return divider;
    }

    public static string CreateWhitespace(int length)
    {
        string whitespace = "";
        for (int i = 0; i < length; i++)
        {
            whitespace += " ";
        }

        return whitespace;
    }
}
