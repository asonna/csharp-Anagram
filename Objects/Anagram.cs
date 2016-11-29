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
				string tempWord = "";
				List<string> newWordLetters = new List<string>{};
				Char[] charArray = word.ToCharArray();
				foreach (char letter in charArray)
				{
					newWordLetters.Add(letter.ToString());
				}
				foreach (string letter in newWordLetters)
				{
					tempWord += letter.ToString();
				}

				bool isAnagram = true;

				Dictionary<string, int> originalLetters = new Dictionary<string, int>();
				Dictionary<string, int> testLetters = new Dictionary<string, int>();

				//add letters from original word to original word dictionary
				foreach (string letter in _letters)
				{
					if (!(originalLetters.ContainsKey(letter)) && letter != " ")
					{
						originalLetters[letter.ToUpper()] = 1;
					}
					else if (letter != " ")
					{
						originalLetters[letter.ToUpper()]++;
					}
				}

				//add letters from test word to test word dictionary
				foreach (string letter in newWordLetters)
				if (!(testLetters.ContainsKey(letter)) && letter != " ")
				{
					testLetters[letter.ToUpper()] = 1;
				}
				else if (letter != " ")
				{
					testLetters[letter.ToUpper()]++;
				}

				//check to see if original word fits in test word
				foreach (string letter in originalLetters.Keys)
				{
					if (testLetters.ContainsKey(letter))
					{
						if (testLetters[letter] < originalLetters[letter])
						{
							isAnagram = false;
							break;
						}
					}
					else
					{
						isAnagram = false;
						break;
					}
				}

				//check to see if test word fits in original word
				if (isAnagram)
				{
					anagramList.Add(tempWord);
				}
				else
				{
					isAnagram = true;
					foreach (string letter in testLetters.Keys)
					{
						if (originalLetters.ContainsKey(letter))
						{
							if (originalLetters[letter] < testLetters[letter])
							{
								isAnagram = false;
								break;
							}
						}
						else
						{
							isAnagram = false;
							break;
						}
					}
					if (isAnagram)
					{
						anagramList.Add(tempWord);
					}
					originalLetters.Clear();
					testLetters.Clear();
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
