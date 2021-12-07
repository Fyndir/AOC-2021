using System;
using System.Collections.Generic;
using System.Text;

namespace AOC_EXO7.Service
{
    public class Exo1
    {
        public int CalculNbIncreseFromList(List<int> sonnarOutput)
        {
            int nbIncrese = 0;
            int precedenceMsure = int.MaxValue;
            foreach (int i in sonnarOutput)
            {
                if (i > precedenceMsure)
                {
                    nbIncrese++;
                }
                precedenceMsure = i;
            }

            return nbIncrese;
        }
    }
}