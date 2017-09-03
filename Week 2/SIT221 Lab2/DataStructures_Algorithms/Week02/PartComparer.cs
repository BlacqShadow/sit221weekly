using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Algorithms.Week02
{
    public class PartComparer : IComparer<Part>
    {
        public int Compare(Part A, Part B)
        {
            // Task 3 a needs to be implemented here
            if(A.CompareTo(B) == -1)
            {

            }
            return 1;
        }
    }
}
