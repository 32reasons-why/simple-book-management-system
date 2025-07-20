using BookManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Services
{
    internal class Library
    {
        private List<Book> books = new();

        public void AddBook(Book book)
        {
            if (!books.Any(b => b.BookID == book.BookID))
            {
                books.Add(book);
            }
        }
    }
}
