using backend.Model;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : Controller
    {
        protected IPokemonServices _pokemonServices;

        public PokemonController(IPokemonServices pokemonServices)
        {
            _pokemonServices = pokemonServices;
        }
        /// <summary>
        /// Gets the JSON for the pokemon infomation in PokeApi
        /// </summary>
        /// <returns>A JSON object representingpokemon infomation in PokeApi</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<Pokemon> GetAPokemon(int id)
        {
            return await _pokemonServices.GetAPokemon(id);
        }
    }
}
