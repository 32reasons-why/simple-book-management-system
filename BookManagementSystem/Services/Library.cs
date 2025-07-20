using BookManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;


namespace BookManagementSystem.Services
{
    internal class Library
    {
        private List<Book> books = new();
        private readonly string dataFilePath = "Data/BookStorage.json";

        public Library()
        {
            LoadBooks();
        }
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

        public void SaveBooks()
        {
            Directory.CreateDirectory("Data"); // Ensure folder exists
            var json = JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(dataFilePath, json);
        }

        public void LoadBooks()
        {
            if (File.Exists(dataFilePath))
            {
                string json = File.ReadAllText(dataFilePath);
                books = JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
            }
        }

        public List<Book> GetAvailableBooks() => books.Where(b => b.IsAvailable).ToList();
    }
}
