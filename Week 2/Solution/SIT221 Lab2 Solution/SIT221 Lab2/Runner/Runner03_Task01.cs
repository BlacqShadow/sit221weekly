﻿using System;
using DataStructures_Algorithms.Week03;
namespace Runner
{
	public class Runner03_Task01 : IRunner
	{
		public Runner03_Task01()
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


			//after you have implemented the ListEnumerator Class, this would work
			foreach(int i in list)
				Console.WriteLine(i);
		}
	}
}
