using Chrono_PM_API.Dtos.Project;
using Chrono_PM_API.Models;
using Chrono_PM_API.Services;
using Chrono_PM_API.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Chrono_PM_API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;
    private readonly UserManager<AppUser> _userManager;

    public ProjectController(IProjectService projectService, UserManager<AppUser> userManager)
    {
        _projectService = projectService;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjectsAsync()
    {
        var projects = await _projectService.GetProjectsAsync();
        return Ok(projects);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProjectDto>> GetProjectByIdAsync(string id)
    {
        var project = await _projectService.GetProjectByIdAsync(id);
        return Ok(project);
    }

    [HttpPost]
    public async Task<ActionResult<ProjectDto>> CreateProjectAsync([FromBody] CreateProjectDto createProjectDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var currentUserId = await UserUtility.GetCurrentUserIdAsync(_userManager, this);
            var createdProject = await _projectService.CreateProjectAsync(createProjectDto, currentUserId);
            return Ok(createdProject);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProjectDto>> UpdateProjectAsync([FromBody] UpdateProjectDto updateProjectDto,
        string id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedProject = await _projectService.UpdateProjectAsync(updateProjectDto, id);
        return Ok(updatedProject);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProjectAsync(string id)
    {
        var result = await _projectService.DeleteProjectAsync(id);
        if (!result)
        {
            return NotFound("Project not found");
        }

        return NoContent();
    }
}