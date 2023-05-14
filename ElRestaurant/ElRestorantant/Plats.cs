using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;

namespace ElRestorantant
{
    public class Plats
    {

        
        public string Nom { get; set; }
        public List<ingredients> LstIngredient { get; set; }
        public string Rarete { get; set; }
        public double PrixAchat { get; set; }
        public double PrixVente { get; set; }

        public Plats(string nom, List<ingredients> lstIngredient, string rarete, double prixAchat, double prixVente)
        {
            Nom = nom;
            LstIngredient = lstIngredient;
            Rarete = rarete;
            PrixAchat = prixAchat;
            PrixVente = prixVente;
        }

        //Fonction Achat Plat
        public static void Acheterplat(Restaurant resto)
        {
            List<ingredients> listIngredientDispo = Program.InitialiserIngredient();
            List<Plats> livreRecette = CreerPlats(listIngredientDispo);
            livreRecette.RemoveAt(3);

            int e = 0;
            foreach (Plats Recette in livreRecette)
            {
                AfficherPlat(livreRecette, Recette.Nom, e+1);
                e++;
            }
            Console.WriteLine("Choisissez un Plat en entrant son numéro :");
            int choix = Convert.ToInt32(Console.ReadLine());

            // Ajout le plats choisi à la liste des Plats
            Plats platChoisi = livreRecette[choix-1];
            Console.WriteLine($"Etes-vous sur de vouloir acheter {platChoisi.Nom} pour {platChoisi.PrixAchat}$. (O-Oui / N-Non)");
            string chx = Console.ReadLine();
            if (chx == "O")
            { 
                livreRecette.RemoveAt(choix - 1);
                resto.Menu.Add(platChoisi);
                resto.Monnaie = resto.Monnaie - platChoisi.PrixAchat;
                Console.WriteLine($"Le Plat {platChoisi.Nom} a été rajouté a votre Menu.");
            }
            else { Console.WriteLine("Achat Annuler"); }
        }
        public static void AfficherPlat(List<Plats> livreRecette, string nomPlat, int y)
        {
            Plats plat = livreRecette.Find(p => p.Nom == nomPlat);
            if (plat != null)
            {
                Console.WriteLine($"{y} - Nom: {plat.Nom}\nIngrédients:", Color.Red);
                foreach (var ingredient in plat.LstIngredient)
                {
                    Console.WriteLine($"- {ingredient.Nom}");
                }
                Console.WriteLine($"Rarete: {plat.Rarete}\nPrixAchat: {plat.PrixAchat}\nPrixVente: {plat.PrixVente}");
            }
            else
            {
                Console.WriteLine("Le plat demandé n'a pas été trouvé.");
            }
        }

        public void AfficherTousLesPlats(List<Plats> livreRecette, string nomPlat)
        {
            int e = 0;
            foreach (Plats plat in livreRecette)
            {
                AfficherPlat(livreRecette, nomPlat, e+1);
                Console.WriteLine(); // Ajoute une ligne vide entre chaque plat pour faciliter la lecture
                e++;
            }
        }

        public static Plats PreparePlat()
        {
            List<ingredients> listIngredientDispo = Program.InitialiserIngredient();
            List<Plats> livreRecette = CreerPlats(listIngredientDispo);

            return livreRecette[3];
        }
        public static List<Plats> CreerPlats(List<ingredients> ingredientsDisponibles)
        {
            List<Plats> plats = new List<Plats>();

            // Quiche au poulet et poivron
            plats.Add(new Plats("Quiche au poulet et poivron", new List<ingredients>
            {
                ingredientsDisponibles.Find(i => i.Nom == "Farine"),
                ingredientsDisponibles.Find(i => i.Nom == "Beurre"),
                ingredientsDisponibles.Find(i => i.Nom == "Oeuf"),
                ingredientsDisponibles.Find(i => i.Nom == "Lait"),
                ingredientsDisponibles.Find(i => i.Nom == "Poivron"),
                ingredientsDisponibles.Find(i => i.Nom == "Poivre"),
                ingredientsDisponibles.Find(i => i.Nom == "Poulet")

            }, "Rare", 100.00, 15.00));


            // Spaghetti bolognaise
            plats.Add(new Plats("Spaghetti bolognaise", new List<ingredients>
            {
                ingredientsDisponibles.Find(i => i.Nom == "Pâtes"),
                ingredientsDisponibles.Find(i => i.Nom == "Tomate"),
                ingredientsDisponibles.Find(i => i.Nom == "Ail"),
                ingredientsDisponibles.Find(i => i.Nom == "Poivre"),
                ingredientsDisponibles.Find(i => i.Nom == "Parmesan")
            }, "Moyenne", 250.00, 25.00));

            // Ratatouille
            plats.Add(new Plats("Ratatouille", new List<ingredients>
            {
                ingredientsDisponibles.Find(i => i.Nom == "Aubergine"),
                ingredientsDisponibles.Find(i => i.Nom == "Courgette"),
                ingredientsDisponibles.Find(i => i.Nom == "Poivron"),
                ingredientsDisponibles.Find(i => i.Nom == "Oignon"),
                ingredientsDisponibles.Find(i => i.Nom == "Tomate"),
                ingredientsDisponibles.Find(i => i.Nom == "Huile d'olive"),
                ingredientsDisponibles.Find(i => i.Nom == "Ail")
            }, "Moyenne", 100.00, 18.00));

            // Tarte aux pommes
            plats.Add(new Plats("Tarte aux pommes", new List<ingredients>
            {
                ingredientsDisponibles.Find(i => i.Nom == "Farine"),
                ingredientsDisponibles.Find(i => i.Nom == "Beurre"),
                ingredientsDisponibles.Find(i => i.Nom == "Sucre"),
                ingredientsDisponibles.Find(i => i.Nom == "Oeuf"),
                ingredientsDisponibles.Find(i => i.Nom == "Pomme")
            }, "Commune", 65.00, 9.00));

            plats.Add(new Plats("Gâteau au chocolat", new List<ingredients>
            {
                ingredientsDisponibles.Find(i => i.Nom == "Farine"),
                ingredientsDisponibles.Find(i => i.Nom == "Sucre"),
                ingredientsDisponibles.Find(i => i.Nom == "Oeuf"),
                ingredientsDisponibles.Find(i => i.Nom == "Beurre"),
                ingredientsDisponibles.Find(i => i.Nom == "Chocolat noir"),
                ingredientsDisponibles.Find(i => i.Nom == "Lait"),
                ingredientsDisponibles.Find(i => i.Nom == "Sel")
            }, "Rare", 150.00, 22.00));

            plats.Add(new Plats("Gratin d'aubergines et courgettes", new List<ingredients>
            {
                ingredientsDisponibles.Find(i => i.Nom == "Aubergine"),
                ingredientsDisponibles.Find(i => i.Nom == "Courgette"),
                ingredientsDisponibles.Find(i => i.Nom == "Oignon"),
                ingredientsDisponibles.Find(i => i.Nom == "Tomate"),
                ingredientsDisponibles.Find(i => i.Nom == "Fromage"),
                ingredientsDisponibles.Find(i => i.Nom == "Huile d'olive"),
                ingredientsDisponibles.Find(i => i.Nom == "Sel"),
                ingredientsDisponibles.Find(i => i.Nom == "Poivre")
            }, "Moyenne", 200.00, 22.00));


            return plats;
        }
    }

   
}
