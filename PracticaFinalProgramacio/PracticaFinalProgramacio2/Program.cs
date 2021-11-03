using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinalProgramacio2
{
    class Program
    {
        static void Main(string[] args)
        {
            Jugador jugador1 = new Jugador("Roger", 12, 21);
            Jugador jugador2 = new Jugador("Maria", 9, 20);
            List<Jugador> jugadors = new List<Jugador> { };
            jugadors.Add(jugador1);
            jugadors.Add(jugador2);

            Equip equip1 = new Equip("Barça", "Futbol", jugadors);
            List<Equip> equips = new List<Equip> { };
            equips.Add(equip1);

            Lliga lliga1 = new Lliga(equips);
        }
    }
}
