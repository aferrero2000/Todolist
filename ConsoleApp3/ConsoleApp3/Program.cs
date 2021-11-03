using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmplirNumeros
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            int[] taula = new int[n];

            taula = Omplir(n);
            int suma = Sumar(taula);

            Console.WriteLine("La suma és: " + suma);
            Console.ReadKey();

        }

        private static int[] Omplir(int n)
        {
            int[] resultat = new int [n];

            for (int i = 0; n > 0; n--, i++)
            {
                Random rnd = new Random();
                int num_aleatori = rnd.Next(0, 50);
                Console.WriteLine(num_aleatori);
                resultat[i] = num_aleatori;
            }
            return resultat;
        }

        private static int Sumar(int[] taula)
        {
            int total = 0;

            for(int i = 0; i < taula.Length; i++)
            {
                total += taula[i];
            }

            return total;
        }
    }
}
