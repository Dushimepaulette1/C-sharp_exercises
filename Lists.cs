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
        marathons2.Clear();
        
        List<string> runners = new List<string> { "Jemima Sumgong", "Tiki Gelana", "Constantina Tomescu", "Mizuki Noguchi" };
        Random rand = new Random();
      
        Console.WriteLine("In reverse chronological order, the gold medalists are...");
      
        
        // The second for loop in the code is used to print out a bib for each runner.
        // Replace it with a foreach loop that achieves the same objective.
        // First loop
        for (int i = 0; i < runners.Count; i++)
        {
            Console.WriteLine($"{i+1}: {runners[i]}");
        }
      
        Console.WriteLine("\nPrinting runner bibs...");
      
        // Second loop
        foreach (string runner in runners)
        {
            string name = runner.ToUpper();
            int id = rand.Next(100, 1000);
            Console.WriteLine($"{id} - {name}");
        }
        // AddRange() — takes an array or list as an argument. Adds the values to the end of the list. Returns nothing.
        //     InsertRange() — takes an int and array or list as an argument. Adds the values at the int index. Returns nothing.
        //     RemoveRange() — takes two int values. The first int is the index at which to begin removing, and the second int is the number of elements to remove. Returns nothing.
        //     GetRange() — takes two int values. The first int is the index of the first desired element, and the second int is the number of elements in the desired range. Returns a list of the same type.
        List<double> topMarathons = marathons2.GetRange(0,3);

    }
}