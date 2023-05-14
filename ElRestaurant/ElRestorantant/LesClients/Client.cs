using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;

namespace ElRestorantant
{
    public enum Humeur
    {
        Joyeux,
        Rageux, 
        Neutre,     
    }
    public class Client
    {
        public string Nom { get; set; }
        public Humeur HumeurClient { get; set; }
        public Plats Facture { get; set; }

        public Client(List<Plats> Menu)
        {
            Nom = FabriqueNom.FabriquerNom();

            //Setting de l'humeur du client 
            int nb = FabriqueNom.rand.Next(0, 3);
            HumeurClient = (Humeur)nb;

            //Choix du Plats 
            int rdm = FabriqueNom.rand.Next(0, Menu.Count);
            Facture = Menu[rdm];
        }

        public void ServirClient(Restaurant resto)
        {
            // Vérifier si tous les ingrédients nécessaires sont disponibles
            float prixRepas=0;
            foreach (ingredients ingr in Facture.LstIngredient)
            {
                resto.Monnaie = resto.Monnaie - ingr.Prix;
                prixRepas += ingr.Prix;
                Console.WriteLine($"* -{ingr.Prix}$ pour 1 {ingr.Nom}.");
            }
            Console.WriteLine($"Tous les ingrédients on été acheter pour le plat ({Facture.Nom}) pour un prix de {prixRepas}$.");
            double montantFacture = Facture.PrixVente;
            Console.WriteLine($"Le plat \"{Facture.Nom}\" est prêt. Le client \"{Nom}\" doit payer {montantFacture}$.");
            resto.Monnaie += montantFacture;     
        }

        public void ObtenirPourboire(Restaurant resto)
        {
            int rdm = FabriqueNom.rand.Next(0, 2);
            int pourboire = FabriqueNom.rand.Next(0, 10);
            if (HumeurClient == Humeur.Joyeux)
            {
                resto.Monnaie += pourboire;
                Console.WriteLine($"+{pourboire}$ de Pourboire", Color.Green);
            }

            if (rdm == 1)
            {
                resto.Monnaie += 5;
                Console.WriteLine("+5$ de Pourboire", Color.Green);
            }
            else
            {
                resto.Monnaie += 2;
                Console.WriteLine("+2$ de Pourboire", Color.Green);
            }

        }

    }
}
