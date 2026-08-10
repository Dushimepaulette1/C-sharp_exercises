using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProgrammingLanguages
{
  class Program
  {
    static void Main()
    {
      List<Language> languages = File.ReadAllLines("./languages.tsv")
        .Skip(1)
        .Select(line => Language.FromTsv(line))
        .ToList();

      PrettyPrintAll(languages);

      var summaries = languages.Select(l => $"{l.Year}: {l.Name} by {l.ChiefDeveloper}");
      PrintAll(summaries);

      var csharp = languages.Where(l => l.Name == "C#");
      PrettyPrintAll(csharp);

      var microsoftLanguages = languages.Where(l => l.ChiefDeveloper.Contains("Microsoft"));
      PrettyPrintAll(microsoftLanguages);

      var lispDescendants = languages.Where(l => l.Predecessors.Contains("Lisp"));
      PrettyPrintAll(lispDescendants);

      var scriptNames = languages
        .Where(l => l.Name.Contains("Script"))
        .Select(l => l.Name);
      PrintAll(scriptNames);

      int totalCount = languages.Count();
      Console.WriteLine($"Total languages: {totalCount}");

      var millenniumLanguages = languages.Where(l => l.Year >= 1995 && l.Year <= 2005);
      int millenniumCount = millenniumLanguages.Count();
      Console.WriteLine($"Languages launched between 1995 and 2005: {millenniumCount}");

      var millenniumStrings = millenniumLanguages.Select(l => $"{l.Name} was invented in {l.Year}");
      PrintAll(millenniumStrings);
    }

    static void PrettyPrintAll(IEnumerable<Language> languages)
    {
      foreach (Language language in languages)
      {
        Console.WriteLine(language.Prettify());
      }
    }

    static void PrintAll(IEnumerable<Object> items)
    {
      foreach (Object item in items)
      {
        Console.WriteLine(item);
      }
    }
  }
}