using LibraryHub.Domain.Entities;

namespace LibraryHub.Business.Core.Contracts;

public interface IReviewService
{
    Task AddReviewAsync(Review review);
    Task<List<Review>> GetReviewsByDateAsync(DateTime date);
    Task<List<Review>> GetReviewsForBookAsync(Guid bookId);
    Task<List<Review>> GetReviewsForUserAsync(Guid userId);
}