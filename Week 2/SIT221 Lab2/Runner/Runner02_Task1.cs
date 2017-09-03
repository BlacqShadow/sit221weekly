using DataStructures_Algorithms.Week02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runner
{
    class  Runner02_Task1 : IRunner 
    {
        public void Run(string[] args)
        {
            //Note: args[0] is the input file name -- make sure to change it as needed, currently 1H.txt
            if (args.Length < 1)
            {
                Console.WriteLine("input file name is missing");
                return;
            }
            Vector<int> vector = null;

            string inputFileName = args[0];
            string outputFileName = "S_1H.txt";
            DataSerializer<int>.LoadVectorFromTextFile(inputFileName, ref vector);

            if (vector == null)
            {
                Console.WriteLine("Failed to load data from input file");
                return;
            }

            //let's check the capacity & count now
            Console.WriteLine("Vector Capacity is {0}", vector.Capacity);
            Console.WriteLine("Vector Count is {0}", vector.Count);

            //Let's sort Vector elements ascending?
            // Task 1 c

            vector.Sort();
            Console.WriteLine("Data has been sorted");
            DataSerializer<int>.SaveVectorToTextFile(outputFileName, vector);
            Console.WriteLine( string.Format("Data has been stored to {0}", outputFileName));

            Console.Read();
        }
    }
}
