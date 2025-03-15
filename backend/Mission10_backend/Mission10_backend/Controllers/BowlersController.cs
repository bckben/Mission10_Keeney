using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission10_backend.Models;  

namespace Mission10_backend.Controllers  
{
    [Route("[controller]")]
    [ApiController]
    public class BowlersController : ControllerBase
    {
        private readonly BowlingLeagueContext _context;

        public BowlersController(BowlingLeagueContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bowler>>> GetBowlers()
        {
            var bowlers = await _context.Bowlers
                .Include(b => b.Team)
                .Where(b => b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks")
                .ToListAsync();

            return Ok(bowlers);
        }
    }
}