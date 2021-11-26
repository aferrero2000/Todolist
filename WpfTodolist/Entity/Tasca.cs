﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WpfTodolist.Entity
{
    public class Tasca
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Descripcio { get; set; }
        public DateTime Data_creacio { get; set; }
        public DateTime Data_finalitzacio { get; set; }
        public int Responsable { get; set; }
        public string Prioritat { get; set; }
        public string Estat { get; set; }
    }
}
