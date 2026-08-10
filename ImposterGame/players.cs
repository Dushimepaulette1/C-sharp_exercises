public class Players{
  public string Name{get; set;}
  public bool IsImposter{get; set;}
  public string Word{get; set;}
   public Players(string name, bool isImposter, string word)
   {
    Name = name;
    IsImposter = isImposter;
    Word = word;
   }
   
}