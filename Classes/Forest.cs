public class Forest
{
    public string name;
    public string biome;
    private int trees;
    private int age;

 public string Name
    {
      get { return name; }
      set { name = value;}
    }
     public string Biome
    {
      get { return biome; }
      set 
      {
        if(value != "Tropical" && value != "Temperate" && value != "Boreal")
        {
          biome = "Unknown";
        }
        else
        {
          biome = value;
        }
}
}
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