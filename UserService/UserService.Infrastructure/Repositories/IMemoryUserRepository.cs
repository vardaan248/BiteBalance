using UserService.Domain.Entities;
using UserService.Domain.Interfaces;

namespace UserService.Infrastructure.Repositories;

public class InMemoryUserRepository : IUserRepository
{
    private readonly List<User> _users = new()
    {
        new User() { Email = "vs@vs.com", Id = Guid.NewGuid(), PasswordHash = "8TBVnw5/+fjcYFgxpfwCyLbs0Cy535T8GpD4/5hwlgg=", Role = "Admin", Username = "vsethi" },
    };

    public Task AddAsync(User user)
    {
        _users.Add(user);
        return Task.CompletedTask;
    }

    public Task<User?> GetByEmailAsync(string email)
        => Task.FromResult(_users.FirstOrDefault(u => u.Email == email));

    public Task<User?> GetByUsernameAsync(string username)
        => Task.FromResult(_users.FirstOrDefault(u => u.Username == username));
}
