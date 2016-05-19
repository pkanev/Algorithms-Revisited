namespace Binomial_Coefficients
{
    using System;

    class Binomials
    {
        private static int[] factorials;
        private static int[,] binomials;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            factorials = new int[n + 1];
            binomials = new int[n + 1, n + 1];

            int binomial = CalculateBinomialCoefficient(n, k);
            Console.WriteLine(binomial);
        }

        private static int CalculateBinomialCoefficient(int n, int k)
        {
            if (binomials[n, k] != 0)
            {
                return binomials[n, k];
            }

            int b;
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

        private static int Calculatefactorial(int i)
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
                int result = i*Calculatefactorial(i - 1);
                factorials[i] = result;
                return result;
            }
        }
    }
}
