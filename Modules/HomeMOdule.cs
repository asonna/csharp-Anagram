using Nancy;
using System.Collections.Generic;
using TheAnagram.Objects;

namespace TheAnagram
{
	public class HomeModule : NancyModule
	{
		public HomeModule()
		{
			Get["/"] = _ =>
			{
				return View["index.cshtml"];
			};
			Post["/result"] = _ =>
			{
				Anagram newWord = new Anagram(Request.Form["originalWord"]);
				string word1 = Request.Form["anagram1"];
				if (word1 != "")
				{
					newWord.AddToPotentialList(word1);
				}
				string word2 = Request.Form["anagram2"];
				if (word2 != "")
				{
					newWord.AddToPotentialList(word2);
				}
				string word3 = Request.Form["anagram3"];
				if (word3 != "")
				{
					newWord.AddToPotentialList(word3);
				}
				return View["result.cshtml", newWord];
			};
		}
	}
}
