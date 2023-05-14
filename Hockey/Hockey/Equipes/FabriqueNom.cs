using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hockey
{
    public class FabriqueNom
    {
        static List<string> listNom = new List<string>();
        static public Random rand = new Random();

        public static List<string>  RemplirListe()
        {
            List<string> listEquip = AjouterNom();
            return listEquip;
        }

        //Usine a Nom Des Équipes
        public static List<string> AjouterNom()
        {
            string fichierNom = "nom_equipe.txt";

            using (StreamReader reader = new StreamReader(fichierNom))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    listNom.Add(line);
                }
            }
            return listNom;
        }

        //Pige un Nom 
        static public string FabriquerNom()
        {
            int indexNom = rand.Next(listNom.Count);
            string nom = listNom[indexNom];
            return nom;
        }

    }
}
