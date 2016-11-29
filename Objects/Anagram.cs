using System.Collections.Generic;
using System;
using System.Linq;

namespace TheAnagram.Objects
{
	public class Anagram
	{
		private List<string> _letters = new List<string>{};
		private string _originalWord;
		private List<string> _potentialAnagrams = new List<string>{};
		private static List<string> _allWords = new List<string>{};

		public Anagram(string word)
		{
			_originalWord = word;
			Char[] charArray = word.ToUpper().ToCharArray();
			foreach (char letter in charArray)
			{
				_letters.Add(letter.ToString());
			}
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

		public List<string> IsAnagram()
		{
			List<string> anagramList = new List<string>{};

			foreach (string word in _potentialAnagrams)
			{
				List<string> newWordLetters = new List<string>{};
				Char[] charArray = word.ToUpper().ToCharArray();
				foreach (char letter in charArray)
				{
					newWordLetters.Add(letter.ToString());
				}

				if (newWordLetters.Count == _letters.Count)
				{
					string tempWord = "";
					foreach (string letter in newWordLetters)
					{
						tempWord += letter;
					}
					newWordLetters.Sort();
					bool isAnagram = true;
					for (int index = 0; index < _letters.Count; index++)
					{
						if (_letters[index] != newWordLetters[index])
						{
							isAnagram = false;
							break;
						}
					}
					if (isAnagram)
					{
						anagramList.Add(tempWord);
					}
				}
			}
			return anagramList;
		}
	}
}
