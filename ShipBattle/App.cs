using ShipBattle.Components;
using ShipBattle.Components.Defenses;
using ShipBattle.Components.Weapons;
using System;

namespace ShipBattle
{
    internal class App
    {
        Round round1 = new();
        public static Random RandomGenerator = new();

        public App()
        {

        }

        public void Run()
        {
            Ship ship1 = new("Red Hand");
            ship1.AddComponent(new Laser(10, 10, 10, 10, 10), 1);
            ship1.AddComponent(new Missile(10, 10, 10, 10, 10), 1);
            ship1.AddComponent(new Shield(10, 10, 10, 10, 10), 10);
            ship1.AddComponent(new Armor(10, 10, 10, 10, 10), 10);
            ship1.AddComponent(new Engine(10, 10, 10, 10), 10);

            Ship ship2 = new("Blue Hand");
            ship2.AddComponent(new Laser(10, 10, 10, 10, 10), 1);
            ship2.AddComponent(new Missile(10, 10, 10, 10, 10), 1);
            ship2.AddComponent(new Shield(10, 10, 10, 10, 10), 10);
            ship2.AddComponent(new Armor(10, 10, 10, 10, 10), 10);
            ship2.AddComponent(new Engine(10, 10, 10, 10), 10);

            round1.SimulateCombat(ship1, ship2);
          
            Console.WriteLine();
        }
    }
}
