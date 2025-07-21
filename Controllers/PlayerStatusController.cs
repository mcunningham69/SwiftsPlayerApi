using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<Playerstatus>> GetPlayer(Guid id)
        {
            var player = await _context.Playerstatus.FindAsync(id);
            if (player == null)
                return NotFound();

            return Ok(player);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<Playerstatus> players)
        {
            var created = new List<Playerstatus>();

            foreach (var p in players)
            {
                 // Only add if Playerid is Guid.Empty (i.e. new record)
                if (p.Playerid != Guid.Empty)
                {
                    var exists = await _context.Playerstatus
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Playerid == p.Playerid);

                    if (exists != null)
                        continue;
                }

                var newEntity = new Playerstatus
                {
                    Playername = p.Playername,
                    Firstname = p.Firstname,
                    Surname = p.Surname,
                    Email = p.Email,
                    Visits = p.Visits,
                    Isplaying = p.Isplaying,
                    Iswaiting = p.Iswaiting,
                    Isselectable = p.Isselectable,
                    Isfacilitator = p.Isfacilitator,
                    Ischoosing = p.Ischoosing,
                    Istimeout = p.Istimeout,
                    Warmingup = p.Warmingup,
                    Grade = p.Grade,
                    Gamescount = p.Gamescount,
                    Ischosen = p.Ischosen,
                    Isadmin = p.Isadmin,
                    Courtno = p.Courtno,
                    Attendingsession = p.Attendingsession,
                    Startedat = p.Startedat,
                    Finishedat = p.Finishedat,
                    Orderofplay = p.Orderofplay,
                    Squareid = p.Squareid,
                    Gameid = p.Gameid,
                    Playercategories = p.Playercategories,
                    DurationInSeconds = p.DurationInSeconds,
                    Notified = p.Notified,
                    NeedsSync = p.NeedsSync
                };

                _context.Playerstatus.Add(newEntity);
                created.Add(newEntity);
            }

            await _context.SaveChangesAsync();

            return Ok(created); // Return list with new Playerid values
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Playerstatus updatedPlayer)
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
            CopyValues(updatedPlayer, existing);
            await _context.SaveChangesAsync();
            Console.WriteLine($"✅ PUT successful: Player {id} updated");

            return NoContent();
        }


        [HttpPatch("{id}/squareid")]
        public async Task<IActionResult> PatchSquareId(
                int id,
                [FromBody] string squareId)
        {
            var player = await _context.Playerstatus.FindAsync(id);
            if (player == null) return NotFound();

            player.Squareid = squareId;
            await _context.SaveChangesAsync();
            return NoContent();
        }


        private void CopyValues(Playerstatus source, Playerstatus target)
        {
            target.Playername = source.Playername;
            target.Firstname = source.Firstname;
            target.Surname = source.Surname;
            target.Email = source.Email;
            target.Visits = source.Visits;
            target.Isplaying = source.Isplaying;
            target.Iswaiting = source.Iswaiting;
            target.Isselectable = source.Isselectable;
            target.Isfacilitator = source.Isfacilitator;
            target.Ischoosing = source.Ischoosing;
            target.Istimeout = source.Istimeout;
            target.Warmingup = source.Warmingup;
            target.Grade = source.Grade;
            target.Gamescount = source.Gamescount;
            target.Ischosen = source.Ischosen;
            target.Isadmin = source.Isadmin;
            target.Courtno = source.Courtno;
            target.Attendingsession = source.Attendingsession;
            target.Startedat = source.Startedat;
            target.Finishedat = source.Finishedat;
            target.Orderofplay = source.Orderofplay;
            target.Squareid = source.Squareid;
            target.Gameid = source.Gameid;
            target.Playercategories = source.Playercategories;
            target.DurationInSeconds = source.DurationInSeconds;
            target.Notified = source.Notified;
            target.NeedsSync = source.NeedsSync;
        }


    }
}

