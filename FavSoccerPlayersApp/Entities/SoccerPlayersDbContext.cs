using Microsoft.EntityFrameworkCore;

namespace FavSoccerPlayersApp.Entities
{
    public class SoccerPlayersDbContext : DbContext
    {
        public SoccerPlayersDbContext(DbContextOptions<SoccerPlayersDbContext> options)
            : base(options)
        {
        }

        public DbSet<SoccerPlayer> SoccerPlayers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SoccerPlayer>().HasData(
                new SoccerPlayer
                {
                    Id = 1,
                    Name = "Alphonso Davies",
                    Number = 19,
                    Team = "Bayern Munich",
                    PreviousTeams = "Vancouver Whitecaps FC"
                },
                new SoccerPlayer
                {
                    Id = 2,
                    Name = "Atiba Hutchinson",
                    Number = 13,
                    Team = "Beşiktaş",
                    PreviousTeams = "FC Copenhagen, PSV Eindhove"
                },
                new SoccerPlayer
                {
                    Id = 3,
                    Name = "Jonathan David",
                    Number = 20,
                    Team = "Lille OSC",
                    PreviousTeams = "Gent"
                },
                new SoccerPlayer
                {
                    Id = 4,
                    Name = "Cyle Larin",
                    Number = 17,
                    Team = "Real Valladolid",
                    PreviousTeams = "Orlando City SC, Zulte Waregem"
                },
                new SoccerPlayer
                {
                    Id = 5,
                    Name = "Milan Borjan",
                    Number = 1,
                    Team = "Red Star Belgrade",
                    PreviousTeams = "Sivasspor, Ludogorets Razgrad"
                }
            );
        }
    }
}
