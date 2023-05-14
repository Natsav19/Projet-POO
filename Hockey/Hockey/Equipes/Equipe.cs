using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hockey
{
    public class Equipe
    {
        public string Nom { get; set; }
        public List<Joueur> lstJoueur { get; set; }
        public int NbVictoire { get; set; }
        public int NbDefaite { get; set; }
        public int NbMatch { get; set; }

        public Equipe(string nom)
        {
            Nom = nom;
            NbVictoire = 0;
            NbDefaite = 0;
            NbMatch = 0;
            lstJoueur = new List<Joueur>();
        }

        public static List<Equipe> CreationEquipe()
        {
            List<Equipe> lstEquip = new List<Equipe>();

            // Chemin d'accès du fichier texte contenant les noms d'équipes
            string filePath = "nom_equipe.txt";

            // Générer les noms d'équipes à partir du fichier texte
            List<string> listNom = FabriqueNom.RemplirListe();

            // Créer des objets Equipe avec les noms générés
            foreach (string nom in listNom)
            {
                Equipe equipe = new Equipe(nom);
                lstEquip.Add(equipe);
            }

            return lstEquip;
        }
        public static Equipe ImprimerEquipe(List<Equipe> lstEquip)
        {
            int y = 0;
            foreach(Equipe equipe in lstEquip)
            {
                Console.WriteLine($"{y+1}- {equipe.Nom}");
                y++;
            }

            int choix = Convert.ToInt32(Console.ReadLine());
            while((choix > 32) || (choix < 0))
            {
                Console.WriteLine("Choissisez Votre Équipe!");
                choix = Convert.ToInt32(Console.ReadLine());
            }
            Equipe EquipeSelect = lstEquip[choix - 1];
            return EquipeSelect;
        }
    }
}
