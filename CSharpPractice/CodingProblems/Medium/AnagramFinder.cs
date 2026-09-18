namespace CSharpPractice.CodingProblems
{
    public class AnagramFinder
    {
        public static List<string> FindAnagramsGroups(string[] words)
        {
            Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>();

            foreach (string word in words)
            {
                char[] chars = word.ToCharArray();

                Array.Sort(chars);

                string key = new string(chars);

                if (!groups.ContainsKey(key))
                {
                    groups[key] = new List<string>();
                }

                groups[key].Add(word);
            }

            List<string> result = new List<string>();
            foreach (var group in groups.Values)
            {
                if (group.Count > 1)
                {
                    result.AddRange(group); // ← don't return yet
                }
            }

            return result; // ← return AFTER checking all groups
        }

        public static bool IsAnagram(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;

            Dictionary<char, int> counts = new Dictionary<char, int>();

            foreach (char c in s1)
            {
                if (counts.ContainsKey(c))
                    counts[c]++;
                else
                    counts[c] = 1;
            }

            foreach (char c in s2)
            {
                if (!counts.ContainsKey(c))
                    return false;

                counts[c]--;

                if (counts[c] < 0)
                    return false;
            }

            return true;
        }      
    }
}