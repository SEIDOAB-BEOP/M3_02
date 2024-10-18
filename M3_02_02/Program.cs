using System;

namespace BOOPM3_02_02
{
    class Program
    {
		class SecretMemberClub {
			private string [] _members  = { "Harry Potter", "Darth Vader", "Fred Flintstone", "Frodo Baggins"};
			public string this[int idx] => _members[idx];
		}

		class FoldedSentence
		{
			string[] words = "a default sentence".Split();
			public string Sentence
			{
				init => words = value.Split();
			}
			public int Length
			{
				get
				{
					if (words.Length % 2 == 0) return words.Length / 2;
					return words.Length / 2 + 1;
				}
			}
		
			public (string, string) this[int idx] // indexer
			{
				get
				{
					if (idx >= Length) throw new IndexOutOfRangeException();

					return (words[idx], words[words.Length - 1 - idx]);
				}
			}
		}
		static void Main(string[] args)
        {
			System.Console.WriteLine("\nExample SecretMemberClub");
			var club = new SecretMemberClub();
			System.Console.WriteLine(club[0]);
			System.Console.WriteLine(club[1]);
			System.Console.WriteLine(club[2]);
			System.Console.WriteLine(club[3]);

			//Ex 1:
			//club._members = null;  //Not possibe
			//club._members[0] = "Donald Duck"; //not possible
			//club._members[0] = null; //not possible

			System.Console.WriteLine("\nExample FoldedSentences");
			var s1 = new FoldedSentence();
			Console.WriteLine(s1.Length);   // 2
			Console.WriteLine(s1[0]);       // (a, sentence)
			Console.WriteLine(s1[1]);       // (default, default)

			var s2 = new FoldedSentence { Sentence = "The quick brown fox catches the white rabbit" };
			Console.WriteLine(s2.Length);   // 4
			for (int i = 0; i < s2.Length; i++)
			{
				Console.WriteLine(s2[i]);   // (The, rabbit) (quick, white) (brown, the) (fox, catches)
			}
		}
	}
}
//Excercises SecretMemberClub:
//1. 	Make _members public and try the codelines above marked Ex1.
//2. 	Make _members public, get only and try the codelines above marked Ex1.

//Excercises FoldedSentence:
//3.	Go through the code of FoldedSentence indexer with a debugger and understand how the folded sentence evolvs. 