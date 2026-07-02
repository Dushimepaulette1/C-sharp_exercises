public class ForestDemo
{
    public static void ForestRun()
    {
        Forest f = new Forest("Congo", "Tropical");
        f.trees = 3;

        Console.WriteLine(f.name);
        Console.WriteLine(f.biome);
    }
}