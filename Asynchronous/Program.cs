using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
  // Task 5: EmptyRecipe returned in case of an error
  private static readonly Recipe EmptyRecipe = new Recipe { Id = 0, Name = "Empty Recipe" };

  // Task 2, 3, 5, 11, 12: Fetch a recipe with error handling and cancellation support
  public static async Task<Recipe> FetchRecipeAsync(int id, CancellationToken cancellationToken = default)
  {
    Console.WriteLine($"Fetching recipe {id}...");

    try
    {
      Recipe recipe = await RecipeAPI.GetRecipeAsync(id, cancellationToken);
      Console.WriteLine($"Successfully fetched recipe {id}");
      return recipe;
    }
    catch (KeyNotFoundException)
    {
      Console.WriteLine($"Error: Recipe {id} not found");
    }
    catch (OperationCanceledException)
    {
      Console.WriteLine($"Recipe {id} fetch was canceled");
    }

    return EmptyRecipe;
  }

  // Task 8, 9, 11, 12: Load both details concurrently with cancellation support
  public static async Task LoadRecipeDetailsAsync(Recipe recipe, CancellationToken cancellationToken = default)
  {
    Console.WriteLine($"Loading details for {recipe}...");

    try
    {
      Task<List<string>> ingredientsTask = RecipeAPI.GetIngredientsAsync(recipe.Id, cancellationToken);
      Task<List<string>> instructionsTask = RecipeAPI.GetInstructionsAsync(recipe.Id, cancellationToken);

      await Task.WhenAll(ingredientsTask, instructionsTask);

      recipe.Ingredients = ingredientsTask.Result;
      recipe.Instructions = instructionsTask.Result;
      Console.WriteLine($"Loaded details for {recipe}");
    }
    catch (OperationCanceledException)
    {
      Console.WriteLine($"Loading details for recipe {recipe.Id} was cancelled");
    }
  }

  public static async Task Main(string[] args)
  {
    Console.WriteLine("Starting Recipe Application...");

    // Task 4: Fetch recipe 1
    Recipe recipe = await FetchRecipeAsync(1);
    Console.WriteLine($"Fetched: {recipe}");

    // Task 6: Test error handling with an invalid ID
    Recipe missing = await FetchRecipeAsync(99);
    Console.WriteLine($"Fetched: {missing}");

    // Task 10: Load details concurrently and display
    await LoadRecipeDetailsAsync(recipe);
    recipe.Display();

    // Task 13: Cancellation source that times out after one second
    CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(1));

    // Task 14: This fetch takes 2 seconds, so the 1 second timeout cancels it
    Recipe canceled = await FetchRecipeAsync(2, cts.Token);
    Console.WriteLine($"Fetched: {canceled}");
  }
}