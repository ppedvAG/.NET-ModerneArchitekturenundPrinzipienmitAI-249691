using LibraryHub.Business.Core.Contracts;
using LibraryHub.DataAccess;
using LibraryHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryHub.Business.Core.Services;

public class UserService : IUserService
{
    private readonly LibraryHubDbContext _context;

    public UserService(LibraryHubDbContext context)
    {
        _context = context;
    }

    // Register a new user
    public async Task<User> RegisterUserAsync(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        // Additional business logic can be added here, e.g., checking if the email is already registered
        if (await _context.Users.AnyAsync(u => u.Email == user.Email))
        {
            throw new InvalidOperationException("Email is already registered.");
        }

        user.Id = Guid.NewGuid();
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }

    // Get all users
    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }
}