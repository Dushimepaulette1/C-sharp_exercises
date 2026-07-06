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
}