using backend.Model;

namespace backend.Services
{
    public class PokemonServices : IPokemonServices
    {
        private readonly HttpClient _client;
        public PokemonServices(IHttpClientFactory clientFactory)
        {
            if (clientFactory is null)
            {
                throw new ArgumentNullException(nameof(clientFactory));
            }
            _client = clientFactory.CreateClient("pokeapi");
        }
        public async Task<Pokemon> GetAPokemon(int id)
        {
            var pokemonId = id;
            if (pokemonId > 1000)
            {
                pokemonId = pokemonId % 100;
            }
            Pokemon res = await _client.GetFromJsonAsync<Pokemon>($"{pokemonId}");
            return res;
        }
    }
}
