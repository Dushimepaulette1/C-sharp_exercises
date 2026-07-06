// Exercise 1 — Basic Inheritance
// Create a Vehicle class with the following:

// A public field string Make
// A public field string Model
// A public field int Year
// A method public void StartEngine() that prints "Vroom! Engine started."

// Then create a Car class that:

// Inherits from Vehicle
// Has its own field public int NumberOfDoors
// Has its own method public void Honk() that prints "Beep beep!"
// Take your Vehicle and Car classes from Exercise 1 and:

// Add a constructor to Vehicle that takes make, model, and year as parameters
// Add a constructor to Car that takes make, model, year, and numberOfDoors as parameters and uses base to call Vehicle's constructor


public class Vehicle
{
    public string Make;
    public string Model;
    public int Year;

    public Vehicle(string make, string model, int year)
    {
        this.Make = make;
        this.Model = model;
        this.Year = year;
    }

    public void StartEngine()
    {
        Console.WriteLine("Vroom! Engine started.");

    }
}
