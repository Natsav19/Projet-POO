using System;
using CalculateurLibrary;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            int x = 0;
            int y = 0;
            double total = 0;
            Calculateur calculateur = new Calculateur();
            Console.WriteLine("ENTREZ UN 1er CHIFFRE (X).");
            x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ENTREZ UN 2eme CHIFFRE (Y).");
            y = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Menu d'Action\n" +
                "(1) Addition\n" +
                "(2) Soustraction\n" +
                "(3) Division\n" +
                "(4) Multiplication\n" +
                "(5) Exposant\n" +
                "(6) Logarithme\n");
            int choix = Convert.ToInt32(Console.ReadLine());
            switch (choix)
            {
                case 1:
                    total = calculateur.Addition(x, y);
                    break;
                case 2:
                    total = calculateur.Soustraction(x, y);
                    break;
                case 3:
                    total = calculateur.Division(x, y);
                    break;
                case 4:
                    total = calculateur.Multiplication(x, y);
                    break;
                case 5:
                    total = calculateur.Exposant(x, y);
                    break;
                case 6:
                    total = calculateur.Logarithme(x, y);
                    break;
            }
            Console.WriteLine($"{total}");

        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Division Impossible Par 0");
            Console.WriteLine(ex.Message);
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("Dépassement de l'entier!");
            Console.WriteLine(ex.Message);
        }
    }
}
