public class ForestDemo
{
    public static void ForestRun()
    {
        Forest f = new Forest();

        f.name = "Cactus";
        f.biome = "Desert";
        f.trees = 3;
        f.age = 23;

        Console.WriteLine(f.name);
    }
}