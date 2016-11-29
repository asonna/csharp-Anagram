using System.Collections.Generic;
using System;
using System.Linq;

namespace TheAnagram.Objects
{
	public class Anagram
	{
		private List<char> _letters = new List<char>{};
		private List<string> _potentialAnagrams = new List<string>{};
		private static List<string> _allWords = new List<string>{};

		public Anagram(string word)
		{
			_letters = word.ToUpper().ToCharArray().ToList();
			_letters.Sort();
		}

		public void AddToPotentialList(string word)
		{
			_potentialAnagrams.Add(word);
		}

		public List<string> GetPotentialAnagrams()
		{
			return _potentialAnagrams;
		}

		public bool IsAnagram()
		{
			bool isAnagram = true;
			List<char> newWordLetters = _potentialAnagrams[0].ToUpper().ToCharArray().ToList();
			if (newWordLetters.Count != _letters.Count)
			{
				isAnagram = false;
				return isAnagram;
			}
			else
			{
				newWordLetters.Sort();
				for (int index = 0; index < _letters.Count; index++)
				{
					if (_letters[index] != newWordLetters[index])
					{
						Console.WriteLine(_letters.Count);
						Console.WriteLine(newWordLetters.Count);
						isAnagram = false;
						break;
					}
				}
				return isAnagram;
			}
		}
	}
}
