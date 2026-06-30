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
        
        double ph = 7;
        if(ph < 7)
        {
            Console.WriteLine("Acidic");
        }
        else if(ph > 7)
        {
            Console.WriteLine("Basic");
        }
        else
        {
            Console.WriteLine("Neutral");
        }
    }
}