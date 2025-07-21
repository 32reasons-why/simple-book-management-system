using Xunit;
using BookManagementSystem.Models;
using BookManagementSystem.Services;
using System.Linq;

namespace BookManagementSystem.Tests
{
    public class LibraryTests
    {
        [Fact]
        public void AddBook_ShouldIncreaseBookCount()
        {
            var library = new Library();
            var book = new Book
            {
                BookID = 1,
                Title = "Test Book",
                Author = "Test Author",
                PublicationYear = 2020,
                IsAvailable = true
            };

            library.AddBook(book);
            var result = library.GetBook(1);

            Assert.NotNull(result);
            Assert.Equal("Test Book", result.Title);
        }

        [Fact]
        public void RemoveBook_ShouldDeleteBookFromList()
        {
            var library = new Library();
            library.AddBook(new Book { BookID = 1, Title = "Test", Author = "Author", PublicationYear = 2000, IsAvailable = true });

            library.RemoveBook(1);
            var result = library.GetBook(1);

            Assert.Null(result);
        }

        [Fact]
        public void UpdateBook_ShouldModifyExistingBook()
        {
            var library = new Library();
            library.AddBook(new Book { BookID = 1, Title = "Old", Author = "Author", PublicationYear = 2000, IsAvailable = true });

            var updated = new Book { BookID = 1, Title = "New Title", Author = "New Author", PublicationYear = 2023, IsAvailable = false };
            library.UpdateBook(1, updated);

            var result = library.GetBook(1);
            Assert.Equal("New Title", result.Title);
            Assert.False(result.IsAvailable);
        }

        [Fact]
        public void GetAvailableBooks_ShouldReturnOnlyAvailableBooks()
        {
            var library = new Library();
            library.AddBook(new Book { BookID = 1, IsAvailable = true });
            library.AddBook(new Book { BookID = 2, IsAvailable = false });

            var availableBooks = library.GetAvailableBooks();

            Assert.Single(availableBooks);
            Assert.True(availableBooks.All(b => b.IsAvailable));
        }

        [Fact]
        public void SearchBooks_ShouldReturnMatchingBooks()
        {
            var library = new Library();
            library.AddBook(new Book { BookID = 1, Title = "C# Programming", Author = "John Doe", PublicationYear = 2021, IsAvailable = true });
            library.AddBook(new Book { BookID = 2, Title = "Python Programming", Author = "Jane Doe", PublicationYear = 2020, IsAvailable = true });

            var results = library.SearchBooks("C#");

            Assert.Single(results);
            Assert.Equal("C# Programming", results.First().Title);
        }
    }
}
