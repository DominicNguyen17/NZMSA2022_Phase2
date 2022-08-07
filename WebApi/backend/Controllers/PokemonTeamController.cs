using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Model;
using backend.Services;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonTeamController : ControllerBase
    {
        private readonly NZMSA2022_PokemonContext _context;
        private readonly IUserServices _userServices;
        protected readonly IPokemonServices _pokemonServices;

        public PokemonTeamController(NZMSA2022_PokemonContext context, IUserServices userServices, IPokemonServices pokemonServices)
        {
            _context = context;
            _userServices = userServices;
            _pokemonServices = pokemonServices;
        }


        /// <summary>
        /// Gets all pokemons added to team.
        /// </summary>
        /// <returns>All the pokemons in team</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PokemonTeam>>> GetTeam()
        {
          if (_context.PokemonTeams == null)
          {
              return NotFound();
          }
            return await _context.PokemonTeams.ToListAsync();
        }

        /// <summary>
        /// Gets a pokemon added to team by ID.
        /// </summary>
        /// <returns>A pokemons in team which is chosen by ID</returns>
        [HttpGet("{id}")]
        public async Task<List<PokemonTeam>> GetPokemonTeam(int userId)
        {
          if (_context.PokemonTeams == null)
          {
              return null;
          }
            var pokemonTeam = await _context.PokemonTeams.Where(x => x.UserId == userId).ToListAsync();

            if (pokemonTeam == null)
            {
                return null;
            }

            return pokemonTeam;
        }

        /// <summary>
        /// Add new pokemon into team.
        /// </summary>
        /// <returns>Pokemon in team</returns>
        [HttpPost]
        public async Task<ActionResult<PokemonTeam>> CreateTeam(int userId)
        {
            var user = await _userServices.GetUser(userId);
            if (user == null) 
            { 
                return NotFound(); 
            }

            var pokemon1 = await _pokemonServices.GetAPokemon(user.BirthDate);
            var pokemon2 = await _pokemonServices.GetAPokemon(user.BirthMonth);
            var pokemon3 = await _pokemonServices.GetAPokemon(user.BirthYear);

            var pokemonTeam1 = new PokemonTeam
            {
                PokemonName = pokemon1.Name, PokemonId = pokemon1.ID, UserId = userId
            };
            _context.PokemonTeams.Add(pokemonTeam1);

            var pokemonTeam2 = new PokemonTeam
            {
                PokemonName = pokemon2.Name,
                PokemonId = pokemon2.ID,
                UserId = userId
            };
            _context.PokemonTeams.Add(pokemonTeam1);

            var pokemonTeam3 = new PokemonTeam
            {
                PokemonName = pokemon3.Name,
                PokemonId = pokemon3.ID,
                UserId = userId
            };
            _context.PokemonTeams.Add(pokemonTeam1);
            _context.PokemonTeams.Add(pokemonTeam2);
            _context.PokemonTeams.Add(pokemonTeam3);
            await _context.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// Delete a pokemon by ID.
        /// </summary>
        /// <returns>Last pokemon in team</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePokemonTeam(int id)
        {
            if (_context.PokemonTeams == null)
            {
                return NotFound();
            }
            var pokemonTeam = await _context.PokemonTeams.FindAsync(id);
            if (pokemonTeam == null)
            {
                return NotFound();
            }

            _context.PokemonTeams.Remove(pokemonTeam);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
