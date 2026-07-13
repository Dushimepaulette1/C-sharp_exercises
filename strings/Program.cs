using System;
using System.Collections.Generic;

namespace LibraryManagementSystem{
  class Program {
    static void Main() {
      // Initialize library
      Library library = new Library();

      // Add some sample books
      Book book1 = new Book("1984", "George Orwell");
      Book book2 = new Book("To Kill a Mockingbird", "Harper Lee");

      library.Addbook(book1);
      library.Addbook(book2);
  
      // Search for a book
      
      library.SearchBooksByTitle("1984");
      // // Display all books
      library.DisplayAllBooks();
    }
  }
}