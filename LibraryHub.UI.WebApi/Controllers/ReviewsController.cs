using LibraryHub.Business.Core.Contracts;
using LibraryHub.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryHub.UI.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewsController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpPost]
    public async Task<IActionResult> AddReview([FromBody] Review review)
    {
        if (review == null)
        {
            return BadRequest("Review data is null.");
        }

        await _reviewService.AddReviewAsync(review);
        return Ok();
    }

    [HttpGet("date/{date:datetime}")]
    public async Task<IActionResult> GetReviewsByDate(DateTime date)
    {
        var reviews = await _reviewService.GetReviewsByDateAsync(date);
        return Ok(reviews);
    }

    [HttpGet("book/{bookId:guid}")]
    public async Task<IActionResult> GetReviewsForBook(Guid bookId)
    {
        var reviews = await _reviewService.GetReviewsForBookAsync(bookId);
        return Ok(reviews);
    }

    [HttpGet("user/{userId:guid}")]
    public async Task<IActionResult> GetReviewsForUser(Guid userId)
    {
        var reviews = await _reviewService.GetReviewsForUserAsync(userId);
        return Ok(reviews);
    }
}