using System.Runtime.InteropServices;

namespace PasswordExcercise
{
    public class PasswordRequirements
	{
		public int MaxLength { get; set; }
		public int MinLength { get; set; }
		public int MinUpperAlphaChars { get; set; }
		public int MinLowerAlphaChars { get; set; }
		public int MinNumericChars { get; set; }
		public int MinSpecialChars { get; set; }

		public PasswordRequirements()
		{
			int summedCharRequirementLength = this.MinLowerAlphaChars + this.MinNumericChars + this.MinUpperAlphaChars + this.MinSpecialChars;
			if (this.MinLength < summedCharRequirementLength)
			{

			}
		}
	}
}
