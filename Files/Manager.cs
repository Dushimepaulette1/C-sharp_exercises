public enum LogLevel
{
  INFO,
  WARN,
  ERROR
}

public class LogEntry
{
  public DateTime Timestamp { get; set; }
  public LogLevel Level { get; set; }
  public string Message { get; set; }

  public override string ToString()
  {
    return $"{Timestamp:yyyyMMdd}_{Timestamp:HHmmss}_{Timestamp.Ticks % 10000} [{Level}] {Message}";
  }

  public static LogEntry Parse(string line)
  {
    string[] parts = line.Split(new[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
    if (parts.Length < 3) throw new FormatException("Invalid log entry format");

    string timestampStr = parts[0].Trim();
    string[] timestampParts = timestampStr.Split('_');
    if (timestampParts.Length < 3) throw new FormatException("Invalid timestamp format");

    string dateTimeStr = $"{timestampParts[0]}_{timestampParts[1]}";
    DateTime timestamp = DateTime.ParseExact(dateTimeStr, "yyyyMMdd_HHmmss", null);

    return new LogEntry
    {
      Timestamp = timestamp,
      Level = Enum.Parse<LogLevel>(parts[1].Trim()),
      Message = parts[2].Trim()
    };
  }
}

public class LogManager
{
  private readonly string baseDirectory;
  public string currentLogPath;
  private long maxLogSize = 10000;

  public LogManager(string directory)
  {
    baseDirectory = directory;
    Directory.CreateDirectory(baseDirectory);
    currentLogPath = Path.Combine(baseDirectory, GenerateLogFilename());
  }

  // Task 2: Unique filename using the current time and clock ticks
  public string GenerateLogFilename()
  {
    return $"log_{DateTime.Now:yyyyMMdd HHmmss}_{DateTime.UtcNow.Ticks % 10000}.txt";
  }

  // Task 3 and 10: Write an entry to the log file, then check rotation
  public void WriteLog(LogLevel level, string message)
  {
    LogEntry entry = new LogEntry
    {
      Timestamp = DateTime.Now,
      Level = level,
      Message = message
    };

    using (FileStream fs = new FileStream(currentLogPath, FileMode.Append))
    using (StreamWriter writer = new StreamWriter(fs))
    {
      writer.WriteLine(entry.ToString());
    }

    Console.WriteLine($"Logged: {entry}");

    RotateLogIfNeeded();
  }

  // Task 5 and 6: Read and parse all entries from a log file
  public List<LogEntry> ReadLogEntries(string logPath)
  {
    List<LogEntry> entries = new List<LogEntry>();

    using (FileStream fs = new FileStream(logPath, FileMode.Open, FileAccess.Read))
    using (StreamReader reader = new StreamReader(fs))
    {
      string line;
      while ((line = reader.ReadLine()) != null)
      {
        if (!string.IsNullOrWhiteSpace(line))
        {
          entries.Add(LogEntry.Parse(line));
        }
      }
    }

    return entries;
  }

  // Task 8: Check whether the file has reached the size limit
  private bool ShouldRotateLog(string logPath, long maxSizeBytes)
  {
    FileInfo logInfo = new FileInfo(logPath);
    return logInfo.Length >= maxSizeBytes;
  }

  // Task 9: Switch to a new log file when the current one is too big
  public void RotateLogIfNeeded()
  {
    if (ShouldRotateLog(currentLogPath, maxLogSize))
    {
      string filename = GenerateLogFilename();
      currentLogPath = Path.Combine(baseDirectory, filename);
      Console.WriteLine($"Rotated to new log file: {currentLogPath}");
    }
  }

  // Task 12: List all log files in the base directory
  public List<FileInfo> ListLogFiles()
  {
    DirectoryInfo dirInfo = new DirectoryInfo(baseDirectory);
    return dirInfo.GetFiles("log_*.txt").ToList();
  }

  // Task 13: Combine multiple log files into one output file
  public void ConsolidateLogs(string[] logPaths, string outputPath)
  {
    string combinedPath = Path.Combine(baseDirectory, outputPath);

    using (FileStream fs = new FileStream(combinedPath, FileMode.Create))
    using (StreamWriter writer = new StreamWriter(fs))
    {
      foreach (string logPath in logPaths)
      {
        List<LogEntry> entries = ReadLogEntries(logPath);
        foreach (LogEntry entry in entries)
        {
          writer.WriteLine(entry.ToString());
        }
      }
    }

    Console.WriteLine($"Consolidated logs into: {combinedPath}");
  }

  public void SetMaxLogSize(long bytes)
  {
    maxLogSize = bytes;
  }
}