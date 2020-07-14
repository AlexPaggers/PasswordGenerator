using PasswordExcercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordExercise
{
    class StringRequirementChecker
    {
		private string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		private string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
		private string numbericChars = "1234567890";
		private string symbolChars = "!\"£$%^&*()-_+=¬¦`{}[]:;@'~#,.<>?/|\\";

		public CheckResult CheckStringRequirements(PasswordRequirements requirements, string currentString)
		{
			if (CountInstancesOfListItemsInString(uppercaseChars, currentString) < requirements.MinUpperAlphaChars)
			{
				return CheckResult.Fail(ErrorMessage.TooFewUppercase);
			}
			if (CountInstancesOfListItemsInString(lowercaseChars, currentString) < requirements.MinLowerAlphaChars)
			{
				return CheckResult.Fail(ErrorMessage.TooFewLowercase);
			}
			if (CountInstancesOfListItemsInString(numbericChars, currentString) < requirements.MinNumericChars)
			{
				return CheckResult.Fail(ErrorMessage.TooFewNumeric);
			}
			if (CountInstancesOfListItemsInString(symbolChars, currentString) < requirements.MinSpecialChars)
			{
				return CheckResult.Fail(ErrorMessage.TooFewSpecial);
			}
			if (currentString.Length < requirements.MinLength)
			{
				return CheckResult.Fail(ErrorMessage.TooShort);
			}
			if (currentString.Length > requirements.MaxLength)
			{
				return CheckResult.Fail(ErrorMessage.TooLong);
			}

			return CheckResult.Success();
		}

		private int CountInstancesOfListItemsInString(string list, string currentString)
		{
			return currentString.Intersect(list).Count();
		}
	}
}
