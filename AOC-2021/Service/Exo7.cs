using System;
using System.Collections.Generic;
using System.Text;

namespace AOC_EXO7.Service
{
    public class Exo7
    {
        /// <summary>
        /// Calcule le nombre de poisson dans le grp passé en param apres X jours
        /// </summary>
        /// <param name="nbJours"></param>
        public int CalculNbFishUnGrpAfterDayInParam(List<long> GrpFish, int nbJours)
        {
            int i;
            for (i = 1; i <= nbJours; i++)
            {
                GrpFish = EvolFish(GrpFish);
            }
            return GrpFish.Count;
        }

        /// <summary>
        /// Fait evoluer le grp de poisson
        /// </summary>
        /// <param name="grpFish"></param>
        /// <returns></returns>
        private List<long> EvolFish(List<long> grpFish)
        {
            List<long> grpFishFutur = new List<long>();
            foreach (int fish in grpFish)
            {
                if (fish == 0)
                {
                    grpFishFutur.Add(8);
                    grpFishFutur.Add(6);
                }
                else
                {
                    grpFishFutur.Add(fish - 1);
                }
            }

            return grpFishFutur;
        }
    }
}