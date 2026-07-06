public class ForestDemo
{
    public static void ForestRun()
    {
        Forest f = new Forest("Congo", "Desert");
        // f.trees = 3;
        f.Grow();
        Console.WriteLine(f.Name);
        Console.WriteLine(f.Biome);
    }
}