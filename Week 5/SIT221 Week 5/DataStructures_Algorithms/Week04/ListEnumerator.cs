using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures_Algorithms.Week04
{
	public class ListEnumerator<T> : IEnumerator<T>
	{
		LinkedList<T> list;
		Node<T> head;
		T current = default(T);
        int position = -1;

		public ListEnumerator(LinkedList<T> LinkedList)
		{
			list = LinkedList;
			head = list.Head;
            current = default(T);
		}

		//Advances the enumerator to the next element of the collection
		//adjust your pointer to the next node, and adjust current field accordingly
		//if no elements remaining (head.next == null) you should return false
		//otherwise advance your head to the next node
		public bool MoveNext()
		{
            position++;
            return (position < list.Count);
		}

		public void Reset()
		{
			head = list.Head;
			current = default(T);
            position = -1;
		}

		public T Current
		{
			get
			{
                current = list.ElementAt(position);
                return  current;
			}
		}

		object IEnumerator.Current
		{
			get
			{
				return current;
			}
		}

		public void Dispose()
		{
			
		}
	}
}