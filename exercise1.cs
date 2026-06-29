public class exercise
{
    public static void exerciseRun()
    {
        // write a program that
        // converts a boolean to a string
        bool likeDogs = true;
        string likesDogs = Convert.ToString(likeDogs);
        Console.WriteLine(likeDogs);

        // changes a string to a list of chars
        string name = "paulette";
        List<char> nameChars = name.ToList();
        Console.WriteLine(nameChars);

    }
}