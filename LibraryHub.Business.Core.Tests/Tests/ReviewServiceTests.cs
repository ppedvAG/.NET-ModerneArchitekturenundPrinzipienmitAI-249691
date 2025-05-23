using LibraryHub.Business.Core.Services;
using LibraryHub.DataAccess.Data;
using LibraryHub.DataAccess.Tests.Common;
using LibraryHub.Domain.Entities;

namespace LibraryHub.Business.Core.Tests.Tests;

[TestClass]
public class ReviewServiceTests
{
    [TestMethod]
    public async Task AddReviewToBookAsync_WithValidReview_AddsReviewToDatabase()
    {
        // Arrange
        using (var db = new TestDb())
        {
            var reviewService = new ReviewService(db.Context);
            var review = new Review
            {
                BookId = Guid.Parse(Seed.Book1Id),
                UserId = Guid.Parse(Seed.User1Id),
                Rating = 5,
                Comment = "Great book!",
                ReviewDate = DateTime.Now
            };

            // Act
            await reviewService.AddReviewAsync(review);
            var result = db.Context.Reviews.Find(review.Id);

            // Assert
            Assert.IsNotNull(result, "Review should not be null.");
            Assert.AreEqual(review.Comment, result.Comment);
            Assert.IsTrue(db.Context.Reviews.Any(r => r.Id == result.Id));
        }
    }

    [TestMethod]
    public async Task AddReviewToBookAsync_WithNullReview_ThrowsArgumentNullException()
    {
        // Arrange
        using (var db = new TestDb())
        {
            var reviewService = new ReviewService(db.Context);

            // Act
            var task = reviewService.AddReviewAsync(null);

            // Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await task);
        }
    }

    [TestMethod]
    [DataRow(Seed.Book1Id)]
    public async Task GetReviewsForBookAsync_WithValidBookId_RetrievesReviewsForBook(string bookIdStr)
    {
        // Arrange
        using (var db = new TestDb())
        {
            var reviewService = new ReviewService(db.Context);
            var bookId = Guid.Parse(bookIdStr);
            var expectedResult = Seed.Reviews
                .Where(r => r.BookId == bookId)
                .Select(r => new { r.BookId, r.UserId, r.Rating, r.Comment, r.ReviewDate })
                .ToArray();

            // Act
            var result = await reviewService.GetReviewsForBookAsync(bookId);
            var actualResult = result.Select(r => new { r.BookId, r.UserId, r.Rating, r.Comment, r.ReviewDate }).ToArray();

            // Assert
            CollectionAssert.AreEquivalent(expectedResult, actualResult);
        }
    }

    private static IEnumerable<object[]> GetReviewDateArgs()
    {
        yield return new object[] { new DateTime(2023, 1, 1) };
    }

    [TestMethod]
    [DynamicData(nameof(GetReviewDateArgs), DynamicDataSourceType.Method)]
    public async Task GetReviewsByDateAsync_WithValidDate_RetrievesReviewsForDate(DateTime targetDate)
    {
        // Arrange
        using (var db = new TestDb())
        {
            var reviewService = new ReviewService(db.Context);
            var expectedResult = Seed.Reviews
                .Where(r => r.ReviewDate.Date == targetDate.Date)
                .Select(r => new { r.BookId, r.UserId, r.Rating, r.Comment, r.ReviewDate })
                .ToArray();

            // Act
            var result = await reviewService.GetReviewsByDateAsync(targetDate);
            var actualResult = result.Select(r => new { r.BookId, r.UserId, r.Rating, r.Comment, r.ReviewDate }).ToArray();

            // Assert
            CollectionAssert.AreEquivalent(expectedResult, actualResult);
        }
    }
}