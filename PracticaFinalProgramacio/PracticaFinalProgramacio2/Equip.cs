using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinalProgramacio2
{
    class Equip
    {
        private string _club;
        private string _tipus;
        private List<Jugador> jugadors;

        public Equip()
        {
            _club = "";
            _tipus = "";
            jugadors = new List<Jugador> { };
        }

        public Equip(string xclub, string xtipus, List<Jugador> xjugadors)
        {
            _club = xclub;
            _tipus = xtipus;
            jugadors = xjugadors;
        }

        public string getClub()
        {
            return _club;
        }

        public void setClub(string value)
        {
            _club = value;
        }

        public string getTipus()
        {
            return _tipus;
        }

        public void setTipus(string value)
        {
            _tipus = value;
        }

        public void afegirJugador(Jugador xjugador)
        {
            jugadors.Add(xjugador);
        }

        public List<Jugador> obtenirJugadors()
        {
            return jugadors;
        }
    }
}
