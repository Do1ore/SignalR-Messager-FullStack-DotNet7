using Domain.JWTModels;
using Domain.MongoEntities.Chat;
using Domain.MongoEntities.User;

namespace Infrastructure.Abstraction.Repositories;

public interface IUserRepository
{
    Task<AppUserM> AddUser(AppUserM user);
    Task<List<ChatM>> GetChatsForUser(Guid userId);
    IAsyncEnumerable<AppUserM> GetUsersDetails(List<Guid> userIds);

    Task<bool> IsUserExists(Guid userId);
    Task<bool> IsUserEmailExists(string email);

    Task<AppUserM> GetUserById(Guid userId);
    Task<AppUserM> GetUserByEmail(string email);
    Task<string> UpdateUserRefreshToken(Guid userId, RefreshToken newRefreshToken);
    Task<List<AppUserM>> FindUsers(string searchTerm);
}