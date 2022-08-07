using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Model
{
    [Table("PokemonTeam")]
    public partial class PokemonTeam
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string PokemonName { get; set; }
        public int PokemonId { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("PokemonTeams")]
        public virtual User User { get; set; }
    }
}
