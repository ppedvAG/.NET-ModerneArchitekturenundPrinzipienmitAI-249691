using LibraryHub.Business.Core.Contracts;
using LibraryHub.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryHub.UI.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody] Book book)
    {
        if (book == null)
        {
            return BadRequest("Book data is null.");
        }

        var result = await _bookService.AddBookToInventoryAsync(book);
        return CreatedAtAction(nameof(GetAllBooks), new { id = result.Id }, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        var books = await _bookService.GetAllBooksAsync();
        return Ok(books);
    }

    [HttpGet("rating/{rating}")]
    public async Task<IActionResult> GetBooksByRating(int rating)
    {
        var books = await _bookService.GetBooksByRatingAsync(rating);
        return Ok(books);
    }
}
