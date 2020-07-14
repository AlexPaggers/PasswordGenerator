using System.Linq;
using NUnit.Framework;

namespace PasswordExcercise.Tests
{
	public class PasswordGeneratorTests
	{
		[Test]
		public void TestGenerateLengthOnly()
		{
			PasswordGenerator generator = new PasswordGenerator();

			string result = generator.GeneratePassword(new PasswordRequirements()
			{
				MaxLength = 16,
				MinLength = 8,
			});

			Assert.That(result.Length, Is.AtMost(16));
			Assert.That(result.Length, Is.AtLeast(8));
		}

		[Test]
		public void TestGenerateAllRequirements()
		{
			PasswordGenerator generator = new PasswordGenerator();

			string result = generator.GeneratePassword(new PasswordRequirements()
			{
				MaxLength = 16,
				MinLength = 8,
				MinLowerAlphaChars = 1,
				MinUpperAlphaChars = 1,
				MinNumericChars = 1,
				MinSpecialChars = 1
			});

			Assert.That(result.Length, Is.AtMost(16));
			Assert.That(result.Length, Is.AtLeast(8));
			Assert.IsTrue(result.Any(char.IsUpper));
			Assert.IsTrue(result.Any(char.IsLower));
			Assert.IsTrue(result.Any(char.IsNumber));
			Assert.IsTrue(result.Any(char.IsSymbol) || result.Any(char.IsPunctuation));
		}

		[Test]
		public void TestGenerateAllRequirments_Multiple()
		{
			PasswordGenerator generator = new PasswordGenerator();

			string result = generator.GeneratePassword(new PasswordRequirements()
			{
				MaxLength = 8,
				MinLength = 8,
				MinLowerAlphaChars = 2,
				MinUpperAlphaChars = 2,
				MinNumericChars = 2,
				MinSpecialChars = 2
			});

			Assert.That(result.Length, Is.EqualTo(8));
			Assert.That(result.Where(char.IsUpper).Count(), Is.EqualTo(2));
			Assert.That(result.Where(char.IsLower).Count(), Is.EqualTo(2));
			Assert.That(result.Where(char.IsNumber).Count(), Is.EqualTo(2));

			int countSpecial = result.Count(char.IsSymbol) + result.Count(char.IsPunctuation);
			Assert.That(countSpecial, Is.EqualTo(2));
		}
	}
}
