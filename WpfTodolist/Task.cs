using System;
using System.Collections.Generic;
using System.Text;

namespace WpfTodolist
{
    class Task
    {
        private int _codi;
        private string _nom;
        private string _descripcio;
        private DateTime _data_creacio;
        private DateTime _data_finalitzacio;
        private string _responsable;
        
        public Task(int new_codi, string new_nom, string new_descripcio, DateTime new_data_creacio, DateTime new_data_finalitzacio, string new_responsable)
        {
            _codi = new_codi;
            _nom = new_nom;
            _descripcio = new_descripcio;
            _data_creacio = new_data_creacio;
            _data_finalitzacio = new_data_finalitzacio;
            _responsable = new_responsable;
        }

        public int Codi { get; set; }
        public string Nom { get; set; }
        public string Descripcio { get; set; }
        public DateTime Data_creacio { get; set; }
        public DateTime Data_finalitzacio { get; set; }
        public string Responsable { get; set; }
    }
}
