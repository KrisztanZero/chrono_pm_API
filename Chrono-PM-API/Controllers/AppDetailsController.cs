using Chrono_PM_API.Dtos.AppDetails;
using Chrono_PM_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Chrono_PM_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppDetailsController : ControllerBase
{
    private readonly IAppDetailsService _appDetailsService;

    public AppDetailsController(IAppDetailsService appDetailsService)
    {
        _appDetailsService = appDetailsService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppDetailsDto>>> GetAppDetailsListAsync()
    {
        var appDetailsDtoList = await _appDetailsService.GetAppDetailsAsync();
        return Ok(appDetailsDtoList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppDetailsDto>> GetAppDetailsAsync(string id)
    {
        var appDetailsDto = await _appDetailsService.GetAppDetailsByIdAsync(id);
        return Ok(appDetailsDto);
    }

    [HttpPost]
    public async Task<ActionResult<AppDetailsDto>> CreateAppDetailsAsync(
        [FromBody] CreateAppDetailsDto createAppDetailsDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var createdAppDetails = await _appDetailsService.CreateAppDetailsAsync(createAppDetailsDto);
            return Ok(createdAppDetails);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<AppDetailsDto>> UpdateAppDetailsAsync(
        [FromBody] UpdateAppDetailsDto updateAppDetailsDto, string id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedAppDetailsDto = await _appDetailsService.UpdateAppDetailsAsync(updateAppDetailsDto, id);
        return Ok(updatedAppDetailsDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAppDetails(string id)
    {
        var result = await _appDetailsService.DeleteAppDetailsAsync(id);
        return Ok(result);
    }
}