using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipBattle
{
    class App
    {
        public App()
        {

        }

        public void Run()
        {
            Ship ship1 = new();

            ship1.AddComponent(ComponentType.Laser, 25);
            ship1.AddComponent(ComponentType.Missile, 25);

            ship1.GetTotalDamage(ComponentType.Laser);
        }
    }
}
