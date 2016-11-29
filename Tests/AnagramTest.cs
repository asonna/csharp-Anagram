using Xunit;

namespace TheAnagram.Objects
{
  public class AnagramTest
  {
    [Fact]
    public void IsAnagram_ForSingleWord_true()
    {
      Anagram newWord = new Anagram("Bread");
      newWord.AddToPotentialList("Beard");
      Assert.Equal(true, newWord.IsAnagram());
    }
  }
}
