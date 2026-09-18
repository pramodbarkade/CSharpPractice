using CSharpPractice.Programs;

namespace CSharpPractice.Tests
{
    public class AnagramFinderTests
    {
        [Fact]
        public void FindAnagrams_ReturnsAnagramWords()
        {
            string[] words = { "eat", "ate", "tea", "joe" };
            var result = AnagramFinder.FindAnagramsGroups(words);
            Assert.Equal(new List<string> { "eat", "ate", "tea" }, result);
        }

        [Fact]
        public void FindAnagrams_WhenNoAnagrams_ReturnsEmptyList()
        {
            string[] words = { "cat", "dog", "fish" };
            var result = AnagramFinder.FindAnagramsGroups(words);
            Assert.Empty(result);
        }

        [Fact]
        public void FindAnagrams_WhenInputIsEmpty_ReturnsEmptyList()
        {
            string[] words = Array.Empty<string>();
            var result = AnagramFinder.FindAnagramsGroups(words);
            Assert.Empty(result);
        }

        [Fact]
        public void FindAnagrams_WhenMultipleGroupsExist_ReturnsAllAnagrams()
        {
            string[] words = { "eat", "ate", "tea", "tan", "nat", "joe" };
            var result = AnagramFinder.FindAnagramsGroups(words);
            Assert.Equal(new List<string> { "eat", "ate", "tea", "tan", "nat" }, result);
        }
    }
}
