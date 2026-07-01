public class Lists
{
    public static void ListsRun()
    {
        //Declaring a list of doubles 
        List<double> marathons = new List<double> ();
        //Object initialization
        List<double> marathons2 = new List<double> {144.07, 143.12, 146.73, 146.33};

        //Adding to the list 
        marathons.Add(144.07);
        marathons.Add(143.12);
        Console.WriteLine(marathons[1]);

    }
}