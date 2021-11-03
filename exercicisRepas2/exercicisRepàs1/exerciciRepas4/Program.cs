using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciciRepas4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Demanar text
            Console.WriteLine("Escriu una cadena de text: ");
            string str = (Console.ReadLine());
            string isosceles = "";
            // Demanar manera mostrar-lo amb "do_while" per comprovar entrada correcte
            do
            {
                Console.WriteLine("Vols que sigui isosceles? (s/n) ");
                isosceles = (Console.ReadLine());
            } while (isosceles != "s" && isosceles != "n");

            int temp, sangria;

            if (isosceles == "s" || isosceles == "S") // En cas de triangle Isósceles
            {
                int impar;
                // Detectar si el text té una quantitat de caràcters par o no
                if (str.Length % 2 == 0)
                {
                    impar = 0;
                }
                else
                {
                    impar = 1;
                }

                int puntMig = str.Length / 2 + impar; // Detectar punt mig del text

                for (int i = 1; i <= puntMig; i++)
                    {

                    sangria = 0;    
                    temp = 0;
                    
                    // Inserir espais necesaris abans del text per mantenir la forma
                    while(sangria < puntMig - i)
                    {
                        Console.Write(" ");
                        sangria++;
                    }

                    // Bucle per escriure els caracters
                    while(temp < i*2 - impar)
                    {
                        Console.Write(str[puntMig - i + temp]); // Escriure caracters corresponents a la iteració
                        temp++;
                    }
                    Console.WriteLine();
                }
            }
            else if (isosceles == "n" || isosceles == "N") // En cas de triangle NO isosceles
            {
                for (int i = 0; i < str.Length; i++) // Bucle incrementla fins al ultim caracter del text
                {
                    temp = 0;

                    // Bucle per escriure tants caràcters com iteracions <FOR> fetes
                    while (temp <= i)
                    {
                        Console.Write(str[temp]);
                        temp++;
                    }
                    Console.WriteLine();
                }
            }

            Console.ReadKey();
        }
    }
}
