using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipBattle.Components
{
    internal class Weapon : Component
    {
        private int _damage;
        private int _range;

        public int Damage { get { return _damage; } }
        public int Range { get { return _range; } }

        protected Weapon(int cost, int size, int health, int damage, int range) :
            base(cost, size, health)
        {
            // Initialize private variables
            _damage = damage;
            _range = range;
        }
    }
}
