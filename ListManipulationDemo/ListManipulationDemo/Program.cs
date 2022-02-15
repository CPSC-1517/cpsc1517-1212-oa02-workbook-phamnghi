// See https://aka.ms/new-console-template for more information
using ListManipulationDemo;
using System.Text.Json;

// Create a new custom class name HockeyPlayer with auto-implemented properties for:
// 1) player name
// 2) game played
// 3) goals
// 4) assists
// a derived property to compute the
// 5) point(goals + assists)

// Create a new custom class named HockeyName with auto-implemented property for:
// 1) team name
// a read only property for a list of  hockey player
// 2) players
// In the constructor add 8 players to the team


// Create a new HockeyPlayerTeam instance
HockeyTeam hockeyTeam = new HockeyTeam("Edmonyon Oilers");
// display all the players in the team
foreach (var players in hockeyTeam.Players)
{
    Console.WriteLine(players);
}
// remove player started a index 5
var splitTeam = hockeyTeam.RemovePlayerAt(5);

// Display all the players left in the team - there should only be 5 players left
Console.WriteLine("\nPlayer remaining in the team:");
foreach (var players in hockeyTeam.Players)
{
    Console.WriteLine(players);
}

// Display all the players removed from the team

Console.WriteLine("\nPlayer removed from the team:");
foreach (var players in splitTeam)
{
    Console.WriteLine(players);
}

HockeyTeam naitHockeyTeam = new HockeyTeam("NAIT OOKS");
// Remove players from the team after the player name Zack Hyman
var demotedPlayers = naitHockeyTeam.RemovePlayerStartingWithName("Zach Hyman");
// There should be now 3 players left in the team
Console.WriteLine("\nPlayer left in the team after Zach Hyman:");
foreach(var player in naitHockeyTeam.Players)
{
    Console.WriteLine(player);
}
// There should be 5 players demoted to NAIT OOKS
Console.WriteLine("\nPlayer demoted to NAIT OOKS after Zach Hyman:");
foreach (var player in demotedPlayers)
{
    Console.WriteLine(player);
}

// Serialize (Write) all the hockey players left after removing players at index 5 to a CSV file
// Serialize (Write) all the hockey players removed started at index 5 to a JSON file
// deserialize (Read) all the hockey players read from the CSV file
// Deserialize (Read) all the hockey players removed from he JSON file

// Serialize the hockey team and deserialize the hockey team to a JSON file

// Write to a JSON file all the properties of the Edmonton Oilers hockey team
HockeyTeam oilers = new HockeyTeam("Edmonton Oilers");
const string hockeyTeamJsonFilePath = "../../../Oilers.json";

try
{
    JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true // separated information
        
    };
    string jsonString = JsonSerializer.Serialize<HockeyTeam>(oilers, options);
    File.WriteAllText(hockeyTeamJsonFilePath, jsonString);
}
catch(Exception ex)
{
    Console.WriteLine("Create Json file Failed");
}

