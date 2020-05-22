using System;
using System.Linq;
using System.Threading.Tasks;
using Mesi.Io.Api.Clipboard.Domain;
using Mesi.Io.Api.Clipboard.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mesi.Io.Api.Clipboard.Controllers
{
    [ApiController]
    [Route("api/clipboard")]
    public class ClipboardController : AuthorizedController
    {
        private readonly IClipboardService _clipboardService;

        public ClipboardController(IClipboardService clipboardService)
        {
            _clipboardService = clipboardService;
        }

        [HttpPost]
        public IActionResult AddClipboardEntry([FromBody] AddClipboardEntryRequest entry)
        {
            if (!Guid.TryParse(entry.UserId, out var userId)) return BadRequest(new {message = "Invalid user id"});
            
            if (!IsAuthorizedBySubject(userId.ToString())) return Forbid();
            
            _clipboardService.AddEntryForUser(userId, entry.Content);

            return Ok();
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetAllByUser([FromRoute] string id)
        {
            if (!Guid.TryParse(id, out var userId)) return BadRequest(new {message = "Invalid user id"});
            
            if (!IsAuthorizedBySubject(id)) return Forbid();
                
            var entries = await _clipboardService.GetAllByUserId(userId);
            return Ok(entries.Select(e => new ClipboardEntryResponse(e.Content, e.CreatedAt)));
        }
    }
}