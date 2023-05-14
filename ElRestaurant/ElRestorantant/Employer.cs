using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElRestorantant
{
    public enum Bonus
    {
        Prix,
        Popularité,
        Pourboire,
    }
    public enum Rarete
    {
        Commun,
        Rare,
        epic,
    }
    public class Employer
    {
        public string Nom { get; set; }
        public Bonus BonusEmp { get; set; }
        public Rarete RareteEmp { get; set; } 
        public int Prix { get; set; }

        public Employer()
        {
            Nom = FabriqueNom.FabriquerNom();

            //Setting de l'humeur du client 
            int nb = FabriqueNom.rand.Next(0, 3);
            BonusEmp = (Bonus)nb;

            //Rareté
            RareteEmp = (Rarete)FabriqueNom.rand.Next(0, 3);


            //Setting du Prix
            if (RareteEmp == Rarete.Commun)
            {
                Prix = FabriqueNom.rand.Next(250, 501);
            }
            else if (RareteEmp == Rarete.Rare)
            {
                Prix = FabriqueNom.rand.Next(1000, 2001);
            }
            else
            {
                Prix = FabriqueNom.rand.Next(3000, 5001);
            }
        }

        public void ObtenirBonus(Employer emp, Restaurant resto)
        {
            if (emp.BonusEmp == Bonus.Prix)
            {
                List<ingredients> listIngredientDispo = Program.InitialiserIngredient();
                foreach(ingredients igd in listIngredientDispo)
                {
                    if (emp.RareteEmp == Rarete.Commun)
                    {
                        igd.Prix = igd.Prix - ((2 * igd.Prix) / 100);
                    }
                    else if (emp.RareteEmp == Rarete.Rare)
                    {
                        igd.Prix = igd.Prix - ((5 * igd.Prix) / 100);
                    }
                    else { igd.Prix = igd.Prix - ((10 * igd.Prix) / 100); }
                }
            }
            if (emp.BonusEmp == Bonus.Popularité)
            {
                if (emp.RareteEmp == Rarete.Commun)
                {
                    resto.Popularité += 5;
                }
                else if (emp.RareteEmp == Rarete.Rare)
                {
                    resto.Popularité += 10;
                }
                else { resto.Popularité += 15; }
            }
            else
            {
                foreach(Client client in resto.lstClient)
                { 
                    if (emp.RareteEmp == Rarete.Commun)
                    {
                        resto.Monnaie += 2;
                    }
                    else if (emp.RareteEmp == Rarete.Rare)
                    {
                        resto.Monnaie += 3;
                    }
                    else { resto.Monnaie += 5; }
                }
            }
        }

    }
}
