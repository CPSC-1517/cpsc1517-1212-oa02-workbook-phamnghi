using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// -> namespace

namespace HockeyTeamSystem
{
    // Define a class name HockeyCoach that inherits from the base class person
    public class HockeyCoach : Person // -> class name
    {
        // Define a readonly public field that can only be assigned a value
        //in the constructor
        public readonly string StartDate;  // ->field

        // Define a greedy constructor with startDate as parameter
        // The ": base(fullName)" means pass fullName to the base class (Person) constructor
        public HockeyCoach(string fullName, string startDate) : base(fullName)  //-> constructor(dataType parameter, dataType parameter name)
        {
            this.StartDate = startDate;
        }

        // Override the ToString() method to return a CSV
        public override string ToString()  // string is method return type
        {
            return $"{FullName},{StartDate}";
        }
    }
}
