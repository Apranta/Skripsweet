using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKRIPSI
{
    class WordCoordinateComparator : IComparer<KoordinateKata>
    {
        public int Compare(KoordinateKata x, KoordinateKata y)
        {
            return x.getScore() - y.getScore();
        }
    }
}
