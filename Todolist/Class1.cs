using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repas_3_03
{
    class ToDoList
    {
        private string _nom;
        List<string> _todolistlist = new List<string>();

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public List<string> ToDoListList
        {
            get { return _todolistlist; }
            set { _todolistlist.Add(_nom); }
        }

        //Constructors
        public ToDoList()
        {
            _nom = "";
            _todolistlist = ToDoListList;
        }

        public ToDoList(String nom, List<string> jugador)
        {
            this.Nom = nom;
            this.ToDoListList = jugador;
        }



        //Mètodes

        public void Afegir()
        {
            string nom;
            Console.WriteLine("Insereix el nom: ");
            nom = Console.ReadLine();
            Nom = nom;
            ToDoListList = _todolistlist;
        }

        public void Eliminar()
        {
            Console.WriteLine("Insereix el numero: ");
            int num = Convert.ToInt32(Console.ReadLine());
            _todolistlist.RemoveAt(num-1);
        }

        public void Mostrar()
        {
            int j;
            j = 0;
            foreach (var i in _todolistlist)
            {
                j++;
                Console.WriteLine($"{j}. {i}");
            }
        }

        public void MostrarTodo()
        {
            string equip;
            Console.WriteLine("Insereix el nom de l'equip: ");
            equip = Console.ReadLine();
            foreach (var Nom in ToDoListList)
            {
                if (Nom.Contains(equip))
                {
                    Console.WriteLine($"Hello {Nom}!");
                }
            }

        }

        public void Menu()
        {
            int num;
            do
            {
                Console.WriteLine("Select the number of your choice: ");
                Console.WriteLine("1: Afegir to do");
                Console.WriteLine("2: Eliminar to do");
                Console.WriteLine("3: Mostrar to do list");
                Console.WriteLine("4: Sortir");
                num = Convert.ToInt32(Console.ReadLine());

                switch (num)
                {
                    case 1:
                        {
                            Afegir();
                        }
                        break;

                    case 2:
                        {
                            Eliminar();
                        }
                        break;

                    case 3:
                        {
                            Mostrar();
                        }
                        break;

                    case 4:
                        {
                            return;
                        }
                    default:
                        {
                            break;
                        }
                }
            } while (num != 4);
        }
     }

}