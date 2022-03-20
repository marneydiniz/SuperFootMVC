using Microsoft.EntityFrameworkCore;
using SuperFootMVC.Models;

namespace SuperFootMVC.DataBase
{
    public class SuperFootContext : DbContext
    {
        public SuperFootContext(DbContextOptions<SuperFootContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Championship> Championships { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
             .HasMany<Game>(g => g.Games)
             .WithOne(u => u.User)
             .HasForeignKey(u => u.UserId)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
             .HasMany<Season>(s => s.Seasons)
             .WithOne(g => g.Game)
             .HasForeignKey(g => g.GameId)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Season>()
             .HasMany(c => c.Championships)
             .WithMany(s => s.Seasons);

            modelBuilder.Entity<Championship>()
             .HasMany<Round>(r => r.Rounds)
             .WithOne(c => c.Championship)
             .HasForeignKey(c => c.ChampionshipId)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Round>()
             .HasMany<Match>(m => m.Matches)
             .WithOne(r => r.Round)
             .HasForeignKey(r => r.RoundId)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Championship>()
            .HasOne(t => t.ChampionTeam)
            .WithMany(t => t.WinningChampionships)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Championship>()
            .Property(t => t.ChampionTeamId)
            .IsRequired(false);

            modelBuilder.Entity<Team>()
            .HasOne(c => c.Championship)
            .WithMany(t => t.Teams)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
             .HasOne(g => g.HomeTeam)
             .WithMany(t => t.MatchHomeTeams)
             .HasForeignKey(t => t.HomeTeamId)
             .OnDelete(DeleteBehavior.Restrict)
             .HasPrincipalKey(t => t.Id);

            modelBuilder.Entity<Match>()
             .HasOne(g => g.VisitantTeam)
             .WithMany(t => t.MatchVisitantTeams)
             .HasForeignKey(t => t.VisitantTeamId)
             .OnDelete(DeleteBehavior.Restrict)
             .HasPrincipalKey(t => t.Id);

            modelBuilder.Entity<Team>()
             .HasMany<Player>(t => t.Players)
             .WithOne(t => t.Team)
             .HasForeignKey(t => t.TeamId)
             .OnDelete(DeleteBehavior.Restrict);
        }

    }

}
