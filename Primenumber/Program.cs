﻿namespace Primenumbers
{
    public class Program
    {
        internal static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Bitte eine Priminput eingeben: ");
                var input = Console.ReadLine();
                try
                {
                    if (IsPrimenumber(input))
                    {
                        Console.WriteLine($"Glückwunsch! {input} ist eine Primzahl.");
                    }
                    else
                    {
                        Console.WriteLine($"{input} ist leider keine Primzahl.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Ungueltige Eingabe. Bitte erneut versuchen.");
                }

                Console.WriteLine("Weitere Primzahl pruefen? (j/N)");

                if (Console.ReadLine().Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
            }
        }

        public static bool IsPrimenumber(string? input)
        {
            var number = int.Parse(input);

            if (number < 1)
                throw new ArgumentException("Input must be a positive integer.");

            if (number == 2)
                return true;

            if (number % 2 == 0)
                return false;

            for (int i = 3; i < number; i += 2)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
}