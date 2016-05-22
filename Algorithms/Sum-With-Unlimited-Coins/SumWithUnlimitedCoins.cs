namespace Sum_With_Unlimited_Coins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SumWithUnlimitedCoins
    {
        static void Main()
        {
            int targetSum = int.Parse("S = 6".Substring(4));
            var line = "Coins = {1,2}";
            var coins = line
                .Substring(9, line.Length - 10)
                .Split(',')
                .Select(int.Parse)
                .ToArray();

            var combinationsCount = new int[targetSum + 1];

            // Calculate the number of possible combinations for the first coin (coins[0])
            for (int sum = 0; sum <= targetSum; sum++)
            {
                if (sum % coins[0] == 0)
                {
                    combinationsCount[sum] = 1;
                }
            }

            // Calculate the number of possible combinations for every other coin
            for (int coin = 1; coin < coins.Length; coin++)
            {
                for (int sum = 1; sum <= targetSum; sum++)
                {
                    if (coins[coin] <= sum)
                    {
                        combinationsCount[sum] += combinationsCount[sum - coins[coin]];
                    }
                }
            }


            Console.WriteLine(combinationsCount[targetSum]);
        }
    }
}
