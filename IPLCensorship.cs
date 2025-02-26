using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IPLCensorshipAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("IPL and Censorship Analyzer");
                Console.WriteLine("---------------------------");

                // Create sample data files if they don't exist
                CreateSampleDataIfNotExists();

                // Process JSON data
                Console.WriteLine("\nProcessing JSON data...");
                ProcessJsonData("ipl_matches.json", "censored_matches.json");

                // Process CSV data
                Console.WriteLine("\nProcessing CSV data...");
                ProcessCsvData("ipl_matches.csv", "censored_matches.csv");

                Console.WriteLine("\nProcessing complete! Press any key to exit.");
            }
            catch (Exception ex)
            {
                // Handle any errors
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadKey();
        }

        // Method to create sample data files if they don't exist
        static void CreateSampleDataIfNotExists()
        {
            // Sample JSON data
            string sampleJson = @"[
                {
                    ""match_id"": 101,
                    ""team1"": ""Mumbai Indians"",
                    ""team2"": ""Chennai Super Kings"",
                    ""score"": {
                        ""Mumbai Indians"": 178,
                        ""Chennai Super Kings"": 182
                    },
                    ""winner"": ""Chennai Super Kings"",
                    ""player_of_match"": ""MS Dhoni""
                },
                {
                    ""match_id"": 102,
                    ""team1"": ""Royal Challengers Bangalore"",
                    ""team2"": ""Delhi Capitals"",
                    ""score"": {
                        ""Royal Challengers Bangalore"": 200,
                        ""Delhi Capitals"": 190
                    },
                    ""winner"": ""Royal Challengers Bangalore"",
                    ""player_of_match"": ""Virat Kohli""
                }
            ]";

            // Sample CSV data
            string sampleCsv = @"match_id,team1,team2,score_team1,score_team2,winner,player_of_match
101,Mumbai Indians,Chennai Super Kings,178,182,Chennai Super Kings,MS Dhoni
102,Royal Challengers Bangalore,Delhi Capitals,200,190,Royal Challengers Bangalore,Virat Kohli";

            // Create JSON file if it doesn't exist
            if (!File.Exists("ipl_matches.json"))
            {
                File.WriteAllText("ipl_matches.json", sampleJson);
                Console.WriteLine("Sample JSON file created: ipl_matches.json");
            }

            // Create CSV file if it doesn't exist
            if (!File.Exists("ipl_matches.csv"))
            {
                File.WriteAllText("ipl_matches.csv", sampleCsv);
                Console.WriteLine("Sample CSV file created: ipl_matches.csv");
            }
        }

        // Method to process JSON data
        static void ProcessJsonData(string inputFile, string outputFile)
        {
            // Read the JSON file
            string jsonContent = File.ReadAllText(inputFile);

            // Parse JSON content
            JArray matches = JArray.Parse(jsonContent);

            // Apply censorship rules to each match
            foreach (JObject match in matches)
            {
                // Get team names for censoring
                string team1 = match["team1"].ToString();
                string team2 = match["team2"].ToString();

                // Apply censorship to team names
                string censoredTeam1 = MaskTeamName(team1);
                string censoredTeam2 = MaskTeamName(team2);

                // Update team names
                match["team1"] = censoredTeam1;
                match["team2"] = censoredTeam2;

                // Update winner name
                string winner = match["winner"].ToString();
                if (winner == team1)
                {
                    match["winner"] = censoredTeam1;
                }
                else if (winner == team2)
                {
                    match["winner"] = censoredTeam2;
                }

                // Update score object keys
                JObject scoreObj = (JObject)match["score"];
                if (scoreObj.ContainsKey(team1))
                {
                    // Store the value temporarily
                    JToken score = scoreObj[team1];
                    // Remove old key
                    scoreObj.Remove(team1);
                    // Add with new key
                    scoreObj.Add(censoredTeam1, score);
                }

                if (scoreObj.ContainsKey(team2))
                {
                    // Store the value temporarily
                    JToken score = scoreObj[team2];
                    // Remove old key
                    scoreObj.Remove(team2);
                    // Add with new key
                    scoreObj.Add(censoredTeam2, score);
                }

                // Redact player of the match
                match["player_of_match"] = "REDACTED";
            }

            // Write censored data to output file
            string censoredJson = matches.ToString(Formatting.Indented);
            File.WriteAllText(outputFile, censoredJson);

            Console.WriteLine("Censored JSON data saved to: " + outputFile);
        }

        // Method to process CSV data
        static void ProcessCsvData(string inputFile, string outputFile)
        {
            // Read all lines from the CSV file
            string[] csvLines = File.ReadAllLines(inputFile);

            // Ensure there's data to process
            if (csvLines.Length <= 1)
            {
                Console.WriteLine("No data in CSV file or only header row present.");
                return;
            }

            // Get the header row
            string headerRow = csvLines[0];

            // Initialize list for censored lines
            List<string> censoredLines = new List<string>();
            censoredLines.Add(headerRow); // Add header unchanged

            // Process each data row
            for (int i = 1; i < csvLines.Length; i++)
            {
                // Split the line into columns
                string[] columns = csvLines[i].Split(',');

                // Apply censorship rules
                if (columns.Length >= 7) // Ensure we have all required columns
                {
                    // Index reference:
                    // 0: match_id, 1: team1, 2: team2, 3: score_team1, 4: score_team2, 5: winner, 6: player_of_match

                    // Censor team names
                    columns[1] = MaskTeamName(columns[1]);
                    columns[2] = MaskTeamName(columns[2]);

                    // Censor winner team name
                    columns[5] = MaskTeamName(columns[5]);

                    // Redact player of the match
                    columns[6] = "REDACTED";

                    // Join columns back into a line
                    string censoredLine = string.Join(",", columns);
                    censoredLines.Add(censoredLine);
                }
            }

            // Write censored lines to output file
            File.WriteAllLines(outputFile, censoredLines);

            Console.WriteLine("Censored CSV data saved to: " + outputFile);
        }

        // Method to mask team name
        static string MaskTeamName(string teamName)
        {
            // Split team name into words
            string[] words = teamName.Split(' ');

            // For teams with multiple words, replace the last word with asterisks
            if (words.Length > 1)
            {
                // Mask the last word with asterisks
                words[words.Length - 1] = "***";

                // Join words back together
                return string.Join(" ", words);
            }
            else
            {
                // For single word team names, replace the second half with asterisks
                int halfLength = teamName.Length / 2;
                return teamName.Substring(0, halfLength) + "***";
            }
        }
    }
}
