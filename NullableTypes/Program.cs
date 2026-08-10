using System;

public class ReadingStatus
{
  public string Message { get; set; }
  public bool? IsValid { get; set; }
}

public class SensorReading
{
  public decimal? Value { get; set; }
  public DateTime? LastUpdated { get; set; }
  public ReadingStatus Status { get; private set; }

  public void Update(decimal? value)
  {
    Value = value;

    if (value.HasValue)
    {
      LastUpdated = DateTime.Now;
      Status = new ReadingStatus { Message = "OK", IsValid = true };
    }
    else
    {
      LastUpdated = null;
      Status = new ReadingStatus { Message = "No Reading", IsValid = false };
    }
  }

  public string GetStatusSummary()
  {
    return $"Status: {Status?.Message ?? "Unknown"}, Valid: {Status?.IsValid ?? false}";
  }
}

public class TemperatureSensor
{
  private const decimal MinTemp = -40;
  private const decimal MaxTemp = 60;

  public SensorReading Temperature { get; set; } = new SensorReading();

  public string ValidateReading()
  {
    if (!Temperature.Value.HasValue)
    {
      return "No reading available";
    }

    if (Temperature.Value >= MinTemp && Temperature.Value <= MaxTemp)
    {
      return "Reading is valid";
    }

    return "Reading is out of range";
  }
}

public class Schedule
{
  public decimal? DayTarget { get; set; }
  public decimal? NightTarget { get; set; }
  private const decimal DefaultTarget = 20;

  public decimal GetCurrentTarget(bool isDaytime)
  {
    return (isDaytime ? DayTarget : NightTarget) ?? DefaultTarget;
  }
}

class Program {
  static void Main(string[] args) {
    Console.WriteLine("Smart Temperature Sensor Starting Up...");

    Console.WriteLine("\n--- Task Group 1: Sensor Reading ---");
    SensorReading reading = new SensorReading();
    reading.Update(22.5m);
    Console.WriteLine($"Value: {reading.Value}, LastUpdated: {reading.LastUpdated}");
    reading.Update(null);
    Console.WriteLine($"Value: {reading.Value}, LastUpdated: {reading.LastUpdated}");

    Console.WriteLine("\n--- Task Group 2: Reading Validation ---");
    TemperatureSensor sensor = new TemperatureSensor();
    Console.WriteLine(sensor.ValidateReading());
    sensor.Temperature.Update(150m);
    Console.WriteLine(sensor.ValidateReading());
    sensor.Temperature.Update(25m);
    Console.WriteLine(sensor.ValidateReading());

    Console.WriteLine("\n--- Task Group 3: Temperature Schedule ---");
    Schedule schedule = new Schedule();
    Console.WriteLine($"Day target (none set): {schedule.GetCurrentTarget(true)}");
    schedule.DayTarget = 23m;
    Console.WriteLine($"Day target (set to 23): {schedule.GetCurrentTarget(true)}");

    Console.WriteLine("\n--- Task Group 4: Reading Status ---");
    SensorReading statusReading = new SensorReading();
    Console.WriteLine(statusReading.GetStatusSummary());
    statusReading.Update(21m);
    Console.WriteLine(statusReading.GetStatusSummary());
  }
}