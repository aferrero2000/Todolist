using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercici1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Demanar entrada de text
            Console.WriteLine("Entra una cadena de text: ");
            string text = Console.ReadLine();

            //Mostrar resultat de la funció
            Console.WriteLine("El text té {0:d} vocals", comptarVocals(text));
            Console.ReadKey();
        }
        static int comptarVocals(string value) // Funció per comptar quantitat de vocals
        {
            int totalVocals = 0;
            for(int i = 0; i < value.Length; i++) // Llegir tots el caracters del text
            {
                // Sumar 1 al total si el caracter es vocal
                if(
                    value[i] == 'a' || value[i] == 'A' ||
                    value[i] == 'e' || value[i] == 'E' ||
                    value[i] == 'i' || value[i] == 'I' ||
                    value[i] == 'o' || value[i] == 'O' ||
                    value[i] == 'u' || value[i] == 'U')
                {
                    totalVocals++;
                }
            }
            return totalVocals;
        }
    }
}
