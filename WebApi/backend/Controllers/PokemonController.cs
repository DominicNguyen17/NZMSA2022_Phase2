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
        /// Gets the pokemon infomation from PokeApi
        /// </summary>
        /// <returns>A pokemon infomation in PokeApi</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<Pokemon> GetAPokemon(int id)
        {
            return await _pokemonServices.GetAPokemon(id);
        }
    }
}
