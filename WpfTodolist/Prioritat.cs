using System;
using System.Collections.Generic;
using System.Text;

namespace WpfTodolist
{
    class Prioritat
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Color { get; set; }

        Prioritat(int new_id, string new_nom, string new_color)
        {
            Id = new_id;
            Nom = new_nom;
            Color = new_color;
        }
    }
}
