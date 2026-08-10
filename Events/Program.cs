using System;

public enum Priority 
{ 
  Low,
  Medium,
  High,
  Urgent
}

// Task 8 and 9: Custom event arguments for passing notification data
public class NotificationEventArgs : EventArgs
{
  public string Department { get; set; }
  public string Message { get; set; }
  public Priority Priority { get; set; }

  public NotificationEventArgs(string department, string message, Priority priority)
  {
    Department = department;
    Message = message;
    Priority = priority;
  }
}

// Task 15: Interface that declares the detailed notification event
public interface INotificationPublisher
{
  event EventHandler<NotificationEventArgs> DetailedNotification;
}

public class NotificationSystem
{
  // Task 4: Standard event
  public event EventHandler Notification;

  // Task 10: Event that carries NotificationEventArgs
  public event EventHandler<NotificationEventArgs> DetailedNotification;

  // Task 5: Raises the Notification event with null checking
  protected virtual void OnNotification()
  {
    Notification?.Invoke(this, EventArgs.Empty);
  }

  public void SendNotification(string message)
  {
    Console.WriteLine($"Attempting to send: {message}");
    OnNotification();
  }

  // Task 11: Creates the event args and raises DetailedNotification
  protected virtual void OnDetailedNotification(string dept, string msg, Priority priority)
  {
    DetailedNotification?.Invoke(this, new NotificationEventArgs(dept, msg, priority));
  }

  // Task 12: Public method to send a detailed notification
  public void SendDetailedNotification(string dept, string msg, Priority priority)
  {
    Console.WriteLine($"Attempting to send detailed notification to {dept}");
    OnDetailedNotification(dept, msg, priority);
  }
}

// Task 16: Publisher that implements the interface and always sends Urgent
public class UrgentNotificationSystem : INotificationPublisher
{
  public event EventHandler<NotificationEventArgs> DetailedNotification;

  protected virtual void OnUrgentNotification(string department, string message)
  {
    DetailedNotification?.Invoke(this, new NotificationEventArgs(department, message, Priority.Urgent));
  }

  public void SendUrgentNotification(string department, string message)
  {
    Console.WriteLine($"Sending urgent notification to {department}");
    OnUrgentNotification(department, message);
  }
}

public class EmailSubscriber
{
  // Task 6: Handler for the basic event
  public void HandleBasicNotification(object sender, EventArgs e)
  {
    Console.WriteLine("Email: Notification received");
  }

  // Task 13: Handler that prints the full notification details
  public void HandleDetailedNotification(object sender, NotificationEventArgs e)
  {
    Console.WriteLine($"Email: [{e.Priority}] {e.Department} - {e.Message}");
  }
}

class Program
{
  static void Main()
  {
    Console.WriteLine("Corporate Notification System");

    // Task 2: Create the notifier and send a test message
    NotificationSystem notifier = new NotificationSystem();
    notifier.SendNotification("System startup complete");

    // Task 3: Create the subscriber
    EmailSubscriber subscriber = new EmailSubscriber();

    // Task 7: Subscribe the handler to the event and test
    notifier.Notification += subscriber.HandleBasicNotification;
    notifier.SendNotification("Testing event subscription");

    // Task 14: Subscribe the detailed handler and send a detailed notification
    notifier.DetailedNotification += subscriber.HandleDetailedNotification;
    notifier.SendDetailedNotification("IT", "Scheduled system update", Priority.Low);

    // Task 17: Test the urgent notification system
    UrgentNotificationSystem urgentSystem = new UrgentNotificationSystem();
    urgentSystem.DetailedNotification += subscriber.HandleDetailedNotification;
    urgentSystem.SendUrgentNotification("Security", "Security alert detected");
  }
}