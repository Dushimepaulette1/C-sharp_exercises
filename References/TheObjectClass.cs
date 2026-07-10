using System;

namespace TheObjectClass
{
  class Program
  {
    static void Main(string[] args)
    {
      Book bk = new Book("Ta-Nehisi Coates", "Between the World and Me");
      Novel nl = new Novel(38);
      Random rand = new Random();
      int i = 9;

      Object[] objects = {bk, nl, rand, i};

      foreach (Object obj in objects)
      {
        Console.WriteLine(obj.GetType());
        Console.WriteLine(obj);
      }

      bool b = true;
      Console.WriteLine(b);
      Console.WriteLine(b.ToString());
    }
  }
}
