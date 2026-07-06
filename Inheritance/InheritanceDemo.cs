// In your Main method:

// Create a Car object and set all its fields
// Call both StartEngine() and Honk() on it
// Print all its fields to the consolepublic class InheritanceDemo
public class InheritanceDemo{

    public static void InheritanceRun()
    {
        // Create a Car object, set all its fields,
        Car car = new Car("2012", "Mercedes Benz", 2014, 6);
        // car.NumberOfDoors = 4;
        // car.Model = "Mercedes Benz";
        // car.Make = "2012";
        // car.Year = 2008;

        // call StartEngine() and Honk(),
        car.StartEngine();
        car.Honk();
        // then print all its fields to the console.
        // In your Main method:

// Create a Car object using the constructor in one line
// Print all its fields to confirm everything was set correctly
        Console.WriteLine(car.NumberOfDoors);
        Console.WriteLine(car.Model);
        Console.WriteLine(car.Make);
        Console.WriteLine(car.Year);

    }
}
