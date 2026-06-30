public class Strings
{
    public static void StringsRun()
    {
        // Create a string variable named firstSentence and save the following string to it:
        
        // "It is a truth universally acknowledged, that a single man in possession of a good fortune must be in want of a wife".
        //     Create a second string variable named firstSpeech and save the following string to it:
        // "My dear Mr. Bennet," said his lady to him one day, "have you heard that Netherfield Park is let at last?"
        //     Make sure to use escape characters when necessary.
        //     Using Console.WriteLine(), print each variable to the console. In between them, print a new line to the console.
        // First string variable
        string firstSentence = "It is a truth universally acknowledged, that a single man in possession of a good fortune must be in want of a wife.";

        // Second string variable
        string firstSpeech = "\"My dear Mr. Bennet,\" said his lady to him one day, \"have you heard that Netherfield Park is let at last?\"";


        // Print variable and newline
        // Console.WriteLine(firstSentence);
        // Console.WriteLine();
        // Console.WriteLine(firstSpeech);
        
        // Declare the variables
        string beginning = "The guy next door ";
        string middle = "wanted to give me some food ";
        string end = "and i went to take the food on his poarch.";

        // Concatenate the string and the variables
        string story = beginning + middle + end;

        // Print the story to the console 
        Console.WriteLine(story);

    }
}