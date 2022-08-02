using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;
using Newtonsoft.Json;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetAPokemonController : Controller
    {
        private readonly HttpClient _client;
        public GetAPokemonController(IHttpClientFactory clientFactory)
        {
            if (clientFactory is null)
            {
                throw new ArgumentNullException(nameof(clientFactory));
            }
            _client = clientFactory.CreateClient("pokeapi");
        }
        /// <summary>
        /// Gets the JSON for the pokemon infomation in PokeApi
        /// </summary>
        /// <returns>A JSON object representingpokemon infomation in PokeApi</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAPokemon(int day, int month, int year)
        {
            var id = new Random().Next(1,1154);
            var res = await _client.GetAsync(String.Format("{0}", id));
            var content = await res.Content.ReadAsStringAsync();
            return Ok(content);
        }
    }
}
