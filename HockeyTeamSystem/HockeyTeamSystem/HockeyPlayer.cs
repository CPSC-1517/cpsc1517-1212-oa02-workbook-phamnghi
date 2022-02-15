using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyTeamSystem
{
    public class HockeyPlayer : Person
    {
        //private string _fullName;       //field declaration or private backing field => using private so the data cannot be change
        private int _primaryNumber;     //field declaration or private backing field
        public PlayerPosition Position { get; private set; } // private set is used for: cannot be edited outside of class

        // Define properties with private set for Goals, Assists
        public int Goals { get; private set; }
        public int Assists { get; private set; }

        // Define a computed read-only for Points (Goals + Assists)
        public int Points
        {
            get { return Goals + Assists; }
        }

        public int PrimaryNumber // => fully implemented
        { 
            get { return _primaryNumber; }
            private set 
            {
                //validate PrimaryNumber is between 1 and 99
                if(value < 1 || value > 99)
                {
                    throw new ArgumentException("HockeyPlayer PrimaryNumber must be between 1 and 99.");
                }
                _primaryNumber = value; //value is  a keyword that can only be used inside a set block
                                        // and it is the new value that is assigned to the property
            }
        }
        //// Define an fully-implemented property for FullName
        ////with readonly informaion
        //// Validate FullName is not null, not empty, and not a whitespace
        //// Validate FullName contains at minimum 3 characters
        //public string FullName
        //{
        //    get { return _fullName; }
        //    private set
        //    {
        //        if (string.IsNullOrWhiteSpace(value))
        //        {
        //            throw new ArgumentException("HockeyPlayer FullName must not be null or empty or  be a whitespace");
        //        }
        //        if (value.Trim().Length <= 3)
        //        {
        //            throw new ArgumentException("HockeyPlayer FullName must contain at least 3 characters.");
        //        }
        //        _fullName = value.Trim();
        //    }
        //}

        // Define an greedy constructor
        public HockeyPlayer(string fullName, int primaryNumber, PlayerPosition position, int goals, int assists) : base(fullName)
        {
            //FullName = fullName;
            PrimaryNumber = primaryNumber;
            Position = position;
            Goals = goals;
            Assists = assists;
        }
        // Override the ToString() method to return a CSV
        public override string ToString()
        {
            return $"{FullName},{PrimaryNumber},{Position}";
        }

        // A static (class-level) method can be accessed directly without creating an instance
        //object for the class. For example we can 
        // HockeyPlayer currentPlayer = HockeyPlayer.Parse("...");
        public static HockeyPlayer Parse(string csvLineText)
        {
            const char Delimeter = ',';
            string[] tokens = csvLineText.Split(Delimeter);
            // There should be five values in the tokens
            if (tokens.Length != 5)
            {
                throw new FormatException($"CSV string must contain exactly 5 values. {csvLineText}");
            }
            //return new HockeyPlayer(
            //   tokens[0],
            //   int.Parse(tokens[1]),
            //   (PlayerPosition)Enum.Parse(typeof(PlayerPosition), tokens[2]),
            //   int.Parse(tokens[3]),
            //   int.Parse(tokens[4])
            //);
            return new HockeyPlayer(
                fullName: tokens[0],
                primaryNumber: int.Parse(tokens[1]),
                position: (PlayerPosition)Enum.Parse(typeof(PlayerPosition), tokens[2]),
                goals: int.Parse(tokens[3]),
                assists: int.Parse(tokens[4])
                );

        }

        public static bool TryParse(string csvLineText, HockeyPlayer player)
        {
            bool success = false;
            try
            {
                player = Parse(csvLineText);
                success = true;
            }
            catch (FormatException ex)
            {
                throw new FormatException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception($"HockeyPlayer TryParse {ex.Message}");
            }
            return success;
        }
    }
}
