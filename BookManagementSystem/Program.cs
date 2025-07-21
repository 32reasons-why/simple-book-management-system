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
                int option = GetMenuOption();

                switch (option)
                {
                    case 1:
                        Book newBook = addABookProcess(library);
                        library.AddBook(newBook);
                        break;

                    case 2:
                        removeABookProcess(library);
                        break;

                    case 3:
                        updateABookProcess(library);
                        break;

                    case 4:
                        searchForABookProcess(library);
                        break;

                    case 5:
                        listAvailableBooksProcess(library);
                        break;

                    case 6:
                        library.SaveBooks();
                        running = false;
                        break;

                }
            }
        }
        static int GetMenuOption()
        {
            int option;
            while (true)
            {
                Console.WriteLine("\nHi :), Welcome to the Book Management System." +
                    "\nPlease select one of the options below to get started with managing the books and please select option 6 if you wish to exit the app." +
                    "\n1. Add a new Book" +
                    "\n2. Remove a Book by ID" +
                    "\n3. Update Book information (Title, Author, Publication Year and Availability)" +
                    "\n4. Search for a Book by the following keys/keywords: ID, Title, Author, Publication Year and Availability" +
                    "\n5. List All the available Books" +
                    "\n6. Exit");
                Console.Write("Enter option: ");

                var input = Console.ReadLine();

                if (int.TryParse(input, out option) && option >= 1 && option <= 6)
                {
                    return option;
                }
                Console.WriteLine("=======================================================================================");
                Console.WriteLine("\nInvalid input/option :(. Please enter a number between 1 and 6.");
            }
        }

        static Book addABookProcess(Library library)
        {
            Book newBook = new();

            while (true)
            {
                Console.Write("Enter the Book ID: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    newBook.BookID = id;
                    break;
                }
                Console.WriteLine("=======================================================================================");
                Console.WriteLine("Invalid ID:(. Book ID must be an Integer.");
            }

            while (true)
            {
                Console.Write("Enter the Title: ");
                string? title = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(title))
                {
                    newBook.Title = title;
                    break;
                }
                Console.WriteLine("=======================================================================================");
                Console.WriteLine("Title cannot be empty :(.");
            }

            while (true)
            {
                Console.Write("Enter the Author's Name: ");
                string? author = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(author)
                    && author.All(c => char.IsLetter(c) || char.IsWhiteSpace(c))
                    && author.Replace(" ", "").Length >= 3)
                {
                    newBook.Author = author;
                    break;
                }
                Console.WriteLine("=======================================================================================");
                Console.WriteLine("Author's name must contain only letters and spaces, and be at least 3 letters long :(.");
            }

            int currentYear = DateTime.Now.Year;
            while (true)
            {
                Console.Write("Enter Publication Year: ");
                if (int.TryParse(Console.ReadLine(), out int year)
                    && year >= 1000 && year <= currentYear)
                {
                    newBook.PublicationYear = year;
                    break;
                }
                Console.WriteLine("=======================================================================================");
                Console.WriteLine($"Publication Year must be a 4-digit number between Year 1000 and {currentYear} :(.");
            }

            newBook.IsAvailable = true;
            library.SaveBooks();

            return newBook;
        }

        static void removeABookProcess(Library library)
        {
            int bookID;
            while (true)
            {
                Console.Write("Enter a Book ID to remove: ");
                if (int.TryParse(Console.ReadLine(), out bookID))
                {
                    break;
                }
                Console.WriteLine("=======================================================================================");
                Console.WriteLine("Invalid ID. Please enter a valid integer :(.");
            }

            library.RemoveBook(bookID);
        }

        static void updateABookProcess(Library library)
        {
            int updateId;

            while (true)
            {
                Console.Write("Enter Book ID to update: ");
                if (int.TryParse(Console.ReadLine(), out updateId))
                {
                    break;
                }
                Console.WriteLine("=======================================================================================");
                Console.WriteLine("Invalid ID. Please enter a valid integer :(.");
            }

            var updatedBook = new Book { BookID = updateId };

            while (true)
            {
                Console.Write("Enter new Title: ");
                string? title = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(title))
                {
                    updatedBook.Title = title;
                    break;
                }
                Console.WriteLine("=======================================================================================");
                Console.WriteLine("Title cannot be empty :(.");
            }

            while (true)
            {
                Console.Write("Enter new Author: ");
                string? author = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(author)
                    && author.All(c => char.IsLetter(c) || char.IsWhiteSpace(c))
                    && author.Replace(" ", "").Length >= 3)
                {
                    updatedBook.Author = author;
                    break;
                }
                Console.WriteLine("=======================================================================================");
                Console.WriteLine("Author name must contain only letters and spaces, and be at least 3 letters long :(.");
            }

            int currentYear = DateTime.Now.Year;
            while (true)
            {
                Console.Write("Enter new Publication Year: ");
                if (int.TryParse(Console.ReadLine(), out int pubYear)
                    && pubYear >= 1000 && pubYear <= currentYear)
                {
                    updatedBook.PublicationYear = pubYear;
                    break;
                }
                Console.WriteLine("=======================================================================================");
                Console.WriteLine($"Publication Year must be a 4-digit number between 1000 and {currentYear} :(.");
            }

            while (true)
            {
                Console.Write("Is the book available? (yes/no): ");
                string? availableInput = Console.ReadLine()?.Trim().ToLower();
                if (availableInput == "yes")
                {
                    updatedBook.IsAvailable = true;
                    break;
                }
                else if (availableInput == "no")
                {
                    updatedBook.IsAvailable = false;
                    break;
                }
                else
                {
                    Console.WriteLine("=======================================================================================");
                    Console.WriteLine("Please enter 'yes' or 'no' :(.");
                }
            }

            library.UpdateBook(updateId, updatedBook);
        }

        static void searchForABookProcess(Library library)
        {
            Console.Write("Enter a Key/keyword to search (ID, title, author, or year): ");
            string keyword = Console.ReadLine() ?? string.Empty;

            var results = library.SearchBooks(keyword);
            if (results.Any())
            {
                Console.WriteLine("\nBooks Matching the key/keyword:");
                foreach (var book in results)
                {
                    Console.WriteLine($"ID: {book.BookID}, Title: {book.Title}, Author: {book.Author}, Year: {book.PublicationYear}, Available: {book.IsAvailable}");
                }
            }
            else
            {
                Console.WriteLine("No books found matching the keyword.");
            }
        }

        static void listAvailableBooksProcess(Library library)
        {
            var availableBooks = library.GetAvailableBooks();
            Console.WriteLine("Available Books:");
            foreach (var book in availableBooks)
            {
                Console.WriteLine($"ID: {book.BookID}, Title: {book.Title}, Author: {book.Author}");
            }
        }

    }
}
