using System.Collections.Generic;
using System.Linq;
public class Library
{
  private List<Book> books = new List<Book>();
  public void Addbook(Book book)
  {
    books.Add(book);
    Console.WriteLine("Book added successfully");
  }
  public void SearchBooksByTitle(string title)
  {
    List<Book> titleBooks = books.Where(book => book.Title == title).ToList();
  //  Console.WriteLine(titleBooks);
   foreach(Book b in titleBooks)
   {
    Console.WriteLine(b.Title);
   }
  }
  public void DisplayAllBooks()
  {
    foreach(Book book in books)
    {
      Console.WriteLine(book.Title);
      Console.WriteLine(book.Author);
    }
  }

}