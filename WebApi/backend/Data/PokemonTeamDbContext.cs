using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class PokemonTeamDbContext : DbContext
    {
        public PokemonTeamDbContext(DbContextOptions<PokemonTeamDbContext> options)
            : base(options)
        {
        }

        public DbSet<PokemonTeam> Team { get; set; }
    }
}
