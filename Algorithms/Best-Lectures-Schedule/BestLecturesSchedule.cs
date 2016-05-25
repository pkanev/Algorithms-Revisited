namespace Best_Lectures_Schedule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BestLecturesSchedule
    {
        static void Main()
        {
            var lecturesCount = int.Parse(Console.ReadLine().Substring(10));
            var lectures = new List<Lecture>();

            for (int i = 0; i < lecturesCount; i++)
            {
                var tokens = Console.ReadLine().Split(':');
                var courseName = tokens[0].Trim();
                var duration = tokens[1]
                    .Split('-')
                    .Select(d => int.Parse(d.Trim()))
                    .ToArray();
                var start = duration[0];
                var end = duration[1];
                lectures.Add(new Lecture(courseName, start, end));
            }

            lectures.Sort();
            var selectedLectures = new List<Lecture>();

            var lastSelectedActivity = lectures[0];
            selectedLectures.Add(lastSelectedActivity);

            foreach (var lecture in lectures)
            {
                if (lecture.Start >= lastSelectedActivity.End)
                {
                    // Activities are compatible
                    lastSelectedActivity = lecture;
                    selectedLectures.Add(lastSelectedActivity);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Lectures ({0}):", selectedLectures.Count);
            foreach (var lecture in selectedLectures)
            {
                Console.WriteLine(lecture);
            }
        }
    }
}
