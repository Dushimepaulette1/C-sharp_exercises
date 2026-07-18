Log File Processor

You have inherited a basic log processing system that works with well-formatted logs but crashes when it encounters any issues. Your task is to make the system more robust by adding proper error handling and validation.

# Tasks

## Protection Against Null Lists

- [x] 1. Look at the following line of code in the Main() method:

    LogProcessor nullProcessor = new LogProcessor(null);

    This code initializes the LogProcessor class using null.

    Look at the LogProcessor() constructor and observe the code:

    public LogProcessor(List<string> logEntries)
    {
      this.logEntries = logEntries ?? throw new ArgumentNullException(nameof(logEntries));
    }

    This code makes sure the LogProcessor throws an error if it is initialized with null.

    Run the code to confirm.

    > Implemented: `Program.cs:17`

- [x] 2. Handle the exception in Main() by surrounding the LogProcessor initialization in a try-catch structure.

    Try to catch the specific exception thrown in the LogProcessor constructor, but a general exception will work as well.

    You can output any message or use the following example message, being sure to name the exception parameter ex: $"Null list error: {ex.Message}"

    > Implemented: `Program.cs:85-92`

- [ ] 3. Verify the null protection by running the code again.

    The program should now output the exception message.

    > Verify by running: `dotnet run`

## Log Processing Protection

- [ ] 4. Now observe the error output from the code using the malformedLogs list.

    > Verify by running: `dotnet run`

- [x] 5. To handle errors while calling ProcessLogs(), implement a basic try-catch structure within ProcessLogs() with ProcessLogEntry() in the try block.

    Catch all exceptions and output the error message, "Error processing entry: " followed by the exception message.

    > Implemented: `Program.cs:44-47`

- [x] 6. At the top of ProcessLogs(), add a counter called processedCount and initialize it to 0. This counter will track successfully processed entries so increment it only after each successful processing.

    > Implemented: `Program.cs:22` (init), `Program.cs:34` (increment)

- [x] 7. Implement a finally block to report processing statistics. The output should be "Processed X out of Y entries" using the processedCount and totalCount variables.

    > Implemented: `Program.cs:50-53`

- [ ] 8. Run the code again to test with the malformedLogs list and verify the statistics are reported correctly. The output should show both individual errors and final statistics.

    > Verify by running: `dotnet run`

## Entry Format Validation

- [x] 9. Create an InvalidLogFormatException class that extends Exception. It should contain a constructor that calls the base class constructor and accepts a message parameter.

    > Implemented: `Program.cs:4-9`

- [x] 10. Inside ProcessLogEntry, add validation to check for null or empty string entries. Create an if statement that tests for entry being either null or empty. Inside the if, throw an InvalidLogFormatException with the message "Empty or null log entry".

    > Implemented: `Program.cs:58-61`

- [x] 11. The parts variable inside ProcessLogEntry() contains the data needed to verify the log titles. Add validation using an if statement to ensure parts has three elements. Throw an InvalidLogFormatException with the message "Invalid format. Expected: timestamp|level|message".

    > Implemented: `Program.cs:65-68`

- [x] 12. We also want to make sure the log level is valid. Add validation with an if to ensure the level is "ERROR", "WARN", or "INFO". Throw an exception with the message "Invalid log level: {level}. Expected: ERROR, WARN, or INFO".

    > Implemented: `Program.cs:72-75`

- [ ] 13. The error messaging has now become more specific and should be represented in the output.

    Test the validation by running the program with various invalid formats and verify appropriate exceptions are thrown.

    > Verify by running: `dotnet run`

## Advanced Exception Handling

- [x] 14. You can now test for the InvalidLogFormatException in the ProcessLogs() method. Add a specific catch block for InvalidLogFormatException. This should output a different message than general exceptions.

    > Implemented: `Program.cs:40-43`

- [x] 15. Get more specific in your exception handling by implementing an exception filter for entries with separators. Create another catch block for the InvalidLogFormatException that uses when and tests if entry contains the appropriate separator, |.

    > Implemented: `Program.cs:36-39`

- [ ] 16. You should now have specific and consistent error reporting in your log application. Test complete error handling with all test cases to verify appropriate messages for each type of error.

    > Verify by running: `dotnet run`
