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

    // GET all players
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Playerstatus>>> GetAll()
    {
        return await _context.Playerstatus.ToListAsync();
    }

    // GET single player by UUID
    [HttpGet("{uuid:guid}")]
    public async Task<ActionResult<Playerstatus>> GetPlayer(Guid uuid)
    {
        var player = await _context.Playerstatus.FirstOrDefaultAsync(p => p.Uuid == uuid);
        if (player == null)
            return NotFound();

        return Ok(player);
    }

    // POST new players
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] List<Playerstatus> players)
    {
        var created = new List<Playerstatus>();

        foreach (var p in players)
        {
            // Handle missing or placeholder UUIDs
            if (p.Uuid == Guid.Empty)
                p.Uuid = Guid.NewGuid();

            // Use UUID for deduplication
            var exists = await _context.Playerstatus
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Uuid == p.Uuid);

            if (exists != null)
                continue;

            var newEntity = new Playerstatus
            {
                Uuid = p.Uuid,  // 👈 Already set above (new or from client)

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
        return Ok(created);
    }

    // PUT update player by UUID
    [HttpPut("{uuid:guid}")]
    public async Task<IActionResult> Put(Guid uuid, [FromBody] Playerstatus updatedPlayer)
    {
        if (uuid != updatedPlayer.Uuid)
        {
            Console.WriteLine($"❌ PUT rejected: URL UUID {uuid} does not match body UUID {updatedPlayer.Uuid}");
            return BadRequest("UUID in URL does not match body");
        }

        var existing = await _context.Playerstatus.FirstOrDefaultAsync(p => p.Uuid == uuid);
        if (existing == null)
        {
            Console.WriteLine($"❌ PUT failed: No player found with UUID {uuid}");
            return NotFound($"No player found with UUID {uuid}");
        }

        Console.WriteLine($"🔄 PUT updating player {uuid}: {updatedPlayer.Playername}");
        CopyValues(updatedPlayer, existing);
        await _context.SaveChangesAsync();
        Console.WriteLine($"✅ PUT successful: Player {uuid} updated");

        return NoContent();
    }

    // PATCH squareid by UUID
    [HttpPatch("{uuid:guid}/squareid")]
    public async Task<IActionResult> PatchSquareId(Guid uuid, [FromBody] string squareId)
    {
        var player = await _context.Playerstatus.FirstOrDefaultAsync(p => p.Uuid == uuid);
        if (player == null) return NotFound();

        player.Squareid = squareId;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // Copy values from DTO or updated object
    private void CopyValues(Playerstatus source, Playerstatus target)
    {
        target.Uuid = source.Uuid;

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

