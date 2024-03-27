using Chrono_PM_API.Dtos.AppDetails;
using Chrono_PM_API.Mappers;
using Chrono_PM_API.Repositories;

namespace Chrono_PM_API.Services;

public class AppDetailsService : IAppDetailsService
{
    private readonly IAppDetailsRepository _appDetailsRepository;

    public AppDetailsService(IAppDetailsRepository appDetailsRepository)
    {
        _appDetailsRepository = appDetailsRepository;
    }

    public async Task<IEnumerable<AppDetailsDto>> GetAppDetailsAsync()
    {
        var appDetails = await _appDetailsRepository.GetAppDetailsListAsync();
        return AppDetailsMapper.MapToDto(appDetails);
    }

    public async Task<AppDetailsDto> GetAppDetailsByIdAsync(string id)
    {
        var appDetails = await _appDetailsRepository.GetAppDetailsByIdAsync(id);
        return AppDetailsMapper.MapToDto(appDetails);
    }

    public async Task<AppDetailsDto> CreateAppDetailsAsync(CreateAppDetailsDto createAppDetailsDto)
    {
        var appDetails = AppDetailsMapper.MapToModel(createAppDetailsDto);
        await _appDetailsRepository.CreateAppDetailsAsync(appDetails);
        return AppDetailsMapper.MapToDto(appDetails);
    }

    public async Task<AppDetailsDto> UpdateAppDetailsAsync(UpdateAppDetailsDto updateAppDetailsDto, string id)
    {
        var existingAppDetails = await _appDetailsRepository.GetAppDetailsByIdAsync(id);
        AppDetailsMapper.MapForUpdate(updateAppDetailsDto, existingAppDetails);
        var updatedAppDetails = await _appDetailsRepository.UpdateAppDetailsAsync(existingAppDetails);
        return AppDetailsMapper.MapToDto(updatedAppDetails);
    }

    public async Task<bool> DeleteAppDetailsAsync(string id)
    {
        var appDetails = await _appDetailsRepository.GetAppDetailsByIdAsync(id);
        if (appDetails == null) return false;
        return await _appDetailsRepository.DeleteAppDetailsAsync(id);
    }
}