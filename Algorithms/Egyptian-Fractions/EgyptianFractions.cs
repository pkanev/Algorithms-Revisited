namespace Egyptian_Fractions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class EgyptianFractions
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var numbers = input
                .Split('/')
                .Select(n => double.Parse(n.Trim()))
                .ToArray();
            var numerator = numbers[0];
            var denominator = numbers[1];

            if (numerator >= denominator)
            {
                Console.WriteLine("Error (fraction is equal to or greater than 1)");
                return;
            }

            var testDenominator = 2D;
            var targetValue = numerator / denominator;
            var latestValue = 0D;
            var fractions = new List<string>();

            while (latestValue <= targetValue)
            {
                if (latestValue + (1 / testDenominator) <= targetValue)
                {
                    latestValue += 1 / testDenominator;
                    fractions.Add(string.Format("1/{0}", testDenominator));
                }

                testDenominator++;
                if (testDenominator > 5000000D)
                {
                    break;
                }
            }

            Console.WriteLine("{0} = {1}", input, string.Join(" + ", fractions));
        }
    }
}
