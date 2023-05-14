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
        public static void SimulationSerie(List<Equipe> lstEquip, Equipe EquipSelect)
        {
            bool valide = true;
            for (int y = 0; valide == true ; y++)
            {
                valide = VérifierWin(lstEquip, EquipSelect);
                if (valide == true)
                {
                    Console.WriteLine($"Début du Round #{y + 1}");
                    foreach (Equipe equipe in lstEquip)
                    {
                        equipe.NbVictoire = 0;
                        equipe.NbDefaite = 0;
                    }
                    Console.WriteLine("Match Making En Cours...",Color.Orange);
                    //Console.WriteLine($"Semaine {i + 1} Terminer ! Appuyez sur une touche pour Continuer !\n");
                    for (int i = 0; i < lstEquip.Count; i += 2)
                    {
                        MatchMaking(lstEquip[i], lstEquip[i + 1]);
                    }
                    Console.WriteLine("Début des Match \n");
                    List<Equipe> equipesEliminees = new List<Equipe>();
                    for (int i = 0; i < lstEquip.Count; i += 2)
                    {
                        Equipe equipeEliminee = SimulerSet(lstEquip[i], lstEquip[i + 1]);
                        equipesEliminees.Add(equipeEliminee);
                    }
                    lstEquip.RemoveAll(equipe => equipesEliminees.Contains(equipe));
                }
            }
            Console.WriteLine($"Les {lstEquip[0].Nom} remportent la Coupe Stanley", Color.Yellow);
        }

        public static void MatchMaking(Equipe equipe1, Equipe equipe2)
        {
            Console.WriteLine($"{equipe1.Nom} Vs {equipe2.Nom} | {equipe1.NbVictoire} / {equipe2.NbVictoire}");
        }

        public static Equipe SimulerSet(Equipe Equipe1, Equipe Equipe2)
        {
            while (Equipe1.NbVictoire < 4 && Equipe2.NbVictoire < 4)
            {
                Match(Equipe1, Equipe2);
                Console.WriteLine($"Résultat : {Equipe1.Nom} Vs {Equipe2.Nom} | {Equipe1.NbVictoire} / {Equipe2.NbVictoire}");
            }
            if (Equipe1.NbVictoire == 4)
            {
                Console.WriteLine($"Victoire de l'équipe -> {Equipe1.Nom}", Color.Green);
                Console.WriteLine($"Élimination de l'équipe -> {Equipe2.Nom}",Color.Red);
                return Equipe2;
            }
            else
            {
                Console.WriteLine($"Victoire de l'équipe -> {Equipe2.Nom}", Color.Green);
                Console.WriteLine($"Élimination de l'équipe -> {Equipe1.Nom}", Color.Red);
                return Equipe1;
            }
        }
    }
}
