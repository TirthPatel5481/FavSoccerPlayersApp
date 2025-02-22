using System.ComponentModel.DataAnnotations;

namespace FavSoccerPlayersApp.Entities
{
    public class SoccerPlayer
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }= string.Empty;

        [Required]
        [Range(1, 99, ErrorMessage = "Number must be between 1 to 99.")]
        public int Number { get; set; }

        [Required]
        public string? Team { get; set; }= string.Empty;

        public string? PreviousTeams { get; set; }


        public List<string> PreviousTeamsList
        {
            get
            {
                return PreviousTeams?.Split(",").ToList() ?? new List<string>();
            }
        }
    }
}
