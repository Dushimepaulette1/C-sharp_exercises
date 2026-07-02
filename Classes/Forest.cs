public class Forest
{
    public string name;
    public string biome;
    public int trees;
    public int age;

    public int Grow()
    {
        this.trees += 30;
        this.age++;
        return this.trees;
    }

    public int Burn()
    {
        this.trees -= 20;
        this.age++;
        return this.trees;
    }
 public Forest(string name, string biome)
    {
      this.name = name;
      this.biome = biome;
      this.age = 1;
    }
}