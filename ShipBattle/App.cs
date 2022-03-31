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
            Ship ship1 = new("Red Hand");
            ship1.AddComponent(ComponentType.Laser, 1);
            ship1.AddComponent(ComponentType.Missile, 1);
            ship1.AddComponent(ComponentType.Shield, 10);
            ship1.AddComponent(ComponentType.Armor, 10);
            ship1.AddComponent(ComponentType.Engine, 10);

            Ship ship2 = new("Blue Hand");
            ship2.AddComponent(ComponentType.Laser, 1);
            ship2.AddComponent(ComponentType.Missile, 1);
            ship2.AddComponent(ComponentType.Shield, 10);
            ship2.AddComponent(ComponentType.Armor, 10);
            ship2.AddComponent(ComponentType.Engine, 10);

            Combat.SimulateCombat(ship1, ship2);

            Console.WriteLine();
        }
    }
}
