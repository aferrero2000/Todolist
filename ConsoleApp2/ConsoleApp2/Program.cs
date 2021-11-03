using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3_Caixa_Negra_Equacio
{
    class Equaciodesegongrau
    {
        // a X2 + b X + c = 0 
        public static double[] Calcula(int a, int b, int c)
        {
            double arrel = Math.Sqrt((b * b) - 4 * a * c);
            double[] resultat1 = { 0.0, 0.0 };
            double[] resultat2 = { 0.0 };
            if (arrel > 0)
            {
                resultat1[0] = (-b + arrel) / 2 * a;
                resultat1[1] = (-b - arrel) / 2 * a;
                return resultat1;
            }
            else if (arrel == 0.0)
            {
                resultat2[0] = -b / 2 * a;
                return resultat2;
            }
            else return null;


        }
    }
    class EquaciodesegongrauTest
    {
        static void Main(string[] args)
        {
            double[] resultat;

            Console.WriteLine("\nProva 1");
            resultat = Equaciodesegongrau.Calcula(1, 2, 1);
            if (resultat.Length == 1) { Console.WriteLine("Resultat: " + resultat[0]); }
            else if (resultat.Length == 2) { Console.WriteLine("Resultat 1: " + resultat[0] + "\nResultat 2: " + resultat[1]); }

            Console.WriteLine("\nProva 2");
            resultat = Equaciodesegongrau.Calcula(-3, 2, 1);
            if (resultat.Length == 1) { Console.WriteLine("Resultat: " + resultat[0]); }
            else if (resultat.Length == 2) { Console.WriteLine("Resultat 1: " + resultat[0] + "\nResultat 2: " + resultat[1]); }

            Console.WriteLine("\nProva 3");
            resultat = Equaciodesegongrau.Calcula(5, 2, 7);
            if (resultat.Length == 1) { Console.WriteLine("Resultat: " + resultat[0]); }
            else if (resultat.Length == 2) { Console.WriteLine("Resultat 1: " + resultat[0] + "\nResultat 2: " + resultat[1]); }
        }
    }
}
