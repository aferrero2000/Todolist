using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinalProgramacio2
{
    class Lliga
    {
        private List<Equip> equips;

        public Lliga()
        {
            equips = new List<Equip> { };
        }

        public Lliga(List<Equip> xequips)
        {
            equips = xequips;
        }

        public void afegirEquip(Equip xequip)
        {
            equips.Add(xequip);
        }

        public List<Equip> llegirEquips()
        {
            return equips;
        }
    }
}
