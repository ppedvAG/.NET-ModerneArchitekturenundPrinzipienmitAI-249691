using LibraryHub.Domain.Entities;

namespace LibraryHub.Business.Core.Contracts;

public interface IUserService
{
    Task<List<User>> GetAllUsersAsync();
    Task<User> RegisterUserAsync(User user);
}