namespace HandballPlayers_DynamicList.Console.ExtensionsMethods;
using System;

public static class UserInterfaceExtensions
{
    public static int GetInt(this string input, string fieldName)
    {
        int num;
        while (true)
        {
            if ((int.TryParse(input, out num) == true) || input.Equals("q", StringComparison.CurrentCultureIgnoreCase))
                break;
            
            Console.WriteLine("Only digits");
            Console.Write(fieldName + ": ");

            input = Console.ReadLine()!;
        }

        return num;
    }

    public static int GetRequiredNumbers(this int input, string fieldName, int min, int max)
    {
        while (true)
        {
            if ((input >= min && input <= max) || input == 0)
                break;

            Console.WriteLine($"Only numbers between {min} and {max}");
            Console.Write(fieldName + ": ");

            input = Console.ReadLine()!.GetInt(fieldName);
        }

        return input;
    }
}
