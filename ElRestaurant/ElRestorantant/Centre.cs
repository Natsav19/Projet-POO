using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElRestorantant
{
    class Centre
    {
        public void Simulation()
        {
            Console.Clear();
            Console.WriteLine("Choissisez le nom de votre restaurant.");
            string choix = Console.ReadLine();
            Console.WriteLine("Appuyez sur une touche pour commencer");
            Console.ReadKey();
            Restaurant resto = new Restaurant(choix);
            //Début du Menu 
            for (int i = 0; resto.Monnaie != 0; i++)
            {
                bool clientServit = false;
                Console.WriteLine($"--> Jour Numéro {i + 1}");
                resto.ObtenirClient(resto.Menu);
                while (!clientServit)
                {
                    Console.WriteLine($">>>> Gestion du Restaurant ({resto.Monnaie}$) <<<<\n");
                    Console.WriteLine("1 --> Stats Du Restaurant\n" +
                        "2 --> Gestion des Clients\n" +
                        "3 --> Achat de Nouveau Plat\n" +
                        "4 --> Engager Employer\n");
                    int chx = Convert.ToInt32(Console.ReadLine());
                    //CONFIRMATION DU CHOIX
                    while ((chx > 4) || (chx < 0))
                    {
                        Console.WriteLine("--> Tapez un chiffre pour faire une action (1,2,3,4 OU 5)");
                        chx = Convert.ToInt32(Console.ReadLine());
                    }
                    if (chx == 1) { resto.RestoStats(); }
                    if (chx == 2) { resto.CompleterFacture(resto); clientServit = true; }
                    if (chx == 3) { Plats.Acheterplat(resto); }
                    if (chx == 4) { resto.EngagerEmp(resto); }
                }

            }
        }
    }
}
