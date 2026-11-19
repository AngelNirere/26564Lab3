namespace Smart_match.Models;

public static class MatchingService
{
    private static readonly HashSet<string> StopWords = new()
    {
        "my", "to", "and", "the", "for", "of", "in", "a", "an", "with", "on", "is"
    };

    // Returns a score from 0 (no match) to 1 (perfect match)
    public static double Score(Profile mentee, Profile mentor)
    {
        var a = BuildVector(mentee);
        var b = BuildVector(mentor);

        double dot = 0;
        foreach (var pair in a)
        {
            if (b.TryGetValue(pair.Key, out int other))
                dot += pair.Value * other;
        }

        double lengthA = Math.Sqrt(a.Values.Sum(v => (double)v * v));
        double lengthB = Math.Sqrt(b.Values.Sum(v => (double)v * v));

        if (lengthA == 0 || lengthB == 0) return 0;
        return dot / (lengthA * lengthB);
    }

    // Turns the profile text into word counts, for example: python=1, sql=1, startup=2
    private static Dictionary<string, int> BuildVector(Profile p)
    {
        string text = $"{p.Skills} {p.Interests} {p.Industry} {p.Goals}".ToLower();
        char[] separators = { ' ', ',', '.', ';', ':', '-', '/', '(', ')', '\n', '\r' };

        var vector = new Dictionary<string, int>();
        foreach (string raw in text.Split(separators, StringSplitOptions.RemoveEmptyEntries))
        {
            string word = raw.Trim();
            if (word.Length < 2 || StopWords.Contains(word)) continue;

            // simple plural fix so "startups" and "startup" count as the same word
            if (word.Length > 3 && word.EndsWith("s") && !word.EndsWith("ss"))
                word = word[..^1];

            vector[word] = vector.GetValueOrDefault(word) + 1;
        }
        return vector;
    }
}