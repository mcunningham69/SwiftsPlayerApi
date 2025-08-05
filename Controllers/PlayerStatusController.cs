using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using SwiftsPlayerApi.Models; // adjust to match your namespace
using SwiftsPlayerApi.Extensions;

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
            var players = await _context.Playerstatus
                .Select(p => new Playerstatus
                {
                    Uuid = p.Uuid,
                    Playername = p.Playername,
                    Firstname = p.Firstname,
                    Surname = p.Surname,
                    Email = p.Email,
                    Changed_by = p.Changed_by,
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
                    DurationInSeconds = p.DurationInSeconds ?? 0,
                    Notified = p.Notified,
                    NeedsSync = p.NeedsSync
                }).ToListAsync();

            return Ok(players.Select(p => p.ToDTO()).ToList());
        }


        // GET single player by UUID
        [HttpGet("{uuid:guid}")]
        public async Task<ActionResult<PlayerStatusDTO>> GetPlayer(Guid uuid)
        {
            var player = await _context.Playerstatus.FirstOrDefaultAsync(p => p.Uuid == uuid);
            if (player == null)
                return NotFound();

            return Ok(player.ToDTO());
        }

        // POST new players
        [HttpPost]
        public async Task<ActionResult<IEnumerable<PlayerStatusDTO>>> Post([FromBody] List<Playerstatus> players)
        {
            var created = new List<Playerstatus>();

            foreach (var p in players)
            {
                if (p.Uuid == Guid.Empty)
                    p.Uuid = Guid.NewGuid();

                var exists = await _context.Playerstatus.AsNoTracking().FirstOrDefaultAsync(x => x.Uuid == p.Uuid);
                if (exists != null)
                    continue;

                _context.Playerstatus.Add(p);
                created.Add(p);
            }

            await _context.SaveChangesAsync();
            return Ok(created.Select(p => p.ToDTO()));
        }

      
        // PUT update player by UUID
        [HttpPut("{uuid:guid}")]
        public async Task<ActionResult<PlayerStatusDTO>> Put(Guid uuid, [FromBody] Playerstatus updatedPlayer)
        {
            if (uuid != updatedPlayer.Uuid)
                return BadRequest("UUID in URL does not match body");

            var existing = await _context.Playerstatus.FirstOrDefaultAsync(p => p.Uuid == uuid);
            if (existing == null)
                return NotFound();

            existing.CopyFromDTO(updatedPlayer.ToDTO());
            await _context.SaveChangesAsync();

            return Ok(existing.ToDTO());
        }

    

        // PATCH squareid by UUID
        [HttpPatch("{uuid:guid}/squareid")]
        public async Task<ActionResult<PlayerStatusDTO>> PatchSquareId(Guid uuid, [FromBody] string squareId)
        {
            var player = await _context.Playerstatus.FirstOrDefaultAsync(p => p.Uuid == uuid);
            if (player == null)
                return NotFound();

            player.Squareid = squareId;
            await _context.SaveChangesAsync();

            return Ok(player.ToDTO());
        }


    }

}

