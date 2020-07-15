using System;
using PasswordExcercise;

namespace PasswordGeneratorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfGenerations = 50;

            var generator = new PasswordGenerator();
            var requirements = new PasswordRequirements(
                minLength: 8,
                maxLength: 16,
                minLowerAlpha: 2,
                minUpperAlpha: 2,
                minNumeric: 2,
                minSpecial: 2);

            for (int i = 0; i < numberOfGenerations; i++)
            {
                Console.WriteLine(generator.GeneratePassword(requirements));
            }
        }
    }
}