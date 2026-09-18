namespace CSharpPractice.Programs
{
    public class CharacterFrequency
    {
        public void CharacterFrequencyCount()
        {
            const string input = "bbaac";

            Dictionary<char, int> characterCounts = new();

            foreach (char character in input)
            {
                if (characterCounts.TryGetValue(character, out int count))
                {
                    characterCounts[character] = count + 1;
                }
                else
                {
                    characterCounts[character] = 1;
                }
            }

            string result = string.Concat(characterCounts.OrderBy(pair => pair.Key).Select(pair => $"{pair.Key}{pair.Value}"));

            Console.WriteLine(result);
        }
    }
}
