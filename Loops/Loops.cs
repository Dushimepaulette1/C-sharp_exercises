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
        // for (int i = 1; i <= 16; i++)
        // {
        //     Console.WriteLine($"Week {i}");
        //     Console.WriteLine("Announcements: \n \n \n ");
        //     Console.WriteLine("Report Backs: \n \n \n");
        //     Console.WriteLine("Discussion Items: \n \n \n");
        // }
        string[] todo = {"respond to email", "make wireframe", "program feature", "fix bugs"};
        foreach(string task in todo)
        {
            Console.WriteLine($"[] {task}"); 
        }
        
        // while loops are good when you know your stopping condition, but not how many times the loop will need to run.
        // do...while loops are only necessary if you definitely want something to run once, but then stop if a condition is met.
        // for loops are best if you want something to run a specific number of times, rather than given a certain condition.
        // foreach loops are the best way to loop over an array, or any other collection.
        
        //JUMP STATEMENTS
        bool buttonClick = false;
        int time = 0;
        do
        {
            Console.WriteLine("BLARRRRR");
            time++;
            if(time == 3){
                break;
            }
        } while(!buttonClick);
    }
}