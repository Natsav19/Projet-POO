using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace ElRestorantant
{


    public enum Qualite
    {
        Moyenne,
        Bonne,
        Excellente,
    }
    public class ingredients
    {

        public string Nom { get; set; }
        public int Calorie { get; set; }
        public Qualite Qualiteinc { get; set; }
        public float Prix { get; set; }

        [JsonConstructor]
        public ingredients(string nom, int calorie, string qualite, float prix)
        {
            Nom = nom;
            Calorie = calorie;
            if (qualite.Contains("Moyenne"))
                Qualiteinc = Qualite.Moyenne;
            else if (qualite.Contains("Bonne"))
                Qualiteinc = Qualite.Bonne;
            else if (qualite.Contains("Excellente"))
                Qualiteinc = Qualite.Excellente;
            else
                Qualiteinc = Qualite.Moyenne;
            Prix = prix;

        }

    }

    public static class JsonFileLoader
    {
        public static T ChargerFicher<T>(string nomFichier)
        {
            try
            {
                using (StreamReader reader = new StreamReader (nomFichier))
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
