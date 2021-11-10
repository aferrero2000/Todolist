using System;
using System.Collections.Generic;
using System.Text;

namespace WpfTodolist
{
    class Tasca
    {
        public int Codi { get; set; }
        public string Nom { get; set; }
        public string Descripcio { get; set; }
        public DateTime Data_creacio { get; set; }
        public DateTime Data_finalitzacio { get; set; }
        public int Responsable { get; set; }
        public int Prioritat { get; set; }

        public Tasca(int new_codi, string new_nom, string new_descripcio, DateTime new_data_creacio, DateTime new_data_finalitzacio, int new_responsable, int new_prioritat)
        {
            Codi = new_codi;
            Nom = new_nom;
            Descripcio = new_descripcio;
            Data_creacio = new_data_creacio;
            Data_finalitzacio = new_data_finalitzacio;
            Responsable = new_responsable;
            Prioritat = new_prioritat;
        }
    }
}
