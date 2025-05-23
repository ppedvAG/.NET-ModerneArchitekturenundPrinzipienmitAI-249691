using LibraryHub.Domain.Entities;

namespace LibraryHub.Business.Core.Contracts
{
    public interface IBookService
    {
        Task<Book> AddBookToInventoryAsync(Book? book);
        Task<List<Book>> GetAllBooksAsync();
        Task<List<Book>> GetBooksByRatingAsync(int rating);
    }
}