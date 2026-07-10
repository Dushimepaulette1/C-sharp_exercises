using System;
namespace LearnReferences
{
  class Program
  {
    static void Main(string[] args)
    {
      // Novel nov1 =  new Novel(5);
      // Novel nov2 = nov1;
      // nov2.Flip();
      // Console.WriteLine(nov1.CurrentPage);
      // Console.WriteLine(nov2.CurrentPage);
      Encyclopedia enc1 = new Encyclopedia(32, "Encyclopedia Britannica", "Encyclopedia Britannica");
			Encyclopedia enc2 = new Encyclopedia(19, "Codecademy Curriculum Team", "Codecademy Encyclopedia of Coding Knowledge");
			Novel nov1 = new Novel(48, "Jane Austen", "Pride and Prejudice");
			Novel nov2 = new Novel(23, "Charles Dickens", "Dushime Paulette");
      Book[] books = [enc1, enc2, nov1, nov2];
      foreach(Book book in books)
      {
        Console.WriteLine(book.Title);
      }


    }
  }
}