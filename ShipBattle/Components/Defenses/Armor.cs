using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipBattle.Components.Defenses
{
    internal class Armor : Defense
    {
        public Armor(int cost, int size, int health, int rating, int regen) :
            base(cost, size, health, rating, regen)
        {

        }
    }
}
