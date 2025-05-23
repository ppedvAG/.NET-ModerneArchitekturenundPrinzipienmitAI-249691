using LibraryHub.DataAccess.Data;
using LibraryHub.DataAccess.Tests.Common;
using LibraryHub.Domain.Entities;
using LibraryHub.Domain.Enums;

namespace LibraryHub.DataAccess.Tests.Tests;

[TestClass]
public class BookTests
{
    [TestMethod]
    [DataRow(Seed.Author1Id)]
    public async Task CreateBook_WithValidBook_BookAddedToDatabase(string authorId)
    {
        // Arrange
        using (var db = new TestDb())
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = "Test Book",
                ISBN = "1234567890",
                AuthorId = Guid.Parse(authorId),
                Category = Category.Fiction
            };

            // Act
            db.Context.Books.Add(book);
            await db.Context.SaveChangesAsync();

            // Assert
            var retrievedBook = db.Context.Books.Find(book.Id);
            Assert.IsNotNull(retrievedBook);
            Assert.AreEqual(book.Title, retrievedBook.Title);
        }
    }

    [TestMethod]
    [DataRow(Seed.Book1Id, Seed.Book1Title)]
    public void ReadBook_WithExistingBookId_RetrievesCorrectBook(string bookId, string expectedTitle)
    {
        // Arrange
        using (var db = new TestDb())
        {
            // Act
            var book = db.Context.Books.Find(Guid.Parse(bookId));

            // Assert
            Assert.IsNotNull(book);
            Assert.AreEqual(expectedTitle, book.Title);
        }
    }

    [TestMethod]
    [DataRow(Seed.Book1Id)]
    public async Task UpdateBook_WithExistingBook_UpdatesBookDetailsAsync(string bookId)
    {
        // Arrange
        using (var db = new TestDb())
        {
            // Act
            var book = db.Context.Books.Find(Guid.Parse(bookId));
            book.Title = "Updated Test Book";
            await db.Context.SaveChangesAsync();

            // Assert
            var updatedBook = db.Context.Books.Find(Guid.Parse(bookId));
            Assert.IsNotNull(updatedBook);
            Assert.AreEqual("Updated Test Book", updatedBook.Title);
        }
    }

    [TestMethod]
    [DataRow(Seed.Book1Id)]
    public void DeleteBook_WithExistingBook_RemovesBookFromDatabase(string bookId)
    {
        // Arrange
        using (var db = new TestDb())
        {
            // Act
            var book = db.Context.Books.Find(Guid.Parse(bookId));
            db.Context.Books.Remove(book);
            db.Context.SaveChanges();

            // Assert
            var deletedBook = db.Context.Books.Find(Guid.Parse(bookId));
            Assert.IsNull(deletedBook);
        }
    }
}