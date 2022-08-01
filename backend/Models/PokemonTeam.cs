using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class PokemonTeam
    {
        public DateTime Created { get; set; }
        [Required]
        public String Name { get; set; }
        public int ID { get; set; }
    }
}