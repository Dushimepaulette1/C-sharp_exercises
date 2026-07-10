using System;
using System.Collections.Generic;

namespace LearnReferences
{
  class Novel : Book, IFlippable
  {
    public int CurrentPage
    { get; set; }

    private List<string> chapterList;

    public Novel(List<string> chapters, int page = 0, string author = "Unknown", string title = "Untitled") : base(author, title)
    {
      CurrentPage = page;
      chapterList = chapters;
    }

    public Novel(int page = 0, string author = "Unknown", string title = "Untitled") : base(author, title)
    {
      CurrentPage = page;
      chapterList = new List<string>();
    }

    public void Flip()
    {
      CurrentPage++;
    }

    public void LogChapters()
    {
      foreach (string chapter in chapterList) 
      {
        Console.WriteLine(chapter);
      }
    }

    public override string Stringify() 
    {
      return "This is a Novel object!";
    }
  }
}