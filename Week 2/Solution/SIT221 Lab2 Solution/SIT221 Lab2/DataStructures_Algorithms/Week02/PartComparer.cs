using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Algorithms.Week02
{
    public class PartComparer : IComparer<Part>
    {
        // by default
        // if A.PartId >  B.PartId --> 1
        // if A.PartId == B.PartId --> 0
        // if A.PartId <  B.PartId --> -1
        
        // what we need here is
        // if A.PartId >  B.PartId --> -1
        // if A.PartId == B.PartId --> 0
        // if A.PartId <  B.PartId --> 1

        public int Compare(Part A, Part B)
        {
            // Task 3 a needs to be implemented here
            if (A == null && B == null) return 0;
            if (A == null && B != null) return 1;
            if (A != null && B == null) return -1;

            return A.PartId.CompareTo(B.PartId) * -1; // -1 is the magic number. Set it to 1 then see what is happening
        }
    }
}
