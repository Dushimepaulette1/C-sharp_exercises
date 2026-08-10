# Tasks

- [ ] 1. Create a SensorReading class with nullable Value and LastUpdated properties. This class should:
    - Define a property Value of nullable decimal type for storing measurement values
    - Define a property LastUpdated of nullable DateTime type to track the last update timestamp

- [ ] 2. Implement the Update() method in the SensorReading class that updates both the Value and LastUpdated properties. This method should:
    - Accept a nullable decimal parameter value
    - Set Value to value
    - Set LastUpdated to DateTime.Now if value was provided, null otherwise

- [ ] 3. Test the SensorReading class functionality by creating a reading instance and updating its value. Your test code should:
    - Create a new SensorReading instance
    - Update it with a valid measurement
    - Display the current reading and timestamp
    - Update it with a null value
    - Display the reading and timestamp again

## Reading Validation

- [ ] 4. Create a TemperatureSensor class with a reading property and constant temperature bounds. The class should:
    - Define private const decimal values MinTemp and MaxTemp
    - Define a public SensorReading property Temperature

- [ ] 5. Implement a ValidateReading() method in TemperatureSensor to check if the current temperature is within bounds. The method should:
    - Check if Temperature.Value has a value
    - If it has a value, verify it's between MinTemp and MaxTemp
    - Return appropriate status messages for each case

- [ ] 6. Test the validation logic with different temperature scenarios. Your test code should:
    - Create a TemperatureSensor instance
    - Test with no reading
    - Test with an out-of-range reading
    - Test with a valid reading

## Temperature Schedule

- [ ] 7. Create a Schedule class with nullable temperature targets. The class should include:
    - A nullable decimal DayTarget property
    - A nullable decimal NightTarget property
    - A constant decimal DefaultTarget

- [ ] 8. Implement a GetCurrentTarget() method in Schedule that returns the appropriate target based on time of day. The method should:
    - Accept a boolean parameter, isDaytime indicating if it's daytime
    - Return DayTarget or NightTarget based on isDaytime
    - Use DefaultTarget if the selected target is null

- [ ] 9. Test the schedule functionality with missing and present targets. Your test code should:
    - Create a Schedule instance
    - Test getting the default day target when no target is set
    - Set a day target and test again

## Reading Status

- [ ] 10. Create a ReadingStatus class with two nullable properties:
    - A string property called Message
    - A bool property called IsValid

- [ ] 11. Add a nullable ReadingStatus property called Status to SensorReading. This property should have a private set.

- [ ] 12. Modify the Update method in SensorReading to manage the status:
    - When newValue has a value, create a new ReadingStatus with Message set to "OK" and IsValid set to true.
    - When newValue is null, create a new ReadingStatus with Message set to "No Reading" and IsValid set to false.

- [ ] 13. Implement a GetStatusSummary() method in the SensorReading class. This method should:
    - Return a string formatted as "Status: [Message], Valid: [IsValid]"
    - Use the ?. operator to safely access Status.Message and Status.IsValid
    - Use the ?? operator to provide default values ("Unknown" for Message, false for IsValid)

- [ ] 14. Test nested property access with various null scenarios. Your test code should:
    - Create a reading with null status
    - Print the status summary
    - Create and set a status
    - Print the updated summary
