public class Recipe
{
  public int Id { get; set; }
  public string? Name { get; set; }
  public List<string>? Ingredients { get; set; }
  public List<string>? Instructions { get; set; }

  public override string ToString()
  {
    return $"Recipe {Id}: {Name}";
  }

  public void Display()
  {
    Console.WriteLine($"\nRecipe: {Name}");
    Console.WriteLine("Ingredients:");
    if (Ingredients != null)
    {
      foreach (var ingredient in Ingredients)
        Console.WriteLine($"- {ingredient}");
    }
    Console.WriteLine("Instructions:");
    if (Instructions != null)
    {
      int step = 1;
      foreach (var instruction in Instructions)
        Console.WriteLine($"{step++}. {instruction}");
    }
    Console.WriteLine();
  }
}

// Simulates API calls with built-in delays
public static class RecipeAPI
{
  private static readonly Dictionary<int, Recipe> _recipes = new Dictionary<int, Recipe>
  {
    {1, new Recipe { Id = 1, Name = "Spaghetti Carbonara" }},
    {2, new Recipe { Id = 2, Name = "Classic Burger" }},
    {3, new Recipe { Id = 3, Name = "Caesar Salad" }}
  };

  private static readonly Dictionary<int, List<string>> _ingredients = new Dictionary<int, List<string>>
  {
    {1, new List<string> { "Pasta", "Eggs", "Pecorino", "Pancetta" }},
    {2, new List<string> { "Beef", "Buns", "Lettuce", "Tomato" }},
    {3, new List<string> { "Romaine", "Croutons", "Parmesan", "Caesar Dressing" }}
  };

  private static readonly Dictionary<int, List<string>> _instructions = new Dictionary<int, List<string>>
  {
    {1, new List<string> { "Boil pasta", "Cook pancetta", "Mix eggs and cheese", "Combine all" }},
    {2, new List<string> { "Form patty", "Grill burger", "Toast bun", "Assemble burger" }},
    {3, new List<string> { "Chop lettuce", "Make dressing", "Combine ingredients", "Toss salad" }}
  };

  public static async Task<Recipe> GetRecipeAsync(int id, CancellationToken cancellationToken = default)
  {
    await Task.Delay(2000, cancellationToken);
    if (!_recipes.ContainsKey(id))
      throw new KeyNotFoundException($"Recipe {id} not found");
    return _recipes[id];
  }

  public static async Task<List<string>> GetIngredientsAsync(int id, CancellationToken cancellationToken = default)
  {
    await Task.Delay(1500, cancellationToken);
    return _ingredients[id];
  }

  public static async Task<List<string>> GetInstructionsAsync(int id, CancellationToken cancellationToken = default)
  {
    await Task.Delay(1500, cancellationToken);
    return _instructions[id];
  }
}