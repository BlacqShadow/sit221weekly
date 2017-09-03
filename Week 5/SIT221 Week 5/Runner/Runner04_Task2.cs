using System;
using DataStructures_Algorithms.Week04;
namespace Runner
{
	public class Runner04_Task2 : IRunner
	{
		public Runner04_Task2()
		{
		}

		public void Run(string[] args)
		{
			//Note: args[0] is the input file name -- make sure to change it as needed, currently 1H.txt
			if (args.Length < 1)
			{
				Console.WriteLine("input file name is missing");
				return;
			}
            
            LinkedList<int> list = null;
			LinkedListSerializer<int>.LoadLinkedListFromTextFile(args[0], ref list);

			//let's display list elements
			Console.WriteLine(string.Format("the list loaded from {0} file has {1} elements", args[0], list.Count));
			for (int i = 0; i < list.Count; i++)
			{
				Console.WriteLine(list[i]); // not a very good solution, if you want to improve, try 
			}

			//now let's try to add one more element at the end
			list.Add(9999);

			//let's check the count, should be +1, also let's display the last element in the list
			Console.WriteLine(string.Format("count = {0}, and last element = {1}",list.Count , list[list.Count - 1]));

			//let's find the index of 9999
			Console.WriteLine(string.Format("element = {0}, found at position {1}", 9999 , list.IndexOf(9999)));

			//let's remove 9999
			list.Remove(9999);
			Console.WriteLine(string.Format("element {0}, was removed successfully ", 9999));

			//let's check the count, should be -1
			Console.WriteLine(string.Format("count = {0}, and last element = {1}", list.Count, list[list.Count - 1]));

            // test IndexOf
            int index = list.IndexOf(1000); // this should return -1;
            if (index != -1)
                Console.WriteLine("IndexOf is not working correctly!");
            else
                Console.WriteLine("IndexOf is working correctly!");

            index = list.IndexOf(6); // this should return 2;
            if (index != 2)
                Console.WriteLine("IndexOf is not working correctly!");
            else
                Console.WriteLine("IndexOf is working correctly!");

            // test RemoveAt
            index = 0;
            list.RemoveAt(index);
            Console.WriteLine(string.Format("After removing the element at index {0}, the list has {1} elements as follows", index, list.Count));
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]); // not a very good solution, if you want to improve, try 
            }
            index = 2;
            list.RemoveAt(index);
            Console.WriteLine(string.Format("After removing the element at index {0}, the list has {1} elements as follows", index, list.Count));
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]); // not a very good solution, if you want to improve, try 
            }

            // test Insert
            index = 0;
            list.Insert(100, index);
            Console.WriteLine(string.Format("After inserting an element at index {0}, the list has {1} elements as follows", index, list.Count));
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]); // not a very good solution, if you want to improve, try 
            }
            index = 3;
            list.Insert(200, index);
            Console.WriteLine(string.Format("After inserting an element at index {0}, the list has {1} elements as follows", index, list.Count));
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]); // not a very good solution, if you want to improve, try 
            }


            // test foreach
            //after you have implemented the ListEnumerator Class, this would work
            Console.WriteLine("Using foreach");
            foreach(int i in list)
            	Console.WriteLine(i);

            Console.ReadLine();
        }
    }
}