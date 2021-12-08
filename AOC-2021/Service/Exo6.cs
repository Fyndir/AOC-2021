using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_EXO7.Service
{
    public class Exo6
    {
        public List<long> GrpFish { get; set; }

        public Exo6()
        {
            GrpFish = new List<long>() { 3, 4, 3, 1, 2, 1, 5, 1, 1, 1, 1, 4, 1, 2, 1, 1, 2, 1, 1, 1, 3, 4, 4, 4, 1, 3, 2, 1, 3, 4, 1, 1, 3, 4, 2, 5, 5, 3, 3, 3, 5, 1, 4, 1, 2, 3, 1, 1, 1, 4, 1, 4, 1, 5, 3, 3, 1, 4, 1, 5, 1, 2, 2, 1, 1, 5, 5, 2, 5, 1, 1, 1, 1, 3, 1, 4, 1, 1, 1, 4, 1, 1, 1, 5, 2, 3, 5, 3, 4, 1, 1, 1, 1, 1, 2, 2, 1, 1, 1, 1, 1, 1, 5, 5, 1, 3, 3, 1, 2, 1, 3, 1, 5, 1, 1, 4, 1, 1, 2, 4, 1, 5, 1, 1, 3, 3, 3, 4, 2, 4, 1, 1, 5, 1, 1, 1, 1, 4, 4, 1, 1, 1, 3, 1, 1, 2, 1, 3, 1, 1, 1, 1, 5, 3, 3, 2, 2, 1, 4, 3, 3, 2, 1, 3, 3, 1, 2, 5, 1, 3, 5, 2, 2, 1, 1, 1, 1, 5, 1, 2, 1, 1, 3, 5, 4, 2, 3, 1, 1, 1, 4, 1, 3, 2, 1, 5, 4, 5, 1, 4, 5, 1, 3, 3, 5, 1, 2, 1, 1, 3, 3, 1, 5, 3, 1, 1, 1, 3, 2, 5, 5, 1, 1, 4, 2, 1, 2, 1, 1, 5, 5, 1, 4, 1, 1, 3, 1, 5, 2, 5, 3, 1, 5, 2, 2, 1, 1, 5, 1, 5, 1, 2, 1, 3, 1, 1, 1, 2, 3, 2, 1, 4, 1, 1, 1, 1, 5, 4, 1, 4, 5, 1, 4, 3, 4, 1, 1, 1, 1, 2, 5, 4, 1, 1, 3, 1, 2, 1, 1, 2, 1, 1, 1, 2, 1, 1, 1, 1, 1, 4 };
        }

        public void Resolve()
        {
            Console.WriteLine($"Nb poisson après {256} jours V2 {CalculNbFishUnGrpAfterDayInParamV2(GrpFish, 256)}");
        }

        /// <summary>
        /// Calcule le nombre de poisson dans le grp passé en param apres X jours
        /// </summary>
        /// <param name="nbJours"></param>
        private int CalculNbFishUnGrpAfterDayInParamV2(List<long> GrpFish, int nbJours)
        {
            int nbFish = 0;
            foreach (int fish in GrpFish.Distinct())
            {
                nbFish += EvolFish(fish, nbJours) * GrpFish.Count(x => x == fish);
            }

            return nbFish;
        }

        /// <summary>
        /// Fait evoluer le grp de poisson
        /// </summary>
        /// <param name="grpFish"></param>
        /// <returns></returns>
        private List<long> EvolFish(List<long> grpFish)
        {
            List<long> grpFishFutur = new List<long>();
            Parallel.ForEach(grpFish, fish =>
               {
                   lock (grpFishFutur)
                       if (fish == 0)
                       {
                           grpFishFutur.Add(8);
                           grpFishFutur.Add(6);
                       }
                       else
                       {
                           grpFishFutur.Add(fish - 1);
                       }
               });

            return grpFishFutur;
        }

        /// <summary>
        /// calcul le nombre de poisson apres x jour pour un poission donn
        /// </summary>
        /// <param name="fish"></param>
        /// <param name="nbDays"></param>
        /// <returns></returns>
        private int EvolFish(long inputFish, int nbDays)
        {
            List<long> grpFish = new List<long>() { inputFish };

            for (int i = 1; i <= nbDays; i++)
            {
                grpFish = EvolFish(grpFish);
            }

            return grpFish.Count;
        }
    }
}