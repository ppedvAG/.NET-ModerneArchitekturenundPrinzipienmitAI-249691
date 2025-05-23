using LibraryHub.Business.Core.Services;
using LibraryHub.DataAccess.Data;
using LibraryHub.DataAccess.Tests.Common;
using LibraryHub.Domain.Entities;
using LibraryHub.Domain.Enums;

namespace LibraryHub.Business.Core.Tests.Tests;

[TestClass]
public class BookServiceTests
{
    [TestMethod]
    public async Task AddBookToInventoryAsync_WithValidBook_AddsBookToDatabase()
    {
        // Arrange
        using (var db = new TestDb())
        {
            var bookService = new BookService(db.Context);
            var book = new Book
            {
                Title = "Test Book",
                ISBN = "1234567890",
                AuthorId = Guid.Parse(Seed.Author3Id),
                Category = Category.Fiction
            };

            // Act
            var result = await bookService.AddBookToInventoryAsync(book);

            // Assert
            Assert.IsNotNull(result, "Book should not be null.");
            Assert.AreEqual(book.Title, result.Title);
            Assert.IsTrue(db.Context.Books.Any(b => b.Id == result.Id));
        }
    }

    [TestMethod]
    public async Task AddBookToInventoryAsync_WithNullBook_ThrowsArgumentNullException()
    {
        // Arrange
        using (var db = new TestDb())
        {
            var bookService = new BookService(db.Context);

            // Act
            var task = bookService.AddBookToInventoryAsync(null);

            // Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await task);
        }
    }

    [TestMethod]
    [DataRow(5)]
    public async Task GetBooksByRatingAsync_WithValidRating_RetrievesBooksWithSpecifiedRating(int rating)
    {
        // Arrange
        using (var db = new TestDb())
        {
            var bookService = new BookService(db.Context);
            var expectedResult = Seed.Reviews
                .Where(r => r.Rating == rating)
                .Select(r => Seed.Books.Single(b => b.Id == r.BookId))
                .Select(b => new { b.Id, b.Title, b.ISBN, b.AuthorId, b.Category })
                .ToArray();

            // Act
            var result = await bookService.GetBooksByRatingAsync(rating);
            var actualResult = result.Select(b => new { b.Id, b.Title, b.ISBN, b.AuthorId, b.Category }).ToArray();

            // Assert
            CollectionAssert.AreEquivalent(expectedResult, actualResult);
        }
    }

    [TestMethod]
    public async Task GetBooksByRatingAsync_WithInvalidRating_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        using (var db = new TestDb())
        {
            var bookService = new BookService(db.Context);

            // Act
            var task = bookService.GetBooksByRatingAsync(0);

            // Assert
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () => await task);
        }
    }
}
