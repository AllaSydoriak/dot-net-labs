using System;
using System.Collections.Generic;

namespace lab1
{
    public class StudentComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.Avarage.CompareTo(y.Avarage);
        }
    }
}