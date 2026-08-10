class Program
{
  static void Main()
  {
    // Task 4: Create the manager and write three test logs
    LogManager manager = new LogManager("logs");
    manager.WriteLog(LogLevel.INFO, "Application startup complete");
    manager.WriteLog(LogLevel.WARN, "Low memory detected");
    manager.WriteLog(LogLevel.ERROR, "Database connection failure");

    // Task 7: Read back and print all entries
    List<LogEntry> entries = manager.ReadLogEntries(manager.currentLogPath);
    foreach (LogEntry entry in entries)
    {
      Console.WriteLine(entry);
    }

    // Task 11: Test rotation with a small size limit
    manager.SetMaxLogSize(100);
    for (int i = 1; i <= 10; i++)
    {
      LogLevel level = i % 3 == 0 ? LogLevel.ERROR : i % 2 == 0 ? LogLevel.WARN : LogLevel.INFO;
      manager.WriteLog(level, $"Test message number {i}");
    }

    // Task 14: List all log files with sizes
    List<FileInfo> logPaths = manager.ListLogFiles();
    foreach (FileInfo file in logPaths)
    {
      Console.WriteLine($"{file.Name}: {file.Length} bytes");
    }
    Console.WriteLine($"Total files: {logPaths.Count}");

    // Task 15: Consolidate and verify
    string[] paths = logPaths.Select(f => f.FullName).ToArray();
    manager.ConsolidateLogs(paths, "logs_combined.txt");

    List<FileInfo> updatedFiles = manager.ListLogFiles();
    foreach (FileInfo file in updatedFiles)
    {
      Console.WriteLine($"{file.Name}: {file.Length} bytes");
    }
  }
}