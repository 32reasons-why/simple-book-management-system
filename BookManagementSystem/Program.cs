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

            while (true)
            {
                Console.WriteLine("\nLibrary Menu");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Exit");
                Console.Write("Enter option: ");
                var input = Console.ReadLine();

                if (input == "1")
                {
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
                    Console.WriteLine("Book added successfully!");
                }
                else if (input == "2")
                {
                    break;
                }
            }
        }
    }
}
