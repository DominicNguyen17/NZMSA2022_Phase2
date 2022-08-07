using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Model
{
    public partial class User
    {
        public User()
        {
            PokemonTeams = new HashSet<PokemonTeam>();
        }

        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string UserName { get; set; }
        public int BirthDate { get; set; }
        public int BirthMonth { get; set; }
        public int BirthYear { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<PokemonTeam> PokemonTeams { get; set; }
    }
}
