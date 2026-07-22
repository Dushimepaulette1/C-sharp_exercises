using System;
using System.Collections.Generic;
 class Game{
  public bool IsImposter{get; set;}
  public Game(){
    Console.WriteLine("---Starting imposter game----");
  }
  List<string> players = new List<string>();
  public void AddPlayer()
  {
    while (true)
    {
    Console.Write("Enter the names of players: ");
    Console.WriteLine("Type 'done' if you've finished entering number of players");
       string names = Console.ReadLine();
       if (string.Equals(names, "done", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
    if (string.IsNullOrWhiteSpace(names))
            {
                Console.WriteLine("Input cannot be empty. Please try again.");
                continue; 
            }
    
 
    players.Add(names);
    }
  }
  public void Generatewords()
  {
    List<string> words = new List<string>{"pizza", "famous", "lazy", "riddles", "camera", "model", "singer"};
    Random random = new Random();
    int randomIndex = random.Next(0, words.Count);
    string randomWord = words[randomIndex];
  }

  public static void Main(string[] args)
  {
    Game game = new Game();

      game.AddPlayer();

    // game.AddPlayer("Paulette");
  }
}