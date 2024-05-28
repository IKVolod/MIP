using System;
using System.Linq;

namespace Lab_3
{
    abstract class Program
    {
        static void Main()
        {
            string[] jobs = { "0/12", "4/10", "6/5", "11/8", "14/6", "18/5" };
            Console.WriteLine(CalculateProductivity(jobs));
        }

        static double CalculateProductivity(string[] jobs)
        {
            int[] intervals = new int[jobs.Length - 1];
            int[] durations  = new int[jobs.Length];
            
            durations [0] = Convert.ToInt32(jobs[0].Split('/')[0]) + Convert.ToInt32(jobs[0].Split('/')[1]);

            for (int i = 1; i < jobs.Length; i++)
            {
                string[] parts = jobs[i].Split('/');
                int currentJobEnds = Convert.ToInt32(parts[0]) + Convert.ToInt32(parts[1]);
                
                durations [i] = currentJobEnds;
            }

            Array.Sort(durations);

            for (int i = 0; i < durations .Length - 1; i++)
            {
                intervals[i] = Math.Abs(durations [i] - durations [i + 1]);
            }

            double intervalAverage = intervals.Average();

            return 1 / intervalAverage;
        }
    }
}