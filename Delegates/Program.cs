using System;

namespace SmartHome 
{
  public class Sensors 
  {
    private static Random _random = new Random();
        
    public static double GetTemperature(string sensorId)
    {
      return 65 + _random.NextDouble() * 15;
    }
        
    public static double GetHumidity(string sensorId) 
    {
      return 30 + _random.NextDouble() * 30;
    }
        
    public static double GetMotion(string sensorId)
    {
      return _random.NextDouble();
    }
  }

  public class HomeAutomation 
  {
    // Task 2: Custom delegate type - takes a string, returns a double
    public delegate double SensorProcessor(string sensorId);

    // Task 11: Multicast delegate type - takes two strings, returns void
    public delegate void AutomationHandler(string device, string action);
        
    // Task 3: Accepts sensor IDs and a SensorProcessor delegate
    public void ProcessSensorData(string[] sensors, SensorProcessor processor)
    {
      foreach (string sensor in sensors)
      {
        Console.WriteLine($"{sensor}: {processor(sensor)}");
      }
    }

    public class TemperatureControl 
    {
      public bool IsComfortable(double temp) 
      {
        return temp >= 68 && temp <= 76;
      }
    }

    private double _currentTemp = 72.0;
    private bool _lightsOn = false;

    public void AdjustHVAC(string device, string action)
    {
      _currentTemp += action == "up" ? 1 : -1;
      Console.WriteLine($"Temperature now: {_currentTemp}");
    }

    public void ControlLights(string device, string action)
    {
      _lightsOn = action == "on";
      Console.WriteLine($"Lights are now {(_lightsOn ? "on" : "off")}");
    }

    // Task 14: Rule properties - a condition to check, actions to run, and their parameters
    public class AutomationRule 
    {
      public Predicate<double> Condition { get; set; }
      public AutomationHandler Actions { get; set; }
      public string Device { get; set; }
      public string Action { get; set; }
    }

    // Task 16: Check the condition, invoke the actions if it is met
    public void ProcessRule(AutomationRule rule, double sensorReading)
    {
      if (rule.Condition(sensorReading))
      {
        rule.Actions(rule.Device, rule.Action);
      }
    }

    public static void Main()
    {
      var home = new HomeAutomation();
      Console.WriteLine("Smart Home Automation Starting...");

      // Task 4: Test sensor processing
      string[] tempSensors = { "TEMP1", "TEMP2" };
      SensorProcessor processor = Sensors.GetTemperature;
      home.ProcessSensorData(tempSensors, processor);

      // Task 5: Func delegate - checks if a reading is between 0 and 100
      Func<double, bool> isValidReading = reading => reading >= 0 && reading <= 100;
      Console.WriteLine(isValidReading(50));
      Console.WriteLine(isValidReading(150));

      // Task 6: Action delegate - prints a sensor ID and reading
      Action<string, double> logReading = (sensorId, value) => Console.WriteLine($"{sensorId}: {value}");
      logReading("TEMP1", 72.5);
      logReading("HUM1", 45.0);

      // Task 7: Predicate delegate - true when a reading is above 90
      Predicate<double> isCritical = reading => reading > 90;
      Console.WriteLine(isCritical(95));
      Console.WriteLine(isCritical(75));

      // Task 8 and 9: Assign an instance method to a Predicate and test it
      TemperatureControl tempControl = new TemperatureControl();
      Predicate<double> comfortPredicate = tempControl.IsComfortable;
      Console.WriteLine($"Is 72 comfortable? {comfortPredicate(72)}");

      // Task 10: Filter an array of temperatures with the predicate
      double[] temperatures = { 65.0, 70.0, 75.0, 80.0 };
      double[] comfortable = Array.FindAll(temperatures, comfortPredicate);
      foreach (double temp in comfortable)
      {
        Console.WriteLine($"Comfortable: {temp}");
      }

      // Task 12: Assign ControlLights to an AutomationHandler
      AutomationHandler eveningMode = home.ControlLights;

      // Task 13: Add AdjustHVAC to the chain and invoke both
      eveningMode += home.AdjustHVAC;
      eveningMode("MAIN", "on");

      // Task 15: Rule that triggers below 68 degrees, using the evening mode chain
      AutomationRule rule = new AutomationRule
      {
        Condition = temp => temp < 68,
        Actions = eveningMode,
        Device = "MAIN",
        Action = "on"
      };

      // Task 16: Trigger the rule with 66 degrees
      home.ProcessRule(rule, 66.0);
    }
  }
}