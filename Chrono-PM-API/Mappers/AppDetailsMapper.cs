using Chrono_PM_API.Dtos.AppDetails;
using Chrono_PM_API.Models;

namespace Chrono_PM_API.Mappers;

public static class AppDetailsMapper
{
    public static AppDetailsDto MapToDto(AppDetails appDetails)
    {
        return new AppDetailsDto()
        {
            Id = appDetails.Id,
            WelcomeMessage = appDetails.WelcomeMessage,
            Introduction = appDetails.Introduction,
            Version = appDetails.Version,
            Developers = appDetails.Developers,
            CopyRights = appDetails.CopyRights,
            CreatedAt = appDetails.CreatedAt,
            UpdatedAt = appDetails.UpdatedAt
        };
    }

    public static IEnumerable<AppDetailsDto> MapToDto(IEnumerable<AppDetails> appDetailsList)
    {
        return appDetailsList.Select(MapToDto).ToList();
    }

    public static AppDetails MapToModel(CreateAppDetailsDto createAppDetailsDto)
    {
        return new AppDetails()
        {
            WelcomeMessage = createAppDetailsDto.WelcomeMessage,
            Introduction = createAppDetailsDto.Introduction,
            Version = createAppDetailsDto.Version,
            Developers = createAppDetailsDto.Developers,
            CopyRights = createAppDetailsDto.CopyRights
        };
    }

    public static void MapForUpdate(UpdateAppDetailsDto updateAppDetailsDto, AppDetails appDetails)
    {
        appDetails.UpdatedAt = DateTime.Now;
        appDetails.WelcomeMessage = updateAppDetailsDto.WelcomeMessage ?? appDetails.WelcomeMessage;
        appDetails.Introduction = updateAppDetailsDto.Introduction ?? appDetails.Introduction;
        appDetails.Version = updateAppDetailsDto.Version ?? appDetails.Version;
        appDetails.CopyRights = updateAppDetailsDto.CopyRights ?? appDetails.CopyRights;

        if (updateAppDetailsDto.Developers != null && updateAppDetailsDto.Developers.Any())
        {
            appDetails.Developers.AddRange(updateAppDetailsDto.Developers.Except(appDetails.Developers));
        }
    }
}