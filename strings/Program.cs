using System;
using System.Collections.Generic;

namespace LibraryManagementSystem{
  class Program {
    Cyber Library Management System

// You are tasked with creating a library management system to manage books in your local library. 
// You’ll be managing a collection of books where each book has a title and an author. 
// Users should be able to add new books, search for books by title, and view all available books. 
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