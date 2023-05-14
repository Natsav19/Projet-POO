using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;

namespace ElRestorantant
{
    public class Restaurant
    {
        public string Nom { get; set; }
        public double Monnaie { get; set; }
        public int NbVente { get; set; }
        public int Popularité { get; set;}
        public List<Client> lstClient { get; set; }
        public List<Plats> Menu { get; set; }
        public List<ingredients> Inventaire { get; set; }
        public List<Employer> lstEmp { get; set; }



        public Restaurant(string nom)
        {
            Nom = nom;
            Monnaie = FabriqueNom.rand.Next(2000, 5001);
            NbVente = 0;
            Popularité = 1; 
            lstClient = new List<Client>();
            Inventaire = new List<ingredients>();
            Menu = new List<Plats>();
            Menu.Add(Plats.PreparePlat());
            lstEmp = new List<Employer>();
        }


        //Fonction qui donne les statistiques du restaurant
        public void RestoStats()
        {
            Console.WriteLine($"Statistique de Votre Restaurant --> {Nom}\n" +
                   $"Monnaie --> {Monnaie}\n" +
                   $"Nombre de Vente --> {NbVente}\n"+
                   $"Popularité --> {Popularité}\n");
            Console.WriteLine($"Voici Votre Menu :");
            foreach(Plats repas in Menu)
            {
                Console.WriteLine($"- {repas.Nom}");
            }
        }

        public void ObtenirClient(List<Plats> Menu)
        {
            int moy = (Popularité * 20)/2;
            int rdm = FabriqueNom.rand.Next(2, moy);
            int nbClient = 0;
            foreach(Client client in lstClient)
            {
                lstClient.Remove(client);
            }
            for (int i = 0; i < rdm; i++)
            {
                Client client = new Client(Menu);
                lstClient.Add(client);
                nbClient = i;
            }
            Console.WriteLine($"Vous Avez {nbClient + 1} client(e)s aujourd'hui ! Voici la liste des clients :\n");
            AfficherClient(lstClient);
        }
        public void AfficherClient(List<Client> lstClient)
        {
            foreach(Client client in lstClient)
            {
                Console.WriteLine($"Voici le nom du Client --> {client.Nom}");
                Console.WriteLine($"Voici l'humeur du Client -> {client.HumeurClient}\n");
                Console.WriteLine($"Voici sa facture --> {client.Facture.Nom}\n");
            }
        }

        //Partie Employer 
        public double EngagerEmp(Restaurant resto)
        {
            List<Employer> lstChaumeur = new List<Employer>();
            for (int i = 0; i < 5; i++)
            {
                Employer employer = new Employer();
                lstChaumeur.Add(employer);
            }

            int y = 0;
            foreach (Employer emp in lstChaumeur)
            {
                Console.WriteLine($"{y+1}- {emp.Nom} (Bonus : {emp.BonusEmp}, Rareté : {emp.RareteEmp}, Prix : {emp.Prix}$)");
                y++;
            }
            Console.WriteLine("Choisissez un Employer en entrant son numéro :");
            int choix = Convert.ToInt32(Console.ReadLine());

            Employer EmpChoisi = lstChaumeur[choix - 1];
            Console.WriteLine($"Etes-vous sur de vouloir acheter {EmpChoisi.Nom}-{EmpChoisi.RareteEmp} pour le prix de {EmpChoisi.Prix}$. (O-Oui/N-Non)");
            string chx = Console.ReadLine();
            if(chx == "O")
            {
                EmpChoisi.ObtenirBonus(EmpChoisi, resto);
                lstChaumeur.RemoveAt(choix - 1);
                lstEmp.Add(EmpChoisi);
                Monnaie = Monnaie - EmpChoisi.Prix;
                return Monnaie;
            }
            else
            {
                Console.WriteLine("Achat Annulé !");
                return Monnaie;
            }
        }

        public void CompleterFacture(Restaurant resto)
        {
            foreach(Client client in resto.lstClient)
            {
                client.ServirClient(resto);
                client.ObtenirPourboire(resto);
                resto.NbVente += 1; 
            }
            Console.WriteLine("PASSONS AUX JOURS SUIVANT ! TOUCHER UNE TOUCHE.");
            Console.ReadKey();

        }
    }
}
    
   