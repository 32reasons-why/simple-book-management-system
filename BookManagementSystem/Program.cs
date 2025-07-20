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
                Console.WriteLine("3. Remove Book");
                Console.WriteLine("4. Update Book");
                Console.WriteLine("5. Exit");
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
                        Console.Write("Enter Book ID to remove: ");
                        if (int.TryParse(Console.ReadLine(), out int removeId))
                        {
                            library.RemoveBook(removeId);
                        }
                        else
                        {
                            Console.WriteLine("❌ Invalid ID.");
                        }
                        break;

                    case "4":
                        Console.Write("Enter Book ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out int updateId))
                        {
                            var updatedBook = new Book();
                            updatedBook.BookID = updateId; // Keep same ID

                            Console.Write("Enter new Title: ");
                            updatedBook.Title = Console.ReadLine() ?? string.Empty;

                            Console.Write("Enter new Author: ");
                            updatedBook.Author = Console.ReadLine() ?? string.Empty;

                            Console.Write("Enter new Publication Year: ");
                            if (!int.TryParse(Console.ReadLine(), out int pubYear))
                            {
                                Console.WriteLine("❌ Invalid year.");
                                break;
                            }
                            updatedBook.PublicationYear = pubYear;

                            Console.Write("Is the book available? (yes/no): ");
                            string? availableInput = Console.ReadLine();
                            updatedBook.IsAvailable = availableInput?.ToLower() == "yes";

                            library.UpdateBook(updateId, updatedBook);
                        }
                        else
                        {
                            Console.WriteLine("❌ Invalid ID.");
                        }
                        break;

                    case "5":
                        library.SaveBooks();  // Save before exit
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}
