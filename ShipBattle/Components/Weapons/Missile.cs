using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipBattle.Components.Weapons
{
    internal class Missile : Laser
    {
        public Missile(int cost, int size, int health, int damage, int range) :
            base(cost, size, health, damage, range)
        {

        }
    }
}
