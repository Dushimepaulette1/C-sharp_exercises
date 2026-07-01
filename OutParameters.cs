public class OutParameters()
{
    public static void OutParametersRun()
    {
        string scoreAsString = "85.6";
        string statement = "Hello World";
        bool outcome;
        double scoreAsDouble;
        outcome = Double.TryParse(scoreAsString, out scoreAsDouble);
        Console.WriteLine(outcome);
        Console.WriteLine(scoreAsDouble);
        Console.WriteLine(Whisper("Paulette is so beautiful!!!", out bool marker));
    }  
    static string Whisper(string statement, out bool marker)
    {
        marker = false;
        return statement.ToLower();
        marker = true;
    }
}