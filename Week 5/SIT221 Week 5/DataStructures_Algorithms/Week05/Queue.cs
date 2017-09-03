using System;
using System.Collections.Generic;

namespace DataStructures_Algorithms.Week05
{
	public class Queue<T>
	{
		IList<T> data = null;
		public Queue()
		{
			data = new LinkedList<T>();
		}
		public Queue(IList<T> datastore)
		{
			data = datastore;
		}

		public void Enque(T element)
		{
            //TODO: Implement Enque method
            //throw new Exception("not implemented");
            //Add element to the end of the vector.
            data.Add(element);
		}
		public T Deque()
		{
            //TODO: Implement Deque method
            //throw new Exception("not implemented");
            T temp = data[0];
            data.RemoveAt(0);
            return temp;
		}

		public int Count { get { return data.Count; } }
	}
}
