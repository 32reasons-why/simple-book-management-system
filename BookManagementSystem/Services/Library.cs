using BookManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
using BookManagementSystem.Helpers;

namespace BookManagementSystem.Services
{
    /// <summary>
    /// Manages the collection of books in the library, including CRUD operations and persistence.
    /// </summary>
    public class Library
    {
        private List<Book> books = new();

        /// <summary>
        /// Path to the file used for Storing the Books (BookStorage.JSON).
        /// </summary>
        private readonly string dataFilePath = Constants.DataFilePath;

        public Library()
        {
            LoadBooks();
        }

        /// <summary>
        /// Adds a new book to the library collection if the BookID does not already exist in Storage.
        /// </summary>
        /// <param name="book">The book to add.</param>
        public void AddBook(Book book)
        {
            if (!books.Any(b => b.BookID == book.BookID))
            {
                books.Add(book);
                Console.WriteLine("Book added.");
            }
            else
            {
                Console.WriteLine("Book ID already exists.");
            }
        }

        /// <summary>
        /// Saves the current list of books into BookStorage.JSON.
        /// </summary>
        public void SaveBooks()
        {
            Directory.CreateDirectory(Constants.DataFolder);
            var json = JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(dataFilePath, json);
        }

        /// <summary>
        /// Loads books from BookStorage.JSON into the library collection.
        /// </summary>
        public void LoadBooks()
        {
            try
            {
                if (File.Exists(dataFilePath))
                {
                    string json = File.ReadAllText(dataFilePath);
                    books = JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load books: {ex.Message}");
                books = new List<Book>();
            }
        }

        /// <summary>
        /// Removes a book from the collection based on the provided BookID.
        /// </summary>
        /// <param name="bookID">The ID of the book to remove.</param>
        public void RemoveBook(int bookID)
        {
            var bookToRemove = books.FirstOrDefault(b => b.BookID == bookID);
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
                Console.WriteLine("Book removed successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        /// <summary>
        /// Updates the details of a book identified by its BookID.
        /// </summary>
        /// <param name="bookID">The ID of the book to update.</param>
        /// <param name="updatedBook">A book object containing the updated details.</param>
        public void UpdateBook(int bookID, Book updatedBook)
        {
            var existingBook = books.FirstOrDefault(b => b.BookID == bookID);
            if (existingBook != null)
            {
                existingBook.Title = updatedBook.Title;
                existingBook.Author = updatedBook.Author;
                existingBook.PublicationYear = updatedBook.PublicationYear;
                existingBook.IsAvailable = updatedBook.IsAvailable;

                Console.WriteLine("Book updated successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        /// <summary>
        /// Searches for books containing the given keyword in their title, author, ID, or publication year.
        /// </summary>
        /// <param name="keyword">The keyword to search for.</param>
        /// <returns>A list of matching books.</returns>
        public List<Book> SearchBooks(string keyword)
        {
            return books
                .Where(b =>
                    b.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    b.Author.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    b.PublicationYear.ToString().Contains(keyword) ||
                    b.BookID.ToString().Contains(keyword)
                )
                .ToList();
        }

        /// <summary>
        /// Retrieves a book by its BookID.
        /// </summary>
        /// <param name="bookID">The ID of the book to retrieve.</param>
        /// <returns>The matching book, or null if not found.</returns>
        public Book? GetBook(int bookID)
        {
            return books.FirstOrDefault(b => b.BookID == bookID);
        }

        /// <summary>
        /// Gets a list of books that are currently available.
        /// </summary>
        /// <returns>A list of available books.</returns>
        public List<Book> GetAvailableBooks() => books.Where(b => b.IsAvailable).ToList();
    }
}
