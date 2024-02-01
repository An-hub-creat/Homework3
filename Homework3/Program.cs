using System;
using System.Collections.Generic;

class Program
{
    static List<Book> bookList = new List<Book>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. Remove a book");
            Console.WriteLine("3. List all books");
            Console.WriteLine("4. Exit");

            int choice = GetUserChoice(1, 4);

            switch (choice)
            {
                case 1:
                    AddBook();
                    break;
                case 2:
                    RemoveBook();
                    break;
                case 3:
                    ListBooks();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }
    }

    static void AddBook()
    {
        Console.WriteLine("Enter book details:");
        Console.Write("Title: ");
        string title = Console.ReadLine();
        Console.Write("Author: ");
        string author = Console.ReadLine();

        Book newBook = new Book(title, author);
        bookList.Add(newBook);

        Console.WriteLine("Book added successfully!");
    }

    static void RemoveBook()
    {
        Console.Write("Enter the title of the book to remove: ");
        string titleToRemove = Console.ReadLine();

        Book bookToRemove = bookList.Find(book => book.Title.Equals(titleToRemove, StringComparison.OrdinalIgnoreCase));

        if (bookToRemove != null)
        {
            bookList.Remove(bookToRemove);
            Console.WriteLine("Book removed successfully!");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    static void ListBooks()
    {
        if (bookList.Count > 0)
        {
            Console.WriteLine("List of Books:");
            foreach (var book in bookList)
            {
                Console.WriteLine($"{book.Title} by {book.Author}");
            }
        }
        else
        {
            Console.WriteLine("No books in the list.");
        }
    }

    static int GetUserChoice(int min, int max)
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < min || choice > max)
        {
            Console.WriteLine($"Please enter a number between {min} and {max}.");
        }
        return choice;
    }
}

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }
}