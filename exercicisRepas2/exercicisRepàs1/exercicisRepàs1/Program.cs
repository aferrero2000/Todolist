using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicisRepàs1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Demanar dos nombres
            Console.WriteLine("Escriu un numero: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Escriu un altre numero: ");
            int num2 = int.Parse(Console.ReadLine());

            //Bucle entre el primer i segon valor
            for(; num1 <= num2; num1++)
            {
                if (num1 % 2 == 1) // Comprovar que el valor es imparell
                {
                    Console.WriteLine(num1); // Ensenyar el valor
                }
            }
            Console.ReadKey();
        }
    }
}
