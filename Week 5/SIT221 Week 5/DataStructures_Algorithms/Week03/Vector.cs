using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Algorithms.Week03
{

	[Serializable]
	public class Vector<T> : ISorter
	{
		T[] data;
		const int DEFAULT_CAPACITY = 10;
		int count = 0;

		public Vector()
		{
			data = new T[DEFAULT_CAPACITY];
		}


		public Vector(int CAPACITY)
		{
			data = new T[CAPACITY];
		}


		private void ExtendData(int extensionCapacity)
		{
			T[] newData = new T[data.Length + extensionCapacity];
			Array.Copy(data, 0, newData, 0, count);
			data = newData;
		}

		public void Add(T element)
		{
			if (count >= data.Length)
				ExtendData(DEFAULT_CAPACITY);
			data[count++] = element;

		}
		public bool Contains(T element)
		{
			if (IndexOf(element) > -1)
				return true;
			return false;
		}
		/*
		 * Running time T(n) = 5n + 3 
		 * Best case = 5
		 * Worst case = 5n + 3
		 */
		public int IndexOf(T element)
		{
            for (var i = 0; i < count; i++)
                if (data[i].Equals(element)) return i;
            return -1;
        }
		/*
		 * 
		 * 
		 * 
		 */
		public void Insert(T element, int index)
		{
			if (index > count) throw new IndexOutOfRangeException("index out of range");
			if (count == data.Length) ExtendData(DEFAULT_CAPACITY);

			// you could use Array.Copy or simply move elements manually as follows
			for (int i = count; i > index; i--)
				data[i] = data[i - 1];
			data[index] = element;
			count++;

		}
		public bool Remove(T element)
		{
			var index = IndexOf(element);
			if (index > -1)
				return RemoveAt(index);
			return false;

		}
		public bool RemoveAt(int index)
		{
			if (index > count) throw new IndexOutOfRangeException("index out of range");
			//shift all the elements to the left
			for (int i = index; i < count; i++)
				data[i] = data[i + 1];
			//decrement count field
			count--;

			return true;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			((ICollection<T>)data).CopyTo(array, arrayIndex);
		}



		public void Clear()
		{
			((ICollection<T>)data).Clear();
		}

		public IEnumerator<T> GetEnumerator()
		{
			return ((ICollection<T>)data).GetEnumerator();
		}



		public int Capacity
		{
			get
			{
				return data.Length;
			}
			set
			{
				if (value < count)
					throw new ArgumentOutOfRangeException();
				ExtendData(value);
			}
		}
		public int Count
		{
			get { return count; }
		}

		public void Sort()
		{
			Array.Sort(data, 0, count);
		}
		public void Sort(IComparer<T> comparer)
		{
			Array.Sort(data, 0, count, comparer);
		}

		private int BinarySearch(T value, int left, int right, IComparer<T> comparer)
		{
			if (comparer == null) comparer = Comparer<T>.Default;
			if (left <= right)
			{
				int middle = (left + right) / 2;
				int result = comparer.Compare(value, data[middle]);
				if (result == 0)
					return middle;
				if (result < 0)
					return BinarySearch(value, left, middle - 1, comparer);
				if (result > 0)
					return BinarySearch(value, middle + 1, right, comparer);
			}
			return -1;

		}
		public int BinarySearch(T element)
		{
			return BinarySearch(element, 0, count, null);
		}
		public int BinarySearch(T element, IComparer<T> comparer)
		{
			return BinarySearch(element, 0, count, comparer);
		}
		public bool IsReadOnly
		{
			get
			{
				return ((ICollection<T>)data).IsReadOnly;
			}
		}

		public T this[int index]
		{
			get
			{
				return data[index];
			}
			set
			{
				if (index >= count)
					throw new IndexOutOfRangeException();
				data[index] = value;

			}
		}
		public override string ToString()
		{
			string listValues = "";
			int i = 0;
			for (i = 0; i < count - 1; i++)
				listValues += string.Format("{0},", data[i]);
			listValues += string.Format("{0}", data[i]);
			return listValues;
		}

		public void Sort(SortingAlgorithm sortAlgorithm)
		{
			switch(sortAlgorithm)
			{
                case SortingAlgorithm.BUBBLE:
                    BubbleSort(); break;
                case SortingAlgorithm.INSERTION: 
					InsertionSort();  break;
				case SortingAlgorithm.SELECTION: 
					SelectionSort(); break;
				case SortingAlgorithm.MERGE: 
					MergeSort(); break;
				case SortingAlgorithm.QUICK: 
					QuickSort(); break; 
				case SortingAlgorithm.MICROSOFT: 
					MicrosoftSort(); break;

			}
        }

		void Swap(ref T t1, ref T t2)
		{
			T tmp = t2;
			t2 = t1;
			t1 = tmp;
		}

        void BubbleSort()
        {
            IComparer<T> comparer = Comparer<T>.Default;
            for (int i = 0; i < Count - 1; i++)
                for (int j = 0; j < Count - i - 1; j++)
                    if (comparer.Compare(data[j], data[j+1]) > 0)
                        Swap(ref data[j], ref data[j + 1]);
        }

        void InsertionSort()
		{
			IComparer <T> comparer  = Comparer<T>.Default;
			int j = 0;
			T temp;
			for (int index = 1; index < Count; index++)
			{
				j = index;
				temp = data[index];
				while ((j > 0) && comparer.Compare(data[j - 1], temp) > 0)
				{
					data[j] = data[j - 1];
					j = j - 1;
				}
				data[j] = temp;
			}
		}

        void SelectionSort()
        {
            IComparer<T> comparer = Comparer<T>.Default;
            long index_of_min = 0;
            for (int iterator = 0; iterator < Count - 1; iterator++)
            {
                index_of_min = iterator;
                for (int index = iterator + 1; index < Count; index++)
                {
                    if (comparer.Compare(data[index], data[index_of_min]) < 0)
                        index_of_min = index;
                }
                Swap(ref data[iterator], ref data[index_of_min]);
            }
        }

        // Using Top-down approach https://en.wikipedia.org/wiki/Merge_sort
        void MergeSort()
        {
            T[] tmpData = new T[Count];
            Array.Copy(data, tmpData, Count); // dupliate data[] into tmpData[] on which the method will be working
            TopDownSplitMerge(ref tmpData, 0, Count, ref data);
        }

        private void TopDownSplitMerge(ref T[] B, int iBegin, int iEnd, ref T[] A)
        {
            if (iEnd - iBegin < 2)                       // if run size == 1, consider it sorted
                return;

            // split the run longer than 1 item into halves
            // iMiddle = mid point
            int iMiddle = (iEnd + iBegin) / 2;

            // recursively sort both runs from array A[] into B[]
            TopDownSplitMerge(ref A, iBegin, iMiddle, ref B);  // sort the left  run
            TopDownSplitMerge(ref A, iMiddle, iEnd, ref B);  // sort the right run

            // merge the resulting runs from array B[] into A[]
            TopDownMerge(ref B, iBegin, iMiddle, iEnd, ref A);
        }

        private void TopDownMerge(ref T[] A, int iBegin, int iMiddle, int iEnd, ref T[] B)
        {
            IComparer<T> comparer = Comparer<T>.Default;
            int i = iBegin;
            int j = iMiddle;

            // While there are elements in the left or right runs...
            for (int k = iBegin; k < iEnd; k++)
            {
                // If left run head exists and is <= existing right run head.
                if (i < iMiddle && (j >= iEnd || comparer.Compare(A[i], A[j]) <= 0))
                {
                    B[k] = A[i];
                    i = i + 1;
                }
                else
                {
                    B[k] = A[j];
                    j = j + 1;
                }
            }
        }

        // Using Lomuto partition scheme https://en.wikipedia.org/wiki/Quicksort
        void quickSort(int left, int right)
        {
            if (left < right)
            {
                int pivot = partition(left, right);
                quickSort(left, pivot - 1);
                quickSort(pivot + 1, right);
            }
        }

        private int partition(int left, int right)
        {
            IComparer<T> comparer = Comparer<T>.Default;
            T pivot = data[right];
            int i = left - 1;
            for (int j = left; j <= right - 1; j++)
            {
                if (comparer.Compare(data[j], pivot) < 0)
                {
                    i++;
                    Swap(ref data[i], ref data[j]);
                }
            }

            if (comparer.Compare(data[right], data[i + 1]) < 0)
                Swap(ref data[i + 1], ref data[right]);

            return i + 1;
        }

        public void QuickSort()
        {
            quickSort(0, Count - 1);
        }

        void MicrosoftSort()
        {
            Array.Sort(data, 0, count);
        }
    }
}