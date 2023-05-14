using System;
using System.Collections.Generic;
using System.Text;

namespace Hockey
{
    class Program
    {
        static void Main(string[] args)
        {
            Centre centre = new Centre();
            InitialiserNom();
            InitialiserJoueur();
            centre.Simulation();
            //Initialisation
        }
        static void InitialiserNom()
        {
            try
            {
                FabriqueNom.RemplirListe();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur survenue lors de la Lecture" + ex.Message);
            }
        }
        static public void InitialiserJoueur()
        {
            List<Joueur> listJoueur = new List<Joueur>();
            List<Joueur> listGuardien = new List<Joueur>();
            listGuardien = JsonFileLoader.ChargerFicher<List<Joueur>>("Gardiens.json");
            listJoueur = JsonFileLoader.ChargerFicher<List<Joueur>>("joueurs.json");

        }
    }

}
