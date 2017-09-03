﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures_Algorithms.Week03
{
	public class LinkedList<T> : IEnumerable<T>
	{
		Node<T> headNode = null;

		public Node<T> Head { get { return headNode;} }
		int count = 0;
		public int Count { get { return count; } }

		public LinkedList()
		{
			
		}

		public Node<T> Add(T element)
		{
			Node<T> newNode = new Node<T>(element, null);
			if (headNode == null) //if the list is empty
			{
				headNode = newNode;
			}
			else //if not, then go all the way to the end/last node - a node that has no node in its next field
			{
				Node<T> tempNode = headNode;
				while (tempNode.Next != null)
				{
					tempNode = tempNode.Next;
				}
				tempNode.Next = newNode;
			}

			count++;
			return newNode;
				
		}

		//insert the given element (after you create a node for it), at the specified position
		//make sure to adjust the link of your new node, and the node before your new node
		//Also remember to adjust counter
		public void Insert(T element, int index) 
		{

		}

		//We want to get the index of the specified element
		//see how ElementAt is implemented
		public int IndexOf(T element)
		{
			//TODO: IndexOf - please add your indexof code here
			return -1;

		}

		//We want to remove the element at the specified location
		// and adjust the linked of the node before it
		//update your counter :)
		public bool RemoveAt(int index)
		{
			//TODO: RemoveAt - Please add your remove at code here
			return false;
		}

		public bool Remove(T element)
		{
			return RemoveAt(IndexOf(element));
		}
		public bool Contains(T element)
		{
			if (IndexOf(element) > -1) return true;
			return false;
		}


		public T ElementAt(int index)
		{
			Node<T> tempNode = headNode;
			int tempIndex = 0;
			while (tempIndex < index)  //jump index steps, now you are the right element. 
			{
				tempNode = tempNode.Next;
				tempIndex++;
			}
			return tempNode.Value;
		}

		public Node<T> NodeAt(int index)
		{
			Node<T> tempNode = headNode;
			int tempIndex = 0;
			while (tempIndex < index)  //jump index steps, now you are the right element. 
			{
				tempNode = tempNode.Next;
				tempIndex++;
			}
			return tempNode;
		}

		public void UpdateElement(int index, T value)
		{
			Node<T> tempNode = NodeAt(index);
			tempNode.Value = value;
		}


		public T this[int index]
		{
			get
			{
				if (index >= count) throw new Exception("Index out of range");
				return ElementAt(index);
			}
			set
			{
				if (index >= count) throw new Exception("Index out of range");
				UpdateElement(index, value);		
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			//TODO: GetEnumerator - Add your GetEnumerator Code here
			return new ListEnumerator<T>(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();

		}


	}
}

