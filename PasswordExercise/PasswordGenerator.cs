using System;

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
	}

	public interface IPasswordGenerator
	{
		string GeneratePassword(PasswordRequirements requirements);
	}

	public class PasswordGenerator : IPasswordGenerator
	{
		public string GeneratePassword(PasswordRequirements requirements)
		{
			throw new NotImplementedException();
		}
	}
}
