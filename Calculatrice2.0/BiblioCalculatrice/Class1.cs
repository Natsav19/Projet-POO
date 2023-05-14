using System;

namespace CalculateurLibrary
{
    public class Calculateur
    {
        // Fonction Addition
        public double Addition(int x, int y)
        {
            double total = x + y;
            return total;
        }

        // Fonction Soustraction
        public double Soustraction(int x, int y)
        {
            double total = x - y;
            return total;
        }

        // Fonction Division
        public double Division(int x, int y)
        {
            double total = x / y;
            return total;
        }

        // Fonction Multiplication
        public double Multiplication(int x, int y)
        {
            double total = x * y;
            return total;
        }

        // Fonction Exposant
        public double Exposant(int x, int y)
        {
            double z = Math.Pow(x, y);
            return z;
        }

        // Fonction Logarithme
        public double Logarithme(int x, int y)
        {
            double total = Math.Log(x, y);
            return total;
        }
    }
}
