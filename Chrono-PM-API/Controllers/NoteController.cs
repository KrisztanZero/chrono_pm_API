using Chrono_PM_API.Dtos.Note;
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
public class NoteController : ControllerBase
{
    private readonly INoteService _noteService;
    private readonly UserManager<AppUser> _userManager;

    public NoteController(INoteService noteService, UserManager<AppUser> userManager)
    {
        _noteService = noteService;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<NoteDto>>> GetNotesAsync()
    {
        var noteDtoList = await _noteService.GetNotesAsync();
        return Ok(noteDtoList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<NoteDto>> GetNoteByIdAsync(string id)
    {
        var noteDto = await _noteService.GetNoteByIdAsync(id);
        return Ok(noteDto);
    }

    [HttpPost]
    public async Task<ActionResult<NoteDto>> CreateNoteAsync([FromBody] CreateNoteDto createNote)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var currentUserId = await UserUtility.GetCurrentUserIdAsync(_userManager, this);
            var createdNote = await _noteService.CreateNoteAsync(createNote, currentUserId);
            return Ok(createdNote);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<NoteDto>> UpdateNoteAsync([FromBody] UpdateNoteDto updateNote, string id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedNote = await _noteService.UpdateNoteAsync(updateNote, id);
        return Ok(updatedNote);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletenote(string id)
    {
        var result = await _noteService.DeleteNoteAsync(id);
        if (!result)
        {
            return NotFound("Note not found");
        }

        return NoContent();
    }
}