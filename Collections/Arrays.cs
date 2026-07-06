
public class Arrays
{
    public static void ArraysRun()
    {
        string[] summerStrut;
        summerStrut = new string[] {"Juice", "Missing U", "Raspberry Beret", "New York Groove", "Make me feel", "Rebel Rebel", "Despacito", "Los Angeles"};
        int[] ratings = {1,2,3,4,5,1,2,3}; 
        // Basic implicitly typed array
        var numbers = new[] { 1, 10, 100, 1000 };  // Inferred as int[]

// String array with null elements
        var names = new[] { "hello", null, "world" };  // Inferred as string[]

// Mixed numeric types
        var mixedNumbers = new[] { 1, 2.5, 3.7f };  // Inferred as double[]

// Won't compile - no common type
// var invalid = new[] { "text", 123, true };

// Won't compile - cannot create empty implicitly typed array
// var empty = new[] { };
// plantHeights will be equal to [0, 0, 0]
        int[] plantHeights = new int[3]; 

// plantHeights will now be [0, 0, 8]
        plantHeights[2] = 8; 
        int[] plantHeights2 = { 3, 6, 4, 1 };

// plantHeights will be { 1, 3, 4, 6 }
        Array.Sort(plantHeights2); 

    }
}