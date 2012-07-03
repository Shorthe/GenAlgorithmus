using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenAlgorithmus
{
    class FitnessComparator : IComparer<Individuum>
    {
        int IComparer<Individuum>.Compare(Individuum x, Individuum y)
        {
            if (x.guete < y.guete)
                return -1;
            if (x.guete > y.guete)
                return 1;
            return 0;
        }
    }
}
