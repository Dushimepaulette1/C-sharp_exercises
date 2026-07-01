public class Loops
{
    public static void LoopsRun()
    {
        // bool buttonClick = false;
        //
        // do 
        // { 
        //     Console.WriteLine("Alarm Ringing");
        // } while (!buttonClick);
        // //This line shows that this will run after the loop finishes
        // Console.WriteLine("Time for a five minute break.");
        for (int i = 1; i <= 16; i++)
        {
            Console.WriteLine($"Week {i}");
            Console.WriteLine("Announcements: \n \n \n ");
            Console.WriteLine("Report Backs: \n \n \n");
            Console.WriteLine("Discussion Items: \n \n \n");
        }
    }
}