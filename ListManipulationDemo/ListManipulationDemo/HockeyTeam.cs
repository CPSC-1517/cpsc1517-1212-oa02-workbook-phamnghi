using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListManipulationDemo
{
    public class HockeyTeam
    {
        public string TeamName { get; private set; }
        public List<HockeyPlayer> Players { get; }
        public HockeyTeam(string teamName)
        {
            TeamName = teamName;
            Players = new List<HockeyPlayer>
            {
                new HockeyPlayer{ PlayerName ="Leon Draisatil",GamePlayed=46,Goals=33,Assists=32},      //index 0
                new HockeyPlayer{ PlayerName ="Connor McDavid",GamePlayed=45,Goals=24,Assists=40},      //index 1
                new HockeyPlayer{ PlayerName ="Ryan Nugent-Hopkins",GamePlayed=39,Goals=6,Assists=28},  //index 2
                new HockeyPlayer{ PlayerName ="Zach Hyman",GamePlayed=30,Goals=14,Assists=13},          //index 3
                new HockeyPlayer{ PlayerName ="Jesse Puljujarvi",GamePlayed=44,Goals=11,Assists=15},    //index 4
                new HockeyPlayer{ PlayerName ="Evan Bourchard",GamePlayed=46,Goals=9,Assists=17},       //index 5
                new HockeyPlayer{ PlayerName ="Darnell Nurse",GamePlayed=39,Goals=5,Assists=15},        //index 6
                new HockeyPlayer{ PlayerName ="Tyson Barrie",GamePlayed=40,Goals=3,Assists=14},         //index 7

            };
        }

        public List<HockeyPlayer> RemovePlayerAt(int startIndex)
        {
            List<HockeyPlayer> splittedPlayers = new();
            for (int index = startIndex; index < Players.Count; index++)
            {
                splittedPlayers.Add(Players[index]);
            }

            Players.RemoveRange(startIndex, Players.Count - startIndex);
            return splittedPlayers;
            
        }

        public List<HockeyPlayer> RemovePlayerStartingWithName(string playerName)
        {
            int indexOfPlayerName = 0;
            for(int index = 0; index < Players.Count; ++index)
            {
                if(Players[index].PlayerName == playerName)
                {
                    indexOfPlayerName = index;
                    index = Players.Count;
                }
            }
            return RemovePlayerAt(indexOfPlayerName);
        }
    }
}
