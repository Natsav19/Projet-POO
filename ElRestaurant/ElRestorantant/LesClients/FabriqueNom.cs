using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElRestorantant
{
    static class FabriqueNom
    {
        static List<string> listNom = new List<string>();
        static List<string> listPrenom = new List<string>();
        static public Random rand = new Random();




        //Remplissage Des Listes
        static public void RemplirListe()
        {
            AjouterNom();
            AjouterPrenom();
        }

        //Usine a Nom De Famille
        static void AjouterNom()
        {
            string fichierNomFamille = "nom_famille.txt";

            using (StreamReader reader = new StreamReader(fichierNomFamille))
            {
                string line;

                while((line = reader.ReadLine()) != null)
                {
                    listNom.Add(line);
                }
            }
        }

        //Usine a Prenom
        static void AjouterPrenom()
        {
            string fichierPrenom = "Prenom.txt";

            using (StreamReader reader = new StreamReader(fichierPrenom))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    listPrenom.Add(line);
                }
            }
        }

        //Pige un Nom 
        static public string FabriquerNom()
        {
            int indexNom = rand.Next(listNom.Count);
            int indexPrenom = rand.Next(listPrenom.Count);
            string nom = listPrenom[indexPrenom] + " " + listNom[indexNom];
            return nom;
        }

    }
}
