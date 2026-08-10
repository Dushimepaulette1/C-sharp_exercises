# Support Ticket Processor

Create a ticket processing system that demonstrates different iterator patterns. You'll work with a ticket tracking class and queue infrastructure to implement several iterator methods, each showing different ways to use the yield keyword and process data.

# Tasks

## System Setup and Review

- [ ] 1. Review the SupportTicket class implementation in main.cs. This class represents individual support tickets and will be the core data structure we iterate over. Pay special attention to the following properties:
    - The Id property of type int uniquely identifies each ticket.
    - The CustomerName property of type string holds the customer's name.
    - The Severity property of type int ranges from 1-5, where 1 is the highest priority.
    - The CreatedTime property of type DateTime tracks when the ticket was created.
    - The ToString() override that will help us display tickets.

    You'll use these properties in your iterator implementations.

- [ ] 2. Examine the TicketQueue class in main.cs. This class manages our collection of tickets and is where you will implement different iterator behaviors. Focus on understanding:
    - The private tickets field of type List<SupportTicket> that stores all tickets.
    - The GetInitialTickets() method that creates test data with varying:
        - Severity levels (1 through 5)
        - Creation times (from 4 hours ago to 30 minutes ago)
        - Customer names and IDs

    This test data is designed to help verify your iterators by including:
    - Multiple tickets with the same severity for priority grouping.
    - Tickets created at different times for time-based filtering.
    - A mix of high and low-priority tickets for testing sort order.

- [ ] 3. In Main.cs, add code to verify the initial setup:
    - Create a new instance of TicketQueue.
    - Loop through and display each ticket.

    The output should show all five initial tickets with their IDs, customer names, and severity levels.

## Time-Based Iterator

- [ ] 4. Create a method called GetRecentTickets() that filters tickets based on how recently they were created. The method should accept an integer parameter, threshold representing hours, and return an enumerable collection of tickets.

    Inside the method, calculate a cutoff time by subtracting the hours from the current time:
    - Define a variable cutoff of type DateTime.
    - Subtract threshold from the current time using DateTime.Now.AddHours().

    You can look at the GetInitialTickets() method to see an implementation of DateTime.Now.AddHours().

- [ ] 5. Add filtering logic to the GetRecentTickets method by looping through each ticket in the tickets list. For each ticket:
    - Check if its creation time is after the cutoff time.
    - If it is, return the ticket as part of the sequence using yield.
    - If not, continue to the next ticket.

    This approach lets us filter tickets without storing them in a separate list.

- [ ] 6. Add code to test the time-based filtering, looping through tickets using GetRecentTickets().

    Run your program and verify that only recently created tickets appear in the output. Try different TimeSpan values to see how it affects which tickets are returned.

## Priority-Based Iterator

- [ ] 7. Create a method called GetHighPriorityTicketsFirst() that processes tickets from highest to lowest priority. The method should return an enumerable collection of tickets and have no parameters.

    Start the method body with an outer loop that:
    - Starts with severity level 1 (highest priority).
    - Goes through each severity level through 5.

    This loop will ensure tickets are processed in priority order.

- [ ] 8. Complete the GetHighPriorityTicketsFirst() method by creating an inner loop.

    For each severity level (1 through 5):
    - Loop through all tickets.
    - If a ticket's severity matches the current level, return it using yield.

    This creates a sequence where all severity 1 tickets come first before moving through each level.

- [ ] 9. Add code to verify the priority-based ordering by looping through tickets with GetHighPriorityTicketsFirst() and display each ticket.

    Verify that the tickets appear in order of severity (1 through 5).

## Infinite Iterator

- [ ] 10. Create a method called GetEndlessTicketProcessor() that continuously processes tickets. The method should return an enumerable collection of tickets and have no parameters.

    Set up an infinite loop by ensuring there is no ending condition. Do not call the method yet since an empty infinite loop will freeze the project.

    Note: If you do run into an infinite loop, refresh the browser.

- [ ] 11. Add the ticket processing logic to GetEndlessTicketProcessor(). Inside the endless loop:
    - Get tickets by looping through them in priority order.
    - Return each ticket using yield.

    This creates a continuous stream of tickets in priority order. Still, be careful not to call the method since, once the priority loop is done, the infinite loop will continue without yield and cause issues.

- [ ] 12. After processing all tickets in a cycle, add a marker to show when the processing cycle completes.

    Within the infinite loop but after the priority loop:
    - yield a special ticket with the following property values:
        - Id = -1
        - CustomerName = "=== Cycle Complete ==="
        - Severity = 0
        - CreatedTime = DateTime.Now
    - Use break to stop the infinite loop.

    This marker helps track when all tickets have been processed and makes the output more readable.

- [ ] 13. Add code to test the endless ticket processor. Loop through tickets using GetEndlessTicketProcessor() and display each one.
