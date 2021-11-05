using System;
using System.Collections.Generic;
using System.Text;

namespace WpfTodolist
{
    class Responsable
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        Responsable(int new_id, string new_nom)
        {
            Id = new_id;
            Nom = new_nom;
        }
    }
}
