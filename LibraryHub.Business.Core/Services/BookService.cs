using LibraryHub.Business.Core.Contracts;
using LibraryHub.DataAccess;
using LibraryHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryHub.Business.Core.Services;

public class BookService : IBookService
{
    private readonly LibraryHubDbContext _context;

    public BookService(LibraryHubDbContext context)
    {
        _context = context;
    }

    // Add a new book to the inventory
    public async Task<Book> AddBookToInventoryAsync(Book? book)
    {
        if (book == null)
        {
            throw new ArgumentNullException(nameof(book));
        }

        // Additional business logic can be added here, e.g., checking if the ISBN is already registered
        if (await _context.Books.AnyAsync(b => b.ISBN == book.ISBN))
        {
            throw new InvalidOperationException("ISBN is already registered.");
        }

        book.Id = Guid.NewGuid();
        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return book;
    }

    // Get all books
    public async Task<List<Book>> GetAllBooksAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<List<Book>> GetBooksByRatingAsync(int rating)
    {
        if (rating < 1 || rating > 5)
        {
            throw new ArgumentOutOfRangeException(nameof(rating), "Rating must be between 1 and 5.");
        }

        return await _context.Reviews
            .Where(r => r.Rating == rating)
            .Include(r => r.Book) // left join in SQL
            .Select(r => r.Book)
            .ToListAsync();
    }
}