using System;
using System.Runtime.InteropServices;

namespace PasswordExcercise
{
    public class PasswordRequirements
    {
        public int MaxLength { get; }
        public int MinLength { get; }
        public int MinUpperAlphaChars { get; }
        public int MinLowerAlphaChars { get; }
        public int MinNumericChars { get; }
        public int MinSpecialChars { get; }

        public PasswordRequirements(
            int maxLength = 0,
            int minLength = 0,
            int minUpperAlpha = 0,
            int minLowerAlpha = 0,
            int minNumeric = 0,
            int minSpecial = 0)
        {
            this.MaxLength = maxLength;
            this.MinLength = minLength;
            this.MinLowerAlphaChars = minLowerAlpha;
            this.MinUpperAlphaChars = minUpperAlpha;
            this.MinNumericChars = minNumeric;
            this.MinSpecialChars = minSpecial;

            int summedCharRequirementLength = this.MinLowerAlphaChars + this.MinNumericChars + this.MinUpperAlphaChars + this.MinSpecialChars;
            if (this.MaxLength < summedCharRequirementLength)
            {
                throw new InvalidOperationException("Combined minimum characters exceeds max length");
            }

            if (MaxLength < MinLength)
            {
                throw new InvalidOperationException("Minimum length exceeds maximum length");
            }
        }
    }
}
