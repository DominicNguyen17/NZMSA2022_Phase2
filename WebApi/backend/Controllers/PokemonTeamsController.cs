using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonTeamsController : ControllerBase
    {
        private readonly PokemonTeamDbContext _context;

        public PokemonTeamsController(PokemonTeamDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Gets all pokemons added to team.
        /// </summary>
        /// <returns>All the pokemons in team</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PokemonTeam>>> GetTeam()
        {
          if (_context.Team == null)
          {
              return NotFound();
          }
            return await _context.Team.ToListAsync();
        }

        /// <summary>
        /// Gets a pokemon added to team by ID.
        /// </summary>
        /// <returns>A pokemons in team which is chosen by ID</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PokemonTeam>> GetPokemonTeam(int id)
        {
          if (_context.Team == null)
          {
              return NotFound();
          }
            var pokemonTeam = await _context.Team.FindAsync(id);

            if (pokemonTeam == null)
            {
                return NotFound();
            }

            return pokemonTeam;
        }

        /// <summary>
        /// Update pokemon information by ID.
        /// </summary>
        /// <returns>A updated pokemons in team which is chosen by ID</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPokemonTeam(int id, PokemonTeam pokemonTeam)
        {
            if (id != pokemonTeam.ID)
            {
                return BadRequest();
            }

            _context.Entry(pokemonTeam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PokemonTeamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Add new pokemon into team.
        /// </summary>
        /// <returns>Pokemon in team</returns>
        [HttpPost]
        public async Task<ActionResult<PokemonTeam>> PostPokemonTeam(PokemonTeam pokemonTeam)
        {
            _context.Team.Add(pokemonTeam);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPokemonTeam", new { id = pokemonTeam.ID }, pokemonTeam);
        }

        /// <summary>
        /// Delete a pokemon by ID.
        /// </summary>
        /// <returns>Last pokemon in team</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePokemonTeam(int id)
        {
            if (_context.Team == null)
            {
                return NotFound();
            }
            var pokemonTeam = await _context.Team.FindAsync(id);
            if (pokemonTeam == null)
            {
                return NotFound();
            }

            _context.Team.Remove(pokemonTeam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PokemonTeamExists(int id)
        {
            return (_context.Team?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
