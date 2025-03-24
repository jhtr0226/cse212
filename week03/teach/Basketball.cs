/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        //var players = new Dictionary<string, int>();

        //using var reader = new TextFieldParser("basketball.csv");
        //reader.TextFieldType = FieldType.Delimited;
        //reader.SetDelimiters(",");
        //reader.ReadFields(); // ignore header row
        //while (!reader.EndOfData)
        //{
        //    var fields = reader.ReadFields()!;
        //    var playerId = fields[0];
        //    var points = int.Parse(fields[8]);
        //}

        //Console.WriteLine($"Players: {{{string.Join(", ", players)}}}");

        //var topPlayers = new string[10];


        //--------------------------------------------------------------------------------------------
        // This dictionary will keep track of the total points per player
        Dictionary<string, int> players = new();

        // Open the CSV file and read line by line
        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");

        reader.ReadFields(); // Skip the header row

        while (!reader.EndOfData)
        {
            var fields = reader.ReadFields()!;

            // Get the player's ID (column 0)
            string playerId = fields[0];

            // Get the points for that season (column 8)
            int points = int.Parse(fields[8]);

            // If the player is already in our dictionary, add to their total
            if (players.ContainsKey(playerId))
            {
                players[playerId] += points;
            }
            else
            {
                // If player not in dictionary, add them with their initial points
                players[playerId] = points;
            }







        }
    }
}