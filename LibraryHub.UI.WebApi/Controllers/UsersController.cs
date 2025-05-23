using LibraryHub.Business.Core.Contracts;
using LibraryHub.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryHub.UI.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] User user)
    {
        if (user == null)
        {
            return BadRequest("User data is null.");
        }

        var result = await _userService.RegisterUserAsync(user);
        return CreatedAtAction(nameof(GetAllUsers), new { id = result.Id }, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }
}