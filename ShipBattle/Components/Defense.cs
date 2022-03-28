using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipBattle.Components
{
    internal class Defense : Component
    {
        private int _rating;
        private int _regen;

        public int Rating { get { return _rating; } }
        public int Regen { get { return _regen; } }

        public Defense(int cost, int size, int health, int rating, int regen) :
            base(cost, size, health)
        {
            // Initialize private variables
            _rating = rating;
            _regen = regen;
        }
    }
}
