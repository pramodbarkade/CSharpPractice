namespace CSharpPractice.CodingProblems;

[PracticeProgram("Coding Problems", "Anagram finder sample")]
public sealed class AnagramFinderSample : IPracticeProgram
{
    public void Run()
    {
        Console.WriteLine(string.Join(", ", AnagramFinder.FindAnagramsGroups(["eat", "ate", "tea", "joe"])));
    }
}

[PracticeProgram("Coding Problems", "Character frequency sample")]
public sealed class CharacterFrequencySample : IPracticeProgram
{
    public void Run()
    {
        new CharacterFrequency().CharacterFrequencyCount();
    }
}

[PracticeProgram("Coding Problems", "Array reduction sample")]
public sealed class ArrayReductionSample : IPracticeProgram
{
    public void Run()
    {
        new ArrayReduction().ArrayReductionProgram();
    }
}

[PracticeProgram("Coding Problems", "Duplicate characters sample")]
public sealed class DuplicateCharactersSample : IPracticeProgram
{
    public void Run()
    {
        Find_duplicate_characters_in_a_string.Start("programming");
    }
}

[PracticeProgram("Coding Problems", "First non-repeating character sample")]
public sealed class FirstNonRepeatingCharacterSample : IPracticeProgram
{
    public void Run()
    {
        Find_the_first_character_that_appears_only_once_in_a_given_string.Start("swiss");
    }
}

[PracticeProgram("Coding Problems", "Missing number sample")]
public sealed class MissingNumberSample : IPracticeProgram
{
    public void Run()
    {
        Find_the_Missing_Number_in_an_Array.Start([10, 15, 14, 11, 13]);
    }
}

[PracticeProgram("Coding Problems", "Duplicate number sample")]
public sealed class DuplicateNumberSample : IPracticeProgram
{
    public void Run()
    {
        Find_Duplicate_Number_in_an_Array.Start([10, 15, 14, 11, 13, 15]);
    }
}

[PracticeProgram("Coding Problems", "Two sum sample")]
public sealed class TwoSumSample : IPracticeProgram
{
    public void Run()
    {
        Find_Two_Numbers_Whose_Sum_Equals_Target.Start([10, 6, 15, 3, 7, 20], 13);
    }
}

[PracticeProgram("Coding Problems", "Move zeroes sample")]
public sealed class MoveZeroesSample : IPracticeProgram
{
    public void Run()
    {
        Move_All_Zeros_To_End_Of_Array.Start([10, 9, 0, 5, 4, 0, 6, 8]);
    }
}

[PracticeProgram("Coding Problems", "Second largest sample")]
public sealed class SecondLargestSample : IPracticeProgram
{
    public void Run()
    {
        Second_Largest_Number_Without_Sorting.Start([10, 12, 61, 18, 23, 40, 51]);
    }
}
