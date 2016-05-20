namespace Binomial_Coefficients
{
    using System;
    using System.Numerics;

    class Binomials
    {
        private static BigInteger[] factorials;
        private static BigInteger[,] binomials;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            factorials = new BigInteger[n + 1];
            binomials = new BigInteger[n + 1, n + 1];

            BigInteger binomial = CalculateBinomialCoefficient(n, k);
            Console.WriteLine(binomial);
        }

        private static BigInteger CalculateBinomialCoefficient(int n, int k)
        {
            if (binomials[n, k] != 0)
            {
                return binomials[n, k];
            }

            BigInteger b;
            if (n <= 2 && k <= 1)
            {
                b = 1;
            }
            else
            {
                b = Calculatefactorial(n)/(Calculatefactorial(k) * Calculatefactorial(n-k));
            }

            return b;
        }

        private static BigInteger Calculatefactorial(int i)
        {
            if (factorials[i] != 0)
            {
                return factorials[i];
            }

            if (i == 1 || i == 0)
            {
                return 1;
            }
            else
            {
                BigInteger result = i*Calculatefactorial(i - 1);
                factorials[i] = result;
                return result;
            }
        }
    }
}
