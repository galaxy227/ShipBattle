using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipBattle.Components
{
    internal class Engine : Component
    {
        private int _thrust;

        public int Thrust { get { return _thrust; } }

        protected Engine(int cost, int size, int health, int thrust) :
            base(cost, size, health)
        {
            // Initialize private variables
            _thrust = thrust;
        }
    }
}
