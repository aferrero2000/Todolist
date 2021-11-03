using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciciRepàs2
{
    class Program
    {
        static void Main(string[] args)
        {
            int temp;
            for(int i = 0; i <= 10; i++) // Bucle de 0 a 10
            {
                temp = i;
                while(temp > 0) // Repetir aquest bucle tants cops com valor de "i"
                {
                    Console.Write("x"); // Escriure "x"
                    temp--;
                }
                Console.Write(" {0}|", i); // Escriure numero iteració o valor de "i"
            }
            Console.ReadKey();
        }
    }
}
