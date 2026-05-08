using WebApp.Models;

namespace WebApp.Services;

public interface IDataService
{
    Task<IEnumerable<User>> GetFormattedUsersAsync(IEnumerable<User> users);
}