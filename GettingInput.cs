public class GettingInput
{
    public static void Run()
    {
        Console.WriteLine("How old are you?");
        string input = Console.ReadLine();
        Console.WriteLine($"You are {input} years old");
    }
}