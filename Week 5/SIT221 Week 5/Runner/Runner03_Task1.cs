using DataStructures_Algorithms.Week03;
using System;
using System.Diagnostics;

namespace Runner
{
	public class Runner03_Task1 : IRunner
	{
		public Runner03_Task1()
		{
		}

		public void Run(string[] args)
		{
            if (args.Length < 2)
            {
                Console.WriteLine("Expected two params");
                return;
            }

            string inputFilename = "../../Data/Week01/" + args[0];
            SortingAlgorithm sortingAlgorithm = (SortingAlgorithm)Enum.Parse(typeof(SortingAlgorithm), args[1]);
            string outputFilename = "../../Data/Week01/" + args[1] + "_" + args[0];

            Vector<int> vector = null;
            DataSerializer<int>.LoadVectorFromTextFile(inputFilename, ref vector);

            if (vector == null)
            {
                Console.WriteLine("Failed to load data from input file");
                return;
            }

            //let's check the capacity & count now
            Console.WriteLine("Vector Capacity is {0}", vector.Capacity);
            Console.WriteLine("Vector Count is {0}", vector.Count);


            //Let's sort Vector elements ascending?

            var memBefore = Process.GetCurrentProcess().WorkingSet64;
            Stopwatch s = new Stopwatch();
            s.Start();

            vector.Sort(sortingAlgorithm); //This is the same as calling vector.Sort with an ascending order comparer

            s.Stop();
            var memAfter = Process.GetCurrentProcess().WorkingSet64;
            Console.WriteLine("execution time = " + s.ElapsedMilliseconds + ", and memory =" + (memAfter - memBefore) / 1024.0);

            DataSerializer<int>.SaveVectorToTextFile(outputFilename, vector);

            Console.ReadLine();
        }
	}
}