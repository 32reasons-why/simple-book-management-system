using BookManagementSystem.Models;
using Xunit;

namespace BookManagementSystem.Tests.Models
{
    public class BookTests
    {
        [Fact]
        public void Book_ShouldInitializeWithDefaultValues()
        {
            var book = new Book();

            Assert.Equal(0, book.BookID);
            Assert.Equal(string.Empty, book.Title);
            Assert.Equal(string.Empty, book.Author);
            Assert.Equal(0, book.PublicationYear);
            Assert.True(book.IsAvailable);
        }

        [Fact]
        public void Book_ShouldSetAndReturnPropertiesCorrectly()
        {
            var book = new Book
            {
                BookID = 1,
                Title = "PWC Junior Engineer",
                Author = "Sunnyboy Chilwana",
                PublicationYear = 2025,
                IsAvailable = false
            };

            Assert.Equal(1, book.BookID);
            Assert.Equal("PWC Junior Engineer", book.Title);
            Assert.Equal("Sunnyboy Chilwana", book.Author);
            Assert.Equal(2025, book.PublicationYear);
            Assert.False(book.IsAvailable);
        }
    }
}
