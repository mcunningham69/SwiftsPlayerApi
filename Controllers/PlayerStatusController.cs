using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftsPlayerApi.Models; // adjust to match your namespace

namespace SwiftsPlayerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
    }
}
