using System.Security.Claims;
using Chrono_PM_API.Dtos.Issue;
using Chrono_PM_API.Mappers;
using Chrono_PM_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chrono_PM_API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class IssueController : ControllerBase
{
    private readonly IIssueService _issueService;

    public IssueController(IIssueService issueService)
    {
        _issueService = issueService ?? throw new ArgumentNullException(nameof(issueService));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<IssueDto>>> GetIssues()
    {
        var issues = await _issueService.GetIssuesAsync();
        var issueDtoList = IssueMapper.MapToDto(issues);
        return Ok(issueDtoList);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<IssueDto>> GetIssue(int id)
    {
        var issue = await _issueService.GetIssueByIdAsync(id);
        if (issue == null)
        {
            return NotFound("Issue not Found");
        }

        var issueDto = IssueMapper.MapToDto(issue);

        return Ok(issueDto);
    }
    
    [HttpPost]
    public async Task<ActionResult<IssueDto>> CreateIssue([FromBody] CreateIssueDto issue)
    {
        if (issue == null)
        {
            return BadRequest("The request body cannot be null.");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (currentUserId == null)
        {
            return NotFound("User not found");
        }

        var createdIssue = await _issueService.CreateIssueAsync(issue, currentUserId );
        return Ok(createdIssue);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<IssueDto>> UpdateIssueAsync([FromBody] UpdateIssueDto updateIssueDto, int id)
    {
        if (updateIssueDto == null)
        {
            return BadRequest("The request body cannot be null.");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedIssue = await _issueService.UpdateIssueAsync(updateIssueDto, id);
        if (updatedIssue == null)
        {
            return NotFound("Issue not found");
        }

        return Ok(updatedIssue);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIssue(int id)
    {
        var result = await _issueService.DeleteIssueAsync(id);
        if (!result)
        {
            return NotFound("Issue not found");
        }

        return NoContent();
    }
}