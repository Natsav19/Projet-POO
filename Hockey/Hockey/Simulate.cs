using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;

namespace Hockey
{
    public partial class Simulate
    {
        public static List<Equipe> Saison(List<Equipe> lstEquip)
        {
            //Console.WriteLine("Début de Saison");
            try
            {
                bool ValidationMatch = false;
                while (ValidationMatch == false)
                {
                    //Console.WriteLine("debut test");
                    Equipe equipe1 = lstEquip[FabriqueNom.rand.Next(0, lstEquip.Count)];
                    //Console.WriteLine($"{equipe1.Nom}");
                    Equipe equipe2 = lstEquip[FabriqueNom.rand.Next(0, lstEquip.Count)];
                    //Console.WriteLine($"{equipe2.Nom}");
                        while (equipe1.NbMatch == 50 || equipe1.Nom == equipe2.Nom)
                        {

                            equipe1 = lstEquip[FabriqueNom.rand.Next(0, lstEquip.Count)];
                          // Console.WriteLine($"- {equipe1.Nom}");
                        }
                        while (equipe2.NbMatch == 50 || equipe2.Nom == equipe1.Nom)
                        {
                            equipe2 = lstEquip[FabriqueNom.rand.Next(0, lstEquip.Count)];
                            //Console.WriteLine($"- {equipe1.Nom}");
                        }
                    Match(equipe1, equipe2);
                    //Console.WriteLine(Winner.Nom);
                    equipe1.NbMatch++;
                    equipe2.NbMatch++;
                    ValidationMatch = EquipMatch(lstEquip);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur: {ex.Message}");
            }
            lstEquip = lstEquip.OrderByDescending(e => e.NbVictoire).ThenBy(e => e.NbDefaite).ToList();
            return lstEquip;
        }

        public static void Match(Equipe Equipe1, Equipe Equipe2)
        {
            int Equipe1But = 0;
            int Equipe2But = 0;

            for (int y = 0; y != 30; y++)
            {
                int rdm = FabriqueNom.rand.Next(1, 5);

                if (rdm == 1)
                {
                    Equipe1But++;
                }
                else if (rdm == 2)
                {
                    Equipe2But++;
                }
            }

            if (Equipe1But > Equipe2But)
            {
                Equipe1.NbVictoire += 1;
                Equipe2.NbDefaite += 1;
            }
            else if (Equipe2But > Equipe1But)
            {
                Equipe2.NbVictoire += 1;
                Equipe1.NbDefaite += 1;
            }
            else
            {
                int rdm = FabriqueNom.rand.Next(1, 2);

                if (rdm == 1)
                {
                    Equipe2.NbVictoire += 1;
                    Equipe1.NbDefaite += 1;
                }
                else
                {
                    Equipe1.NbVictoire += 1;
                    Equipe2.NbDefaite += 1;
                }
            }
        }
        public static bool EquipMatch(List<Equipe> lstEquip)
        {
            int y = 0;
            foreach(Equipe Equipe in lstEquip)
            {
                if(Equipe.NbMatch == 50)
                {
                    y++;
                }
            }
            if ((y == 32) || (y == 31))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static void LancerSerie(List<Equipe> lstEquip, Equipe EquipSelect)
        {
            int y = 0;
            List<Equipe> EquipSerie = new List<Equipe>();
            for(int i =0; i < 16; i++)
            {
                EquipSerie.Add(lstEquip[i]);
            }
            bool valide= VérifierWin(EquipSerie, EquipSelect);
            if(valide == true)
            {
                Console.WriteLine("");
                Console.WriteLine("ÉQUIPE ADMISSIBLE AU SÉRIE :", Color.Green);
                Centre.ImprimerListe(EquipSerie, EquipSelect);
                Console.WriteLine("");
                SimulationSerie(EquipSerie, EquipSelect);
            }
        }

        public static bool VérifierWin(List<Equipe> lstEquip, Equipe EquipSelect)
        {
            int y = 0;
            foreach (Equipe Equipe in lstEquip)
            {
                if (Equipe == EquipSelect)
                {
                  y++;
                }
            }
            if (y > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Vous ne faites pas les séries !", Color.Red);
                Console.WriteLine(@"    ┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼
    ███▀▀▀██┼███▀▀▀███┼███▀█▄█▀███┼██▀▀▀
    ██┼┼┼┼██┼██┼┼┼┼┼██┼██┼┼┼█┼┼┼██┼██┼┼┼
    ██┼┼┼▄▄▄┼██▄▄▄▄▄██┼██┼┼┼▀┼┼┼██┼██▀▀▀
    ██┼┼┼┼██┼██┼┼┼┼┼██┼██┼┼┼┼┼┼┼██┼██┼┼┼
    ███▄▄▄██┼██┼┼┼┼┼██┼██┼┼┼┼┼┼┼██┼██▄▄▄
    ┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼
    ███▀▀▀███┼▀███┼┼██▀┼██▀▀▀┼██▀▀▀▀██▄┼
    ██┼┼┼┼┼██┼┼┼██┼┼██┼┼██┼┼┼┼██┼┼┼┼┼██┼
    ██┼┼┼┼┼██┼┼┼██┼┼██┼┼██▀▀▀┼██▄▄▄▄▄▀▀┼
    ██┼┼┼┼┼██┼┼┼██┼┼█▀┼┼██┼┼┼┼██┼┼┼┼┼██┼
    ███▄▄▄███┼┼┼─▀█▀┼┼─┼██▄▄▄┼██┼┼┼┼┼██▄
    ┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼
    ");
                return false;
            }         
        }
    }
}
