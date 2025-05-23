using LibraryHub.Business.Core.Contracts;
using LibraryHub.DataAccess;
using LibraryHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryHub.Business.Core.Services;

public class ReviewService : IReviewService
{
    private readonly LibraryHubDbContext _context;

    public ReviewService(LibraryHubDbContext context)
    {
        _context = context;
    }

    public async Task<List<Review>> GetReviewsForBookAsync(Guid bookId)
    {
        return await _context.Reviews
            .Where(r => r.BookId == bookId)
            .ToListAsync();
    }

    public async Task<List<Review>> GetReviewsForUserAsync(Guid userId)
    {
        return await _context.Reviews
            .Where(r => r.UserId == userId)
            .ToListAsync();
    }

    public async Task<List<Review>> GetReviewsByDateAsync(DateTime date)
    {
        return await _context.Reviews
            .Where(r => r.ReviewDate.Date == date.Date)
            .ToListAsync();
    }

    public async Task AddReviewAsync(Review review)
    {
        ArgumentNullException.ThrowIfNull(review, nameof(review));

        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();
    }
}
