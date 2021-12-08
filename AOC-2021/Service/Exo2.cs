using AOC_EXO7.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AOC_EXO7.Service
{
    public class Exo2
    {
        public List<DirectionCommande> DirectionCommandes { get; set; }

        public Exo2()
        {
            DirectionCommandes = GetDirectionCommandeFromInput();
        }

        public void Resolve()
        {
            PositionSousMarin positionSousMarin = new PositionSousMarin() { Depth = 0, Foward = 0 };
            positionSousMarin = EvolPositionSousMarin(positionSousMarin, DirectionCommandes);
            Console.WriteLine($"After following these instructions, you would have a horizontal position of {positionSousMarin.Foward} and a depth of {positionSousMarin.Depth}. (Multiplying these together produces {positionSousMarin.Depth * positionSousMarin.Foward}.)");
        }

        private PositionSousMarin EvolPositionSousMarin(PositionSousMarin positionSousMarin, List<DirectionCommande> directionCommandes)
        {
            foreach (DirectionCommande directionCommande in directionCommandes)
            {
                switch (directionCommande.Direction)
                {
                    case ("forward"):
                        positionSousMarin.Foward += directionCommande.Value;
                        positionSousMarin.Depth += directionCommande.Value * positionSousMarin.Aim;
                        break;

                    case ("down"):
                        positionSousMarin.Aim += directionCommande.Value;
                        break;

                    case ("up"):
                        positionSousMarin.Aim -= directionCommande.Value;
                        break;
                }
            }
            return positionSousMarin;
        }

        private List<DirectionCommande> GetDirectionCommandeFromInput()
        {
            List<DirectionCommande> directionCommandes = new List<DirectionCommande>();

            StreamReader reader = File.OpenText("Input//Exo2Input.tt");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.Split(' ');
                directionCommandes.Add(new DirectionCommande() { Direction = items[0], Value = int.Parse(items[1]) });
            }
            return directionCommandes;
        }
    }
}