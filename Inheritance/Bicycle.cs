// Create a Motorcycle class that also inherits from Vehicle and overrides Describe() to return:

// "I am a motorcycle made by [Make]"
// In your Main method:

// Create one Car and one Motorcycle using constructors
// Call Describe() on both and print the 
public class Bicycle: Car
{
    public Bicycle(string make, string model, int year,  int numberOfDoors) : base(make, model, year, numberOfDoors)
    {
        // NumberOfDoors = numberOfDoors;
    }
    public override void Describe()
{
    Console.WriteLine($"I am a car made by {this.Make}");
}
}

