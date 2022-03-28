using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShipBattle.Components.Weapons;

namespace ShipBattle
{
    internal class App
    {
        public App()
        {

        }

        public void Run()
        {
            Ship ship1 = new("Starfighter");

            for (int i = 0; i < 10; i++)
                ship1.componentList.Add(new Laser(10, 10, 10, 10, 10));

            Console.WriteLine($"{ship1.Name} total damage: {ship1.GetTotalDamage()}");
        }
    }
}
