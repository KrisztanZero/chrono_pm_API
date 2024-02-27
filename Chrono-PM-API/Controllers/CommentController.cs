using Chrono_PM_API.Models;
using Chrono_PM_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Chrono_PM_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CommentController : Controller
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService ?? throw new ArgumentNullException(nameof(commentService));
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
    {
        var comments = await _commentService.GetCommentsAsync();
        return Ok(comments);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Comment>> GetComment(string id)
    {
        var comment = await _commentService.GetCommentByIdAsync(id);
        if (comment == null)
        {
            return NotFound();
        }

        return comment;
    }

    [HttpPost]
    public async Task<ActionResult<Comment>> CreateComment([FromBody] Comment comment)
    {
        if (comment == null)
        {
            return BadRequest("The request body cannot be null.");
        }
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdComment = await _commentService.CreateCommentAsync(comment);
        return CreatedAtAction(nameof(GetComment), new { id = createdComment.Id }, createdComment);
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