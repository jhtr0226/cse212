using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // Step 1: Store all words in a set so we can check for matches quickly
        HashSet<string> wordSet = new(words);

        // Step 2: Create a list to store the symmetric pairs we find
        List<string> result = new();

        // Step 3: Go through each word one by one
        foreach (string word in words)
        {
            // Reverse the word: for example "am" becomes "ma"
            string reversed = new string(new[] { word[1], word[0] });

            // Make sure we are not checking words like "aa" (they reverse to themselves)
            if (word != reversed && wordSet.Contains(reversed))
            {
                // Add the pair to the result
                result.Add($"{word} & {reversed}");

                // Remove both words from the set so we don’t find this pair again
                wordSet.Remove(word);
                wordSet.Remove(reversed);
            }
        }

        // Step 4: Convert the result list to an array and return it
        return result.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        // Create a dictionary to store degree -> count
        var degrees = new Dictionary<string, int>();

        // Go through each line in the file
        foreach (var line in File.ReadLines(filename))
        {
            // Split the line into pieces using comma
            var fields = line.Split(",");

            // Get the degree from column 4 (index 3)
            var degree = fields[3];

            // If we already saw this degree, increase its count
            if (degrees.ContainsKey(degree))
            {
                degrees[degree] += 1;
            }
            else
            {
                // First time seeing this degree, add it with count 1
                degrees[degree] = 1;
            }
        }

        // Return the full summary
        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // Step 1: Normalize both words (remove spaces, make lowercase)
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        // Step 2: If lengths don't match, they can't be anagrams
        if (word1.Length != word2.Length)
            return false;

        // Step 3: Use a dictionary to count letters in word1
        Dictionary<char, int> letterCounts = new();

        foreach (char c in word1)
        {
            if (letterCounts.ContainsKey(c))
            {
                letterCounts[c] += 1; // we've seen this letter again
            }
            else
            {
                letterCounts[c] = 1; // first time seeing this letter
            }
        }

        // Step 4: Loop through word2 and subtract from the counts
        foreach (char c in word2)
        {
            if (!letterCounts.ContainsKey(c))
            {
                return false; // letter doesn't exist in word1
            }

            letterCounts[c] -= 1;

            if (letterCounts[c] < 0)
            {
                return false; // more of this letter in word2 than in word1
            }
        }

        // Step 5: All counts should be zero if it's a perfect match
        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);



        // Create a list of formatted results
        List<string> results = new();

        foreach (var feature in featureCollection.Features)
        {
            var place = feature.Properties.Place;
            var mag = feature.Properties.Mag;

            // Only show data if both place and mag exist
            if (!string.IsNullOrEmpty(place) && mag.HasValue)
            {
                results.Add($"{place} - Mag {mag.Value}");
            }
        }

        // Return it as an array
        return results.ToArray();
        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
    }
}