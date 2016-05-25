namespace Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Salaries
    {
        private static List<int>[] employeeToManagerGraph;
        private static int[] subordinates;
        private static long[] salaries;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            employeeToManagerGraph = new List<int>[n]; // shows direct managers
            subordinates = new int[n]; //# of people managed by every employee
            salaries = new long[n];

            for (int i = 0; i < n; i++)
            {
                if (employeeToManagerGraph[i] == null)
                {
                    employeeToManagerGraph[i] = new List<int>();
                }

                var input = Console.ReadLine().ToCharArray();
                for (int j = 0; j < n; j++)
                {
                    if (input[j] == 'Y')
                    {
                        if (employeeToManagerGraph[j] == null)
                        {
                            employeeToManagerGraph[j] = new List<int>();
                        }

                        employeeToManagerGraph[j].Add(i);
                        subordinates[i]++;
                    }
                }

                // regular employees get a salary of 1
                if (subordinates[i] == 0)
                {
                    salaries[i] = 1;
                }
            }

            CalculateSalary();
            Console.WriteLine(salaries.Sum());
        }

        private static void CalculateSalary()
        {
            int index = Array.IndexOf(subordinates, 0);
            while (index != -1)
            {
                subordinates[index]--;

                foreach (var manager in employeeToManagerGraph[index])
                {
                    subordinates[manager]--;
                    salaries[manager] += salaries[index];
                }

                index = Array.IndexOf(subordinates, 0);
            }
        }
    }
}
