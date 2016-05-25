namespace Processor_Scheduling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ProcessorScheduling
    {
        static void Main()
        {
            var taskCount = int.Parse(Console.ReadLine().Substring(7));
            var tasks = new List<Task>();
            var maxTasksToBePerformed = int.MinValue;

            for (int i = 1; i <= taskCount; i++)
            {
                var tokens = Console.ReadLine().Split('-').Select(t => int.Parse(t.Trim())).ToArray();
                var value = tokens[0];
                var deadline = tokens[1];
                if (deadline > maxTasksToBePerformed)
                {
                    maxTasksToBePerformed = deadline;
                }

                tasks.Add(new Task(i, value, deadline));
            }

            FindSchedule(tasks, maxTasksToBePerformed);
        }

        private static void FindSchedule(List<Task> tasks, int maxTasksToBePerformed)
        {
            var selectedTasks = new int[maxTasksToBePerformed];
            var totalValue = 0;
            for (int currentStep = maxTasksToBePerformed - 1; currentStep >= 0; currentStep--)
            {
                var step = currentStep;
                var bestTask = tasks.Where(t => t.Deadline >= step).OrderByDescending(t => t.Value).First();
                totalValue += bestTask.Value;
                selectedTasks[currentStep] = bestTask.Id;
                tasks.Remove(bestTask);
            }

            Console.WriteLine("Optimal schedule:  {0}", string.Join(" -> ", selectedTasks));
            Console.WriteLine("Total value: {0}", totalValue);
        }
    }
}
