using Chrono_PM_API.Dtos.Issue;
using Chrono_PM_API.Mappers;
using Chrono_PM_API.Services;
using Chrono_PM_API.Utilities;
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
    public async Task<ActionResult<IEnumerable<IssueDto>>> GetIssuesAsync()
    {
        var issueDtoList = await _issueService.GetIssuesAsync();
        return Ok(issueDtoList);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<IssueDto>> GetIssue(int id)
    {
        var issue = await _issueService.GetIssueByIdAsync(id);

        var issueDto = IssueMapper.MapToDto(issue);

        return Ok(issueDto);
    }
    
    [HttpPost]
    public async Task<ActionResult<IssueDto>> CreateIssue([FromBody] CreateIssueDto issue)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var currentUserId = UserUtilities.GetCurrentUserId(this);
            var createdIssue = await _issueService.CreateIssueAsync(issue, currentUserId );
            return Ok(createdIssue);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<IssueDto>> UpdateIssueAsync([FromBody] UpdateIssueDto updateIssueDto, int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedIssue = await _issueService.UpdateIssueAsync(updateIssueDto, id);

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