namespace Fractional_Knapsack_Problem
{
    using System;
    using System.Collections.Generic;

    class FractionalKnapsackProblem
    {
        static void Main()
        {
            double capacity = int.Parse(Console.ReadLine().Substring(10));
            int itemCount = int.Parse(Console.ReadLine().Substring(7));
            var items = new Item[itemCount];
            for (int i = 0; i < itemCount; i++)
            {
                var tokens = Console.ReadLine().Split(new[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                var price = int.Parse(tokens[0]);
                var weight = int.Parse(tokens[1]);
                items[i] =new Item(price, weight);
            }
            Array.Sort(items);

            var usedWeight = 0D;
            var currentItemIndex = 0;
            var totalPrice = 0M;

            while (usedWeight < capacity && currentItemIndex < itemCount)
            {
                var lastSelectedItem = items[currentItemIndex];
                var availableCapacity = capacity - usedWeight;
                if (availableCapacity > lastSelectedItem.Weight)
                {
                    totalPrice += lastSelectedItem.Price;
                    usedWeight += lastSelectedItem.Weight;
                    Console.WriteLine("Take 100% of item with price {0:F2} and weight {1:F2}",
                        lastSelectedItem.Price, lastSelectedItem.Weight);
                }
                else
                {
                    var ratio = (decimal)(availableCapacity / lastSelectedItem.Weight);
                    totalPrice += lastSelectedItem.Price * ratio;
                    usedWeight += availableCapacity;
                    Console.WriteLine("Take {2:F2}% of item with price {0:F2} and weight {1:F2}",
                        lastSelectedItem.Price, lastSelectedItem.Weight, ratio * 100);
                }

                currentItemIndex++;
            }

            Console.WriteLine("Total price: {0:F2}", totalPrice);
        }
    }

    internal class Item : IComparable<Item>
    {
        public Item(decimal price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        public decimal Price { get; set; }
        public double Weight { get; set; }

        public int CompareTo(Item other)
        {
            return -1 * (this.Price/(decimal) this.Weight).CompareTo(other.Price/(decimal) other.Weight);
        }
    }
}
