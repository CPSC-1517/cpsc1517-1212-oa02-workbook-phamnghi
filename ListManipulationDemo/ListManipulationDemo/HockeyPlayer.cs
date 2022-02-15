using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListManipulationDemo
{
    public class HockeyPlayer
    {
        public string PlayerName { get; set; }
        public int GamePlayed { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int Points { get { return Goals + Assists; } }

        public HockeyPlayer()
        {
            PlayerName = "Ghost Rider";
            GamePlayed = 0;
            Goals = 0;
            Assists = 0;
        }

        public HockeyPlayer(string playerName, int gamePlayed, int goals, int assists)
        {
            PlayerName = playerName;
            GamePlayed = gamePlayed;
            Goals = goals;
            Assists = assists;
        }

        public override string ToString()
        {
            return $"{PlayerName},{GamePlayed},{Goals},{Assists},{Points}";
        }
    }
}
