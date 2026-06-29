public class ArithmeticOperations
{
    public static void ArithmeticOperationsRun()
        {
            // Your Age
            int userAge = 23;
            // Length of years on Jupiter (in Earth years)
            double jupiterYears = 11.86;
            
            // Age on Jupiter
            double jupiterAge = userAge / jupiterYears;
            // Time to Jupiter
            double journeyToJupiter = 6.142466;
            
            // New Age on Earth
            double newEarthAge = userAge + journeyToJupiter;
            // New Age on Jupiter
            double newJupiterAge = newEarthAge/jupiterYears;
            
            // Log calculations to console
            Console.WriteLine(userAge);
            Console.WriteLine(jupiterAge);
            Console.WriteLine(newEarthAge);
            Console.WriteLine(newJupiterAge);
            //Start by creating a variable named steps and initialize it to 0.
            //Next, increment the value of steps by 2 and re-save this new value to steps.
            //Now, decrement the variable steps by 1.
            //Print the final value of steps to the console.
             // Declare steps variable
                  int steps = 0;
            
                  // Two steps forward 
                  steps = steps + 2;
            
                  // One step back 
                  steps = steps--;
            
                  // Print result to the console
                  Console.WriteLine(steps);


        }
}