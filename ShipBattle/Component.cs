using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipBattle
{
    internal class Component
    {
        private int _cost;
        private int _size;
        private int _health;

        public int Cost { get { return _cost; } }
        public int Size { get { return _size; } }
        public int Health { get { return _health; } }

        protected Component(int cost, int size, int health)
        {
            // Initialize private variables.
            _cost = cost;
            _size = size;
            _health = health;
        }
    }
}
