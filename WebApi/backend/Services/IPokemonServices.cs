using backend.Model;

namespace backend.Services
{
    public interface IPokemonServices
    {
        Task<Pokemon> GetAPokemon(int id);
    }
}
