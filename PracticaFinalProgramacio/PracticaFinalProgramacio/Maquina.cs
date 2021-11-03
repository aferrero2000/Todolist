using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinalProgramacio
{
    class Maquina : Gestio
    {
        private bool _actiu;
        private bool _reservat;

        public Maquina()
        {
            _actiu = false;
            _reservat = false;
        }

        void Gestio.activar()
        {
            _actiu = !_actiu;
        }

        void Gestio.reservar()
        {
            _reservat = !_reservat;
        }

        bool Gestio.activat()
        {
            return _actiu;
        }

        bool Gestio.reservat()
        {
            return _reservat;
        }
    }
}
