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
      expectedReturn.Add("BEARD");
      Assert.Equal(expectedReturn, newWord.IsAnagram());
    }

    [Fact]
    public void IsAnagram_ForListOfWordsWithASingleMatch_BEARD()
    {
      Anagram newWord = new Anagram("Bread");
      newWord.AddToPotentialList("beard");
      newWord.AddToPotentialList("bottle");
      List<string> expectedReturn = new List<string>{};
      expectedReturn.Add("BEARD");
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
      expectedReturn.Add("BEARD");
      expectedReturn.Add("DEBRA");
      expectedReturn.Add("BARED");
      Assert.Equal(expectedReturn, newWord.IsAnagram());
    }
  }
}
