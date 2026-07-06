public class Conditionals
{
    public static void ConditionalsRun()
    {
        // int socks = 6;
        // if(socks <= 3)
        // {
        //     Console.WriteLine("Time to do laundry!");
        // }
        // else
        // {
        //     Console.WriteLine("Time to do lost!");
        // }
        
        //using the ph example to show how else if conditionals work
        //
        double ph = 4.5;
        // if(ph < 7)
        // {
        //     Console.WriteLine("Acidic");
        // }
        // else if(ph > 7)
        // {
        //     Console.WriteLine("Basic");
        // }
        // else
        // {
        //     Console.WriteLine("Neutral");
        // }
        // switch (ph)
        // {
        //     case <= 3:
        //         Console.WriteLine("Very Acidic");
        //         break;
        //
        //     case < 7:
        //         Console.WriteLine("Acidic");
        //         break;
        //
        //     case >= 11:
        //         Console.WriteLine("Very Basic");
        //         break;
        //
        //     case > 7:
        //         Console.WriteLine("Basic");
        //         break;
        //
        //     default:
        //         Console.WriteLine("Neutral");
        //         break;
        // }
        int pepperLength = 4;
        string message = (pepperLength >= 3.5) ? "ready!" : "wait a little longer";
        Console.WriteLine(message);
    }
}