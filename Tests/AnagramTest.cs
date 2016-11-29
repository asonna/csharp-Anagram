using Xunit;
using System.Collections.Generic;
using System;

namespace TheAnagram.Objects
{
  public class AnagramTest
  {
    [Fact]
    public void IsAnagram_ForSingleWord_BEARD()
    {
      Anagram newWord = new Anagram("Bread");
      newWord.AddToPotentialList("Beard");
      List<string> expectedReturn = new List<string>{};
      expectedReturn.Add("Beard");
      Assert.Equal(expectedReturn, newWord.IsAnagram());
    }

    [Fact]
    public void IsAnagram_ForListOfWordsWithASingleMatch_BEARD()
    {
      Anagram newWord = new Anagram("Bread");
      newWord.AddToPotentialList("beard");
      newWord.AddToPotentialList("bottle");
      List<string> expectedReturn = new List<string>{};
      expectedReturn.Add("beard");
      Assert.Equal(expectedReturn, newWord.IsAnagram());
    }

    [Fact]
    public void IsAnagram_ForListOfWordsWithNoMatch_EmptyList()
    {
      Anagram newWord = new Anagram("Bread");
      newWord.AddToPotentialList("road");
      newWord.AddToPotentialList("bottle");
      List<string> expectedReturn = new List<string>{};
      Assert.Equal(expectedReturn, newWord.IsAnagram());
    }

    [Fact]
    public void IsAnagram_ForListOfWordsWithMultipleMatches_BeardDebraBared()
    {
      Anagram newWord = new Anagram("Bread");
      newWord.AddToPotentialList("beard");
      newWord.AddToPotentialList("Debra");
      newWord.AddToPotentialList("Bared");
      List<string> expectedReturn = new List<string>{};
      expectedReturn.Add("beard");
      expectedReturn.Add("Debra");
      expectedReturn.Add("Bared");
      Assert.Equal(expectedReturn, newWord.IsAnagram());
    }

    [Fact]
    public void IsAnagram_ForPartialMatches_HatPaths()
    {
      Anagram newWord = new Anagram("Hatp");
      newWord.AddToPotentialList("Hat");
      newWord.AddToPotentialList("Paths");
      List<string> expectedReturn = new List<string>{};
      expectedReturn.Add("Hat");
      expectedReturn.Add("Paths");
      Assert.Equal(expectedReturn, newWord.IsAnagram());
    }
  }
}
