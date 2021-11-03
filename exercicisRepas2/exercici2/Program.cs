using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercici2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variables
            int[] vector1;
            int s;
            float m;

            // Crida de funcions
            LlegirVector(out vector1);
            OperarVector(vector1, out s, out m);

            //Mostrar resultat
            Console.WriteLine("La suma es {0:d} i la mitja {1:f2}", s, m);
            Console.ReadKey();
        }

        // Funció per inserir dades al vector
        static void LlegirVector(out int[] vector)
        {
            int input, comptador = 0;
            vector = new int[5];
            while (comptador < vector.Length) // Bucle perque l'usuari introdueixi els valors necesaris per el vector
            { 
                // Demanar valor
                Console.WriteLine("Insereix un valor");
                string value = Console.ReadLine();

                // Comprovar que el valor es un nombre
                if (int.TryParse(value, out input)) 
                {
                    vector[comptador] = input;
                    comptador++;
                }
            }
        }

        // Funció per fer operacions amb el vector
        static void OperarVector(int[] vector, out int suma, out float mitjana)
        {
            suma = 0;
            mitjana = 0.0f;

            // Sumar tots els valors del vector al total
            for(int i = 0; i < vector.Length; i++)
            {
                suma += vector[i];
                mitjana += 1; // Contar valors sumats
            }

            // Fer mitjana
            mitjana = suma / mitjana;
        }
    }
}
