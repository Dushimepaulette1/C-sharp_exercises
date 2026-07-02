public class Forest
{
    public string name;
    public string biome;
    public int trees;
    public int age;

    public int Grow()
    {
        trees += 30;
        age++;
        return trees;
    }

    public int Burn()
    {
        trees -= 20;
        age++;
        return trees;
    }
}