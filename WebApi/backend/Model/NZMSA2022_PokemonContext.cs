using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace backend.Model
{
    public partial class NZMSA2022_PokemonContext : DbContext
    {
        public NZMSA2022_PokemonContext()
        {
        }

        public NZMSA2022_PokemonContext(DbContextOptions<NZMSA2022_PokemonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PokemonTeam> PokemonTeams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:nzmsa2022pokemon.database.windows.net,1433;Initial Catalog=NZMSA2022_Pokemon;Persist Security Info=False;User ID=nzmsa2022pokemon;Password=Phu17022001;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PokemonTeam>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.PokemonTeams)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PokemonTe__UserI__5EBF139D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
