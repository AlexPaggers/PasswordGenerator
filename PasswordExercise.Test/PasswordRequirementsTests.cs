using NUnit.Framework;
using PasswordExcercise;
using System;

namespace PasswordExercise.Test
{
    class PasswordRequirementsTests
    {
        [Test]
        public void A_Set_of_Requirements_Cannot_Have_A_Minumum_Higher_Than_Maximum()
        {
            try
            {
                new PasswordRequirements(minLength: 10, maxLength: 5);
            }
            catch (InvalidOperationException ex)
            {
                Assert.That(ex.Message, Is.EqualTo("Minimum length exceeds maximum length"));
            }
        }

        [Test]
        public void A_Set_of_Requirements_Cannot_Have_A_Sum_of_Minumum_char_values_Higher_Than_Maximum()
        {
            try
            {
                new PasswordRequirements(minLowerAlpha: 2, minNumeric: 2, minUpperAlpha: 2, maxLength: 5);
            }
            catch (InvalidOperationException ex)
            {
                Assert.That(ex.Message, Is.EqualTo("Combined minimum characters exceeds max length"));
            }
        }
    }
}
