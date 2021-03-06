﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Algorithms.Week02
{
    public class Part : IComparable<Part>
    {
        public string PartName { get; set; }

        public int PartId { get; set; }

        public override string ToString()
        {
            return "ID: " + PartId + "   Name: " + PartName;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Part objAsPart = obj as Part;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
       
        public override int GetHashCode()
        {
            return PartId;
        }
        public bool Equals(Part other)
        {
            if (other == null) return false;
            return (this.PartId.Equals(other.PartId));
        }

        public int CompareTo(Part other)
        {
            // A null value means that this object is greater.
            if (this.PartId > other.PartId)
                return 1;
            else if (this.PartId < other.PartId)
                // Task 2 c needs to be implemented here
                return -1;
            else
                return 0;
                
        }
    
    }
}
