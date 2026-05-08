using WebApp.Models;

namespace WebApp.Services;

public class DataService : IDataService
{
    private readonly IConfiguration _config;

    public DataService(IConfiguration config)
    {
        _config = config;
    }

    public Task<IEnumerable<User>> GetFormattedUsersAsync(IEnumerable<User> users)
    {
        var maxItems = _config.GetValue<int>("MaxItems", 100);
        var result = users
            .OrderBy(u => u.Name)
            .Take(maxItems)
            .Select(u => new User
            {
                Id = u.Id,
                Name = u.Name.ToUpper(),
                Age = u.Age,
                Email = u.Email
            });
        
        return Task.FromResult(result);
    }
}