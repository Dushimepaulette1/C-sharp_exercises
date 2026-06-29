// First, create two string variables. The first one is called name and has the value "Shadow".
//     The second one is called breed and has the value "Golden Retriever".
public class Variables
{
    public static void VariablesRun()
    {
        string name = "Shadow";
        string breed = "Golden Retriever";

// Next, create a variable to hold the age. Name the variable age and store the value 5.
        int age = 5;
// Next, create a variable to hold the weight. Name the variable weight and store the value 65.22. 
        double weight = 65.22;
// Next, create a variable that can be either true or false. Name the variable spayed and set it to true. 
        bool spayed = true;
// Use Console.WriteLine() to print each variable to the console. 
        Console.WriteLine($"{name}");
        Console.WriteLine($"{breed}");
        Console.WriteLine($"{age}");
        Console.WriteLine($"{weight}");
        Console.WriteLine($"{spayed}");
    }
}

