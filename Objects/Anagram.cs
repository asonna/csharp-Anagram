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
				Char[] charArray = word.ToCharArray();
				foreach (char letter in charArray)
				{
					newWordLetters.Add(letter.ToString());
				}

				string tempWord = "";
				if (newWordLetters.Count == _letters.Count)
				{
					foreach (string letter in newWordLetters)
					{
						tempWord += letter;
					}
					newWordLetters.Sort();
					bool isAnagram = true;
					for (int index = 0; index < _letters.Count; index++)
					{
						if (_letters[index] != newWordLetters[index].ToUpper())
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
				else
				{
					// string originalWordSorted = "";
					// string tempWordUpper = "";
					// foreach (string letter in _letters)
					// {
					// 	originalWordSorted += letter.ToUpper();
					// }
					// foreach (string letter in newWordLetters)
					// {
					// 	tempWord += letter;
					// }
					// tempWordUpper = tempWord.ToUpper();
					// System.Console.WriteLine(tempWord);
					// System.Console.WriteLine(tempWordUpper);
					// System.Console.WriteLine(originalWordSorted);
					// if (originalWordSorted.Contains(tempWord) || tempWord.Contains(originalWordSorted))
					// {
					// 	anagramList.Add(tempWord);
					// }
				}
			}
			return anagramList;
		}

		public string GetWord()
		{
			return _originalWord;
		}
	}
}
