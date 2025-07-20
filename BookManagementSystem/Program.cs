using BookManagementSystem.Models;
using BookManagementSystem.Services;
using System;

namespace BookManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new();

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nLibrary Menu");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. List Available Books");
                Console.WriteLine("3. Exit");
                Console.Write("Enter option: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Book newBook = new();
                        Console.Write("Enter Book ID: ");
                        newBook.BookID = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter Title: ");
                        newBook.Title = Console.ReadLine()!;
                        Console.Write("Enter Author: ");
                        newBook.Author = Console.ReadLine()!;
                        Console.Write("Enter Publication Year: ");
                        newBook.PublicationYear = int.Parse(Console.ReadLine()!);
                        newBook.IsAvailable = true;

                        library.AddBook(newBook);
                        break;

                    case "2":
                        var availableBooks = library.GetAvailableBooks();
                        Console.WriteLine("Available Books:");
                        foreach (var book in availableBooks)
                        {
                            Console.WriteLine($"ID: {book.BookID}, Title: {book.Title}, Author: {book.Author}");
                        }
                        break;

                    case "3":
                        library.SaveBooks();  // Save before exit
                        running = false;
                        break;
                }
            }
        }
    }
}
