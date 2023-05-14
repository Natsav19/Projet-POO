using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Hockey
{
    public class Joueur
    {
        public string Nom { get; set; }
        public string Position { get; set; }
        public int Vitesse { get; set; }
        public int Tir { get; set; }
        public int Passe { get; set; }
        public int Defense { get; set; }

        [JsonConstructor]
        public Joueur(string nom, string position, int vitesse, int tir, int passe, int defense)
        {
            Nom = nom;
            Position = position;
            Vitesse = vitesse;
            Tir = tir;
            Passe = passe;
            Defense = defense;
        }


        public static void SimulerDraft(List<Equipe> listEquip)
        {
            List<Joueur> listJoueur = JsonFileLoader.ChargerFicher<List<Joueur>>("joueurs.json");
            List <Joueur> listAttaquants = new List<Joueur>();
            List<Joueur> listGuardien = JsonFileLoader.ChargerFicher<List<Joueur>>("Gardiens.json");
            List<Joueur> listDefenseurs = new List<Joueur>();

            // Séparez les joueurs en fonction de leur position
            foreach (Joueur joueur in listJoueur)
            {
                if (joueur.Position == "Attaquant")
                {
                    listAttaquants.Add(joueur);
                }
                else if (joueur.Position == "Défenseur")
                {
                    listDefenseurs.Add(joueur);
                }
            }
            Console.WriteLine($"Attaquant : {listAttaquants.Count}");
            Console.WriteLine($"Défenseur : {listDefenseurs.Count}");
            Console.WriteLine($"Gardien : {listGuardien.Count}");
            foreach (Equipe equipe in listEquip)
            {
                // Sélectionnez deux défenseurs et trois attaquants pour chaque équipe
                List<Joueur> joueursEquipe = new List<Joueur>();
                for (int i = 0; i < 2; i++)
                {
                    int index = FabriqueNom.rand.Next(0, listDefenseurs.Count);
                    joueursEquipe.Add(listDefenseurs[index]);
                    listDefenseurs.RemoveAt(index);
                }
                for (int i = 0; i < 3; i++)
                {
                    int index = FabriqueNom.rand.Next(0, listAttaquants.Count);
                    joueursEquipe.Add(listAttaquants[index]);
                    listAttaquants.RemoveAt(index);
                }
                int rdm = FabriqueNom.rand.Next(0, listGuardien.Count);
                joueursEquipe.Add(listGuardien[rdm]);
                listGuardien.RemoveAt(rdm);
    
                equipe.lstJoueur.AddRange(joueursEquipe);
            }
        }
    }

    public static class JsonFileLoader
    {
        public static T ChargerFicher<T>(string nomFichier)
        {
            try
            {
                using (StreamReader reader = new StreamReader(nomFichier))
                {
                    string json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<T>(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("le Fichier JSON a dead💀 : " + ex.Message);
                return default(T);

            }

        }
    }
}
