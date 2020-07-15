using System.Linq;
using NUnit.Framework;

namespace PasswordExcercise.Tests
{
    public class PasswordGeneratorTests
    {
        [Test]
        public void A_generated_password_will_be_between_the_minimum_and_maximum_length()
        {
            PasswordGenerator generator = new PasswordGenerator();

            string result = generator.GeneratePassword(new PasswordRequirements(
                maxLength: 16,
                minLength: 8
            ));

            Assert.That(result.Length, Is.AtMost(16));
            Assert.That(result.Length, Is.AtLeast(8));
        }

        [Test]
        public void A_generated_password_will_meet_all_requirements()
        {
            PasswordGenerator generator = new PasswordGenerator();

            string result = generator.GeneratePassword(new PasswordRequirements(
                maxLength: 8,
                minLength: 8,
                minLowerAlpha: 2,
                minUpperAlpha: 2,
                minNumeric: 2,
                minSpecial: 2
            ));

            Assert.That(result.Length, Is.EqualTo(8));
            Assert.That(result.Where(char.IsUpper).Count(), Is.EqualTo(2));
            Assert.That(result.Where(char.IsLower).Count(), Is.EqualTo(2));
            Assert.That(result.Where(char.IsNumber).Count(), Is.EqualTo(2));

            int countSpecial = result.Count(char.IsSymbol) + result.Count(char.IsPunctuation);
            Assert.That(countSpecial, Is.EqualTo(2));
        }
    }
}
