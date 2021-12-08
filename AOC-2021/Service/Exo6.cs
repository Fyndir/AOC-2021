using AOC_EXO7.Dto;
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

        /// <summary>
        /// Resout le probleme
        /// </summary>
        public void Resolve()
        {
            int nbJour = 256;
            List<DimensionPoisson> dimensionPoissons = GetDimensionPoissonsFromInput(this.GrpFish);
            dimensionPoissons = EvolDimensionPoissonsByDay(dimensionPoissons, nbJour);
            long nbPoisson = dimensionPoissons.Select(x => x.NbPoisson).Sum();
            Console.WriteLine($"Apres {nbJour} jours il y a {nbPoisson} poissons new algo");
        }

        /// <summary>
        /// Parse l'input et génère les dimensions initial
        /// </summary>
        /// <param name="grpFish"></param>
        /// <returns></returns>
        private List<DimensionPoisson> GetDimensionPoissonsFromInput(List<long> grpFish)
        {
            List<DimensionPoisson> dimensionPoissons = InitDimensionPoisson();
            foreach (long fish in grpFish)
            {
                dimensionPoissons.Where(x => x.NbJourDuplication == fish).First().NbPoisson++;
            }
            return dimensionPoissons;
        }

        /// <summary>
        /// Effectue X cycle et retourne la dimension calculé
        /// </summary>
        /// <param name="dimensionPoissons"></param>
        /// <param name="nbJour"></param>
        /// <returns></returns>
        private List<DimensionPoisson> EvolDimensionPoissonsByDay(List<DimensionPoisson> dimensionPoissons, int nbJour)
        {
            for (int i = 1; i <= nbJour; i++)
            {
                dimensionPoissons = EvolDimensionPoissons(dimensionPoissons);
            }
            return dimensionPoissons;
        }

        /// <summary>
        /// Effectue un cycle et retourne les dimmensions calculer
        /// </summary>
        /// <param name="dimensionPoissons"></param>
        /// <returns></returns>
        private List<DimensionPoisson> EvolDimensionPoissons(List<DimensionPoisson> dimensionPoissons)
        {
            List<DimensionPoisson> dimensionPoissonsFutur = InitDimensionPoisson();
            foreach (DimensionPoisson dimensionPoisson in dimensionPoissons)
            {
                switch (dimensionPoisson.NbJourDuplication)
                {
                    case 0:
                        dimensionPoissonsFutur.Where(x => x.NbJourDuplication == 6).FirstOrDefault().NbPoisson += dimensionPoisson.NbPoisson;
                        dimensionPoissonsFutur.Where(x => x.NbJourDuplication == 8).FirstOrDefault().NbPoisson += dimensionPoisson.NbPoisson;
                        break;

                    case 1:
                        dimensionPoissonsFutur.Where(x => x.NbJourDuplication == 0).FirstOrDefault().NbPoisson += dimensionPoisson.NbPoisson;
                        break;

                    case 2:
                        dimensionPoissonsFutur.Where(x => x.NbJourDuplication == 1).FirstOrDefault().NbPoisson += dimensionPoisson.NbPoisson;
                        break;

                    case 3:
                        dimensionPoissonsFutur.Where(x => x.NbJourDuplication == 2).FirstOrDefault().NbPoisson += dimensionPoisson.NbPoisson;
                        break;

                    case 4:
                        dimensionPoissonsFutur.Where(x => x.NbJourDuplication == 3).FirstOrDefault().NbPoisson += dimensionPoisson.NbPoisson;
                        break;

                    case 5:
                        dimensionPoissonsFutur.Where(x => x.NbJourDuplication == 4).FirstOrDefault().NbPoisson += dimensionPoisson.NbPoisson;
                        break;

                    case 6:
                        dimensionPoissonsFutur.Where(x => x.NbJourDuplication == 5).FirstOrDefault().NbPoisson += dimensionPoisson.NbPoisson;
                        break;

                    case 7:
                        dimensionPoissonsFutur.Where(x => x.NbJourDuplication == 6).FirstOrDefault().NbPoisson += dimensionPoisson.NbPoisson;
                        break;

                    case 8:
                        dimensionPoissonsFutur.Where(x => x.NbJourDuplication == 7).FirstOrDefault().NbPoisson += dimensionPoisson.NbPoisson;
                        break;
                }
            }
            return dimensionPoissonsFutur;
        }

        /// <summary>
        /// Initialise les différentes dimensions des poisson , 1 dim par jour avant la duplication
        /// </summary>
        /// <returns></returns>
        private List<DimensionPoisson> InitDimensionPoisson()
        {
            List<DimensionPoisson> dimensionPoissons = new List<DimensionPoisson>();
            for (int i = 0; i <= 8; i++)
            {
                dimensionPoissons.Add(new DimensionPoisson() { NbJourDuplication = i, NbPoisson = 0 });
            }
            return dimensionPoissons;
        }
    }
}