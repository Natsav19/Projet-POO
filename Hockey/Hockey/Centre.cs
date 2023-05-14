using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;

namespace Hockey
{
    class Centre
    {
        public List<Equipe> listEquip;

        public Centre()
        {
            listEquip = new List<Equipe>();
            listEquip = Equipe.CreationEquipe();
        }

        public void Simulation()
        {
            Console.WriteLine("DÉBUT DE LA SAISON !");
            Console.WriteLine("Choissisez Votre Équipe!");
            Equipe equipSelect = Equipe.ImprimerEquipe(listEquip);
            Console.WriteLine($"Vous Avez choisit {equipSelect.Nom}");
            Console.WriteLine("Début de la Draft ! Appuyez sur une touche pour continuer",Color.Aqua);
            Console.ReadKey();
            Joueur.SimulerDraft(listEquip);
            Console.WriteLine("La Draft est maintenant terminée ! Appuyez sur une Touche pour commencer la série", Color.SeaGreen);
            ImprimerJoueur(listEquip,equipSelect);
            List<Equipe> classement = Simulate.Saison(listEquip);

            Console.WriteLine("La Saison est maintenant simulée vous pouvez appuyez sur une touche pour voir le classement !");
            Console.ReadKey();
            Console.WriteLine("Classement :",Color.Aqua);
            ImprimerListe(classement, equipSelect);
            Simulate.LancerSerie(classement, equipSelect);

        } 




        public static void ImprimerListe(List<Equipe> lstEquip, Equipe equipSelect)
        {
            int i = 0;
            foreach (Equipe equipe in lstEquip)
            {
                if (equipe == equipSelect)
                {
                    Console.WriteLine($"{i+1}. {equipe.Nom} - Victoires : {equipe.NbVictoire} - Défaites : {equipe.NbDefaite}", Color.Yellow);
                    i++;
                }
                else
                {
                    Console.WriteLine($"{i+1}. {equipe.Nom} - Victoires : {equipe.NbVictoire} - Défaites : {equipe.NbDefaite}");
                    i++;
                }
            }
        }
        public static void ImprimerJoueur(List<Equipe> lstEquip, Equipe equipSelect)
        {
            int i = 0;
            foreach (Equipe equipe in lstEquip)
            {
                if (equipe == equipSelect)
                {
                    Console.WriteLine($"Votre Effectif ({equipe.Nom}) :", Color.Orange);
                    Console.WriteLine("Liste Des Joueurs: \n ---------------------------------------------------------------------------", Color.Orange);
                    foreach (Joueur joueur in equipe.lstJoueur)
                    {
                        Console.WriteLine($"-{joueur.Nom}/{joueur.Position} --> Vitesse : {joueur.Vitesse} | Tir : {joueur.Tir} | Défense : {joueur.Defense} | Passe : {joueur.Passe}", Color.Yellow);
                    }
                    Console.WriteLine("\n-----------------------------------------------------------------------------------", Color.Orange);
                }
                else
                {
                    Console.WriteLine($"Effectif des {equipe.Nom} :", Color.OrangeRed);
                    Console.WriteLine("Liste Des Joueurs: \n ---------------------------------------------------------------------------", Color.OrangeRed);
                    foreach (Joueur joueur in equipe.lstJoueur)
                    {
                        Console.WriteLine($"-{joueur.Nom}/{joueur.Position} --> Vitesse : {joueur.Vitesse} | Tir : {joueur.Tir} | Défense : {joueur.Defense} | Passe : {joueur.Passe}");
                    }
                    Console.WriteLine("\n-------------------------------------------------------------------------------", Color.OrangeRed);
                }
            }
        }
    }
}
