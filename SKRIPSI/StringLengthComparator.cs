using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKRIPSI
{
    class StringLengthComparator : IComparer<String>
    {
        public int Compare(string x, string y)
        {
            return x.Length - y.Length;
        }
    }
}
