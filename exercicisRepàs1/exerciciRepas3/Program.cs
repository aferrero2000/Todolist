using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciciRepas3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Demanar dos valors
            Console.WriteLine("Escriu un numero: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Escriu un altre numero: ");
            int num2 = int.Parse(Console.ReadLine());

            int total = 1; // Variable on es guarda el total, IMPORTANT inicialitzada a 1 perque cualsevol altre valor donaria un resultat incorrecte

            if (num2 < num1) // Comprovació per tal de que <num1> sigui més petit que <num2> i sino corregir-ho
            {
                num1 += num2;
                num2 = num1 - num2;
                num1 -= num2;
            }

            for (; num1 <= num2; num1++){ // Bucle amb tots els valors entre els valors
                total *= num1; // Factorial amb les iteracions
            }
            Console.WriteLine(total); // Mostrar total

            Console.ReadKey();
        }
    }
}
