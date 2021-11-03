using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinalProgramacio2
{
    class Jugador
    {
        private string _nom;
        private int _dorsal;
        private int _edat;

        public Jugador()
        {
            _nom = "";
            _dorsal = -1;
            _edat = -1;
        }

        public Jugador(string xnom, int xdorsal, int xedat)
        {
            _nom = xnom;
            _dorsal = xdorsal;
            _edat = xedat;
        }

        public string getNom()
        {
            return _nom;
        }

        public void setNom(string value)
        {
            _nom = value;
        }

        public int getDorsal()
        {
            return _dorsal;
        }

        public void setDorsal(int value)
        {
            _dorsal = value;
        }

        public int getEdat()
        {
            return _edat;
        }

        public void setEdat(int value)
        {
            _edat = value;
        }
    }
}
