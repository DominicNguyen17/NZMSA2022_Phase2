using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class PokemonTeam
    {
        public DateTime Created { get; set; }
        [Required]
        public String TeamName { get; set; }
        public String PokemonName { get; set; }
        public int ID { get; set; }

    }
}