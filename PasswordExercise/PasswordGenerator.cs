using System;
using System.Linq;
using System.Text;

namespace PasswordExcercise
{
	public class PasswordGenerator : IPasswordGenerator
	{
		private Random random;

		private string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		private string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
		private string numbericChars = "1234567890";
		private string symbolChars = "!\"£$%^&*()-_+=¬¦`{}[]:;@'~#,.<>?/|\\";
		public PasswordGenerator()
		{
			random = new Random((int)DateTime.Now.Ticks);
		}

		public string GeneratePassword(PasswordRequirements requirements)
		{
			StringBuilder stringBuilder = new StringBuilder(new String(' ', random.Next(requirements.MinLength, requirements.MaxLength)));
			int stringIterator = 0;

			// Add lowercase chars
			for (int i = 0; i < requirements.MinLowerAlphaChars; i++)
			{
				stringBuilder[stringIterator] = GenerateCharFromString(lowercaseChars);
				stringIterator++;
			}

			// Add uppercase chars
			for (int i = 0; i < requirements.MinUpperAlphaChars; i++)
			{
				stringBuilder[stringIterator] = GenerateCharFromString(uppercaseChars);
				stringIterator++;
			}

			// Add numeric chars
			for (int i = 0; i < requirements.MinNumericChars; i++)
			{
				stringBuilder[stringIterator] = GenerateCharFromString(numbericChars);
				stringIterator++;
			}

			// Add symbols
			for (int i = 0; i < requirements.MinSpecialChars; i++)
			{
				stringBuilder[stringIterator] = GenerateCharFromString(symbolChars);
				stringIterator++;
			}

			// Fill in missing chars
			for (int i = stringIterator; i < stringBuilder.Length; i++)
			{
				stringBuilder[stringIterator] = GenerateCharFromString(symbolChars + numbericChars + uppercaseChars + lowercaseChars);
				stringIterator++;
			}

			// Shuffle the chars
			string shuffledString = ShuffleString(stringBuilder.ToString());

			return shuffledString;
		}

		private string ShuffleString(String unshuffledString, int shuffleFactor = 7)
		{
			var charlist = unshuffledString.ToList();
			for (int i = 0; i < shuffleFactor; i++)
			{
				charlist.OrderBy(c => random.Next()).ToList();
			}
			return new String(charlist.ToArray());
		}

		private char GenerateCharFromString(string list)
		{
			return list[random.Next(list.Length)];
		}

		private int CountInstancesOfListItemsInString(string list, string currentString)
		{
			return currentString.Intersect(list).Count();
		}
	}
}