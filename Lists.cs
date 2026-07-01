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
        
        //containing and couting in lists
        Console.WriteLine(marathons2.Contains(143.23));
        Console.WriteLine(marathons2.Count);
        
        //Removing an item from a list
        bool removed = marathons2.Remove(143.12);
        Console.WriteLine(marathons2[1]);
        Console.WriteLine(removed);
        
        //Removing everything in the list
        marathons2.clear();


    }
}