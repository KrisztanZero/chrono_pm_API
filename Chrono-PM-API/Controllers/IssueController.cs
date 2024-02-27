using Chrono_PM_API.Models;
using Chrono_PM_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Chrono_PM_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class IssueController : Controller
{
    private readonly IIssueService _issueService;

    public IssueController(IIssueService issueService)
    {
        _issueService = issueService ?? throw new ArgumentNullException(nameof(issueService));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Issue>>> GetIssues()
    {
        var issues = await _issueService.GetIssuesAsync();
        return Ok(issues);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Issue>> GetIssue(string id)
    {
        var issue = await _issueService.GetIssueByIdAsync(id);
        if (issue == null)
        {
            return NotFound();
        }

        return issue;
    }
    
    [HttpPost]
    public async Task<ActionResult<Issue>> CreateIssue([FromBody] Issue issue)
    {
        if (issue == null)
        {
            return BadRequest("The request body cannot be null.");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdIssue = await _issueService.CreateIssueAsync(issue);
        return CreatedAtAction(nameof(GetIssue), new { id = createdIssue.Id }, createdIssue);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIssue(string id)
    {
        var result = await _issueService.DeleteIssueAsync(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}