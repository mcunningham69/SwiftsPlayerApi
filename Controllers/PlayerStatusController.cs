using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftsPlayerApi.Models; // adjust to match your namespace

namespace SwiftsPlayerApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class PlayerStatusController : ControllerBase
    {
        private readonly SwiftsContext _context;

        public PlayerStatusController(SwiftsContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playerstatus>>> GetAll()
        {
            return await _context.Playerstatus.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<Playerstatus> players)
        {
            foreach (var p in players)
            {
                var existing = await _context.Playerstatus.FindAsync(p.Playerid);
                if (existing != null)
                    _context.Entry(existing).CurrentValues.SetValues(p);
                else
                    _context.Playerstatus.Add(p);
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Playerstatus updatedPlayer)
        {
            if (id != updatedPlayer.Playerid)
            {
                Console.WriteLine($"❌ PUT rejected: URL ID {id} does not match body ID {updatedPlayer.Playerid}");
                return BadRequest("Player ID in URL does not match body");
            }

            var existing = await _context.Playerstatus.FindAsync(id);
            if (existing == null)
            {
                Console.WriteLine($"❌ PUT failed: No player found with ID {id}");
                return NotFound($"No player found with ID {id}");
            }

            Console.WriteLine($"🔄 PUT updating player {id}: {updatedPlayer.Playername}");
            _context.Entry(existing).CurrentValues.SetValues(updatedPlayer);
            await _context.SaveChangesAsync();
            Console.WriteLine($"✅ PUT successful: Player {id} updated");

            return NoContent();
        }

    }
}
