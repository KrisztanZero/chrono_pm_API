using Chrono_PM_API.Dtos.Comment;
using Chrono_PM_API.Models;
using Chrono_PM_API.Services;
using Chrono_PM_API.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Chrono_PM_API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;
    private readonly UserManager<AppUser> _userManager;

    public CommentController(ICommentService commentService, UserManager<AppUser> userManager)
    {
        _commentService = commentService ?? throw new ArgumentNullException(nameof(commentService));
        _userManager = userManager;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CommentDto>>> GetComments()
    {
        var comments = await _commentService.GetCommentsAsync();
        return Ok(comments);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CommentDto>> GetComment(string id)
    {
        var comment = await _commentService.GetCommentByIdAsync(id);
        return Ok(comment);
    }

    [HttpPost]
    public async Task<ActionResult<CommentDto>> CreateComment([FromBody] CreateCommentDto comment)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var currentUserId = await UserUtility.GetCurrentUserIdAsync(_userManager, this);
            var createdComment = await _commentService.CreateCommentAsync(comment, currentUserId);
            return Ok(createdComment);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComment(string id)
    {
        var result = await _commentService.DeleteCommentAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}