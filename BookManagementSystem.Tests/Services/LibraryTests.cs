using Xunit;
using BookManagementSystem.Models;
using BookManagementSystem.Services;
using System.Linq;

namespace BookManagementSystem.Tests.Services
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
                Title = "PWC Newest Author Test",
                Author = "Sunnyboy Test",
                PublicationYear = 2025,
                IsAvailable = true
            };

            library.AddBook(book);
            var result = library.GetBook(1);

            Assert.NotNull(result);
            Assert.Equal("PWC Newest Author Test", result.Title);
        }

        [Fact]
        public void RemoveBook_ShouldDeleteBookFromList()
        {
            var library = new Library();
            library.AddBook(new Book { BookID = 1, Title = "Testing", Author = "Mr Author", PublicationYear = 2024, IsAvailable = true });

            library.RemoveBook(1);
            var result = library.GetBook(1);

            Assert.Null(result);
        }

        [Fact]
        public void UpdateBook_ShouldModifyExistingBook()
        {
            var library = new Library();
            library.AddBook(new Book { BookID = 1, Title = "Testing Title", Author = "Mr Testing Author", PublicationYear = 2023, IsAvailable = true });

            var updated = new Book { BookID = 1, Title = "Testing Updated title", Author = "Mr Testing Updated Author", PublicationYear = 2022, IsAvailable = false };
            library.UpdateBook(1, updated);

            var result = library.GetBook(1);
            Assert.Equal("Testing Updated title", result.Title);
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
            library.AddBook(new Book { BookID = 1, Title = "Search Test", Author = "Dr Search", PublicationYear = 2022, IsAvailable = true });
            library.AddBook(new Book { BookID = 2, Title = "Additional Test Book", Author = "Prof Additional", PublicationYear = 2021, IsAvailable = true });

            var results = library.SearchBooks("Search");

            Assert.Single(results);
            Assert.Equal("Search Test", results.First().Title);
        }
    }
}
