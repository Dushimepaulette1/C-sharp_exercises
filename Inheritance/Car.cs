public class Car: Vehicle
{
    public int NumberOfDoors;
 
    public Car(string make, string model, int year, int numberOfDoors) : base(make, model, year)

    {
        NumberOfDoors = numberOfDoors;
    }
    public void Honk()
    {
        Console.WriteLine("Beep beep!");
    }
    // Then:
// Override Describe() in Car to return:
// "I am a car made by [Make]"
public override void Describe()
{
    Console.WriteLine($"I am a car made by {this.Make}");
}
}