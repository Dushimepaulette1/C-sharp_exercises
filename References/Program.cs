using System;
namespace LearnReferences
{
  class Program
  {
    static void Main(string[] args)
    {
      Novel nov1 =  new Novel(5);
      Novel nov2 = nov1;
      nov2.Flip();
      Console.WriteLine(nov1.CurrentPage);
      Console.WriteLine(nov2.CurrentPage);
    }
  }
}