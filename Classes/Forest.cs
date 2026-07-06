public class Forest
{
    public string name;
    public string biome;
    private int trees;
    private int age;
public int Age
    {
      get {return age;}
//This means that we can't set the age outside the class but when we don't write it at all meaning 
// "omitting the set" then we can't change it also in the class
      private set {age = value;}
    }

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