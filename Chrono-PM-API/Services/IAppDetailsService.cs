using Chrono_PM_API.Dtos.AppDetails;

namespace Chrono_PM_API.Services;

public interface IAppDetailsService
{
    Task<IEnumerable<AppDetailsDto>> GetAppDetailsAsync();
    Task<AppDetailsDto> GetAppDetailsByIdAsync(string id);
    Task<AppDetailsDto> CreateAppDetailsAsync(CreateAppDetailsDto createAppDetailsDto);
    Task<AppDetailsDto> UpdateAppDetailsAsync(UpdateAppDetailsDto updateAppDetailsDto, string id);
    Task<bool> DeleteAppDetailsAsync(string id);
}