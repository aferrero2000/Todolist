using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

	public class Buscador
	{
		public static bool buscar(int paramInt, int[] paramArrayOfInt)
		{
			int i = 0;
			do
			{
				if (paramInt == paramArrayOfInt[i])
				{
					return true;
				}
				i++;
			} while (i < paramArrayOfInt.Length - 1);
			return false;
		}
	}

	//	Prova 1: busca un element que no estigui a l’array.
	//  Prova 2: busca un element que hi sigui, més o menys, al mig de l’array.
	//  Prova 3: busca l’element que està a la última posició de l’array.
	//  Prova 4: busca l’element que està a la primera posició de l’array.
	//	Prova 5: busca l’element d’un array que només contingui un element.
	//	Prova 6: busca un element d’un array que està buit.

	class ProvaBuscador
	{
		static void Main(string[] args)
		{
			int[] arr = { 1, 2, 4, 5, 6, 7, 9 };
			int[] arr2 = { 2 };
			int[] arr3 = { };

			Console.WriteLine("Prova 1");
			if (Buscador.buscar(3, arr)) Console.WriteLine("S'ha trobat el valor al array\n");
			else Console.WriteLine("No s'ha trobat el valor a l'array\n");

			Console.WriteLine("Prova 2");
			if (Buscador.buscar(5, arr)) Console.WriteLine("S'ha trobat el valor al array\n");
			else Console.WriteLine("No s'ha trobat el valor a l'array\n");

			Console.WriteLine("Prova 3");
			if (Buscador.buscar(9, arr)) Console.WriteLine("S'ha trobat el valor al array\n");
			else Console.WriteLine("No s'ha trobat el valor a l'array\n");

			Console.WriteLine("Prova 4");
			if (Buscador.buscar(1, arr)) Console.WriteLine("S'ha trobat el valor al array\n");
			else Console.WriteLine("No s'ha trobat el valor a l'array\n");

			Console.WriteLine("Prova 5");
			if (Buscador.buscar(2, arr2)) Console.WriteLine("S'ha trobat el valor al array\n");
			else Console.WriteLine("No s'ha trobat el valor a l'array\n");

			Console.WriteLine("Prova 6");
			if (Buscador.buscar(3, arr3)) Console.WriteLine("S'ha trobat el valor al array\n");
			else Console.WriteLine("No s'ha trobat el valor a l'array\n");
		}
	}
}