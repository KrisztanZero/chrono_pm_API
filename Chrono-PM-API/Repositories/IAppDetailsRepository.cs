using Chrono_PM_API.Models;

namespace Chrono_PM_API.Repositories;

public interface IAppDetailsRepository
{
    Task<IEnumerable<AppDetails>> GetAppDetailsListAsync();
    Task<AppDetails> GetAppDetailsByIdAsync(string id);
    Task<AppDetails> CreateAppDetailsAsync(AppDetails appDetails);
    Task<AppDetails> UpdateAppDetailsAsync(AppDetails appDetails);
    Task<bool> DeleteAppDetailsAsync(string id);
}