using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyTeamSystem
{
    public class HockeyTeam
    {
        // Define a compute (read-only) property to TotalPoints for all HockeyPlayers
        //sum the Points for each HockeyPlayer in the team
        public int TotalPoints
        {
            get
            {
                int sum = 0;
                foreach(HockeyPlayer currentPlayer in HockeyPlayers)
                {
                    sum += currentPlayer.Points;
                }
                // or we can use
                //foreach (var currentPlayer in HockeyPlayers)
                //{
                //    sum += currentPlayer.Points;
                //}
                return sum;
            }
            
        }


        // Define a fully-implemented property with a backing field for the team name
        private string _teamName;   // Define a private backing field for the property
        public string TeamName      // Define a readonly property for TeamName with a private set -> fully implemented property
        {
            get { return _teamName; }
            private set 
            { 
                //validate the new team name is not null, an empty string, or only whitespace
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Hockey TeamName is required.");
                }

                // Validate the new team name contains at least 5 or more characters
                if (value.Trim().Length < 5)
                {
                    throw new ArgumentException("Hockey TeamName must contains 5 or more characters.");
                }
                _teamName = value;
            }
        }
        // Define an auto-implemented property with a private for the team division
        public TeamDivision Division { get; private set; }

        // Define an auto-implemented readonly property for the HockeyPlayers
        public List<HockeyPlayer> HockeyPlayers { get; } = new List<HockeyPlayer>();

        // Define an readonly property for PlayerCount
        public int PlayerCount
        {
            get { return HockeyPlayers.Count;}
        }

        // Define a readonly property with a private set for the Coach
        // The Coach property is known as Aggregation/Composition when the field/property is an object
        public HockeyCoach Coach { get; private set; }

#pragma warning disable
        // Define a greedy construct that has a parameter for the team name, TeamDivision and coach
        public HockeyTeam(string teamName, TeamDivision division, HockeyCoach coach)
        {
            TeamName = teamName;
            Division = division;
            Coach = coach;
        }

        // Define a method to add a player to the team
        public void AddPlayer(HockeyPlayer player)
        {
            // Validate that the player is not null
            if (player == null)
            {
                throw new ArgumentException("HockeyTeam add HockeyPlayer is required.");
            }

            // Validate that the number of players is less than 23
            if(PlayerCount > 23)
            {
                throw new InvalidOperationException("There are enough player in the team.");
            }

            // Validate that the play is not already on the team (by primary number)
            foreach (HockeyPlayer currentPlayer in HockeyPlayers)
            {
                if (player.PrimaryNumber == currentPlayer.PrimaryNumber)
                {
                    throw new ArgumentException("HockeyTeam add hockey player failed. Player primary number already exists.");
                }

            }

            HockeyPlayers.Add(player);
        }

        public override string ToString()
        {
            return $"{TeamName},{Coach},{Division}";
        }

    }
}
