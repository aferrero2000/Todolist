using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercici3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear, omplir i mostrar matriu
            int[,] matriu;
            omplirMatriu(out matriu);
            mostrar(matriu);
            Console.ReadKey();
        }

        static void omplirMatriu(out int[,] value) // Ínserir valors a la matriu
        {
            value = new int[3, 5];
            // Recorregut per la matriu
            for(int i = 0; i <= value.GetUpperBound(0); i++)
            {
                for(int j = 0; j <= value.GetUpperBound(1); j++)
                {
                    value[i, j] = i + j; // Omplir posició de la matriu en funció de la mateixa
                }
            }
        }

        static void mostrar(int[,] value) // Llegir i mostrar matriu per consola
        {
            // Recorregut per la matriu
            for (int i = 0; i <= value.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= value.GetUpperBound(1); j++)
                {
                    Console.Write(value[i, j]); // Llegir posició
                }
                Console.WriteLine();
            }
        }
    }
}
