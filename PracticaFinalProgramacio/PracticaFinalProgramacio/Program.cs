using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinalProgramacio
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle v = new Vehicle();
            Maquina m = new Maquina();

            Gestio[] objectes = new Gestio[] { v, m };

            Gestio temp;

            // Operacions Vehicle v
            temp = objectes[0];
            temp.activar();

            // Vehicle actiu?
            if (temp.activat()) Console.WriteLine("Vehicle Activat");
            else Console.WriteLine("Vehicle No Activat");

            // Vehicle reservat?
            if (temp.reservat()) Console.WriteLine("Vehicle Reservat");
            else Console.WriteLine("Vehicle No Reservat");


            // Operacions Maquina m
            temp = objectes[1];
            temp.reservar();

            // Maquina activa?
            if (temp.activat()) Console.WriteLine("Maquina Activada");
            else Console.WriteLine("Maquina No Activada");

            // Maquina reservada?
            if (temp.reservat()) Console.WriteLine("Maquina Reservada");
            else Console.WriteLine("Maquina No Reservada");

            // Activar tota la maquinaria
            Console.WriteLine("------------\nActivant tot\n------------");
            foreach (Gestio x in objectes)
            {
                if (!x.activat()) x.activar();
            }


            // Vehicle actiu?
            temp = objectes[0];
            if (temp.activat()) Console.WriteLine("Vehicle Activat");
            else Console.WriteLine("Vehicle No Activat");
            // Maquina activa?
            temp = objectes[1];
            if (temp.activat()) Console.WriteLine("Maquina Activada");
            else Console.WriteLine("Maquina No Activada");

            Console.ReadKey();
        }
    }
}