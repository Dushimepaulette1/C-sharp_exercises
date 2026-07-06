public class GettingInput
{
    public static void Run()
    {
        /*This program asks a user how old they are and displays their age in the terminal */
        Console.WriteLine("How old are you?");
        string input = Console.ReadLine();
        Console.WriteLine($"You are {input} years old");
    }
}