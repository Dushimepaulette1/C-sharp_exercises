public class ConvertDataTypes
{
    public static void ConvertDataTypesRun()
    {
        Console.WriteLine("What is your favorite number?");
        int favoriteNumber = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Your favorite number is {favoriteNumber}");
    }
}