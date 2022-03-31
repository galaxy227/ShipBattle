using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShipBattle.Components.Defenses;
using ShipBattle.Components.Weapons;
using ShipBattle.Components;

namespace ShipBattle
{
    internal class Combat
    {
        private static int turnCount = 1;
        private static int distance;

        private static int shieldOfShip1;
        private static int armorOfShip1;
        private static int shieldOfShip2;
        private static int armorOfShip2;

        public static void SimulateCombat(Ship ship1, Ship ship2)
        {
            // do at start
            SetPosition(ship1, ship2);

            distance = GetDistance(ship1, ship2);

            shieldOfShip1 = GetTotalShield(ship1);
            armorOfShip1 = GetTotalArmor(ship1);
            shieldOfShip2 = GetTotalShield(ship2);
            armorOfShip2 = GetTotalArmor(ship2);

            // Loop until one player has no health.
            while (HasHealth(ship1) && HasHealth(ship2))
            {
                Console.WriteLine("Turn: " + turnCount);
                Console.WriteLine();

                ApplyDamage(ship1, ship2);

                DestroyComponent(ship1, ship2);

                //PrintHealth(ship1, ship2);
                Console.WriteLine("Red Hand");
                Console.WriteLine("Shield: " + shieldOfShip1);
                Console.WriteLine("Armor: " + armorOfShip1);
                Console.WriteLine("Health: " + GetTotalHealth(ship1));
                Console.WriteLine();
                Console.WriteLine("Blue Hand");
                Console.WriteLine("Shield: " + shieldOfShip2);
                Console.WriteLine("Armor: " + armorOfShip2);
                Console.WriteLine("Health: " + GetTotalHealth(ship2));

                turnCount++;

                Console.ReadLine();
            }

            // text when ship is destroyed
            if (!HasHealth(ship1))
            {
                Console.WriteLine(ship1.Name + " has been destroyed!");
            }
            else
            {
                Console.WriteLine(ship2.Name + " has been destroyed!");
            }
        }

        private static void SetPosition(Ship ship1, Ship ship2)
        {
            ship1.Position = -5;
            ship2.Position = 5;
        }

        private static int GetDistance(Ship ship1, Ship ship2)
        {
            int distance;
            
            distance = Math.Abs(ship1.Position - ship2.Position);

            return distance;
        }

        // Math.Min(X, damageOfShip) where X defines the MAXIMUM damage possible for each loop of randomly selecting a component
        // the above works to spread damage across all components, rather than attacking one component until destroyed before attacking the next
        private static void ApplyDamage(Ship ship1, Ship ship2)
        {
            int initialHP = 0;

            int damageOfShip1 = GetTotalDamage(ship1);
            int damageOfShip2 = GetTotalDamage(ship2);

            // ship1 attacks ship2 shield

            while (damageOfShip1 > 0 && shieldOfShip2 > 0)
            {
                initialHP = shieldOfShip2;

                shieldOfShip2 = Math.Max(0, initialHP - damageOfShip1);
                damageOfShip1 = damageOfShip1 - (initialHP - shieldOfShip2);
            }

            // ship1 attacks ship2 armor

            while (damageOfShip1 > 0 && armorOfShip2 > 0)
            {
                initialHP = armorOfShip2;

                armorOfShip2 = Math.Max(0, initialHP - damageOfShip1);
                damageOfShip1 = damageOfShip1 - (initialHP - armorOfShip2);
            }

            // ship1 attacks ship2 health

            while (damageOfShip1 > 0 && HasHealth(ship2))
            {
                Random r = new();
                int i = r.Next(ship2.componentList.Count);
                initialHP = ship2.componentList[i].Health;

                ship2.componentList[i].Health = Math.Max(0, initialHP - Math.Min(5, damageOfShip1));
                damageOfShip1 = damageOfShip1 - (initialHP - ship2.componentList[i].Health);
            }

            // ship2 attacks ship1 shield

            while (damageOfShip2 > 0 && shieldOfShip1 > 0)
            {
                initialHP = shieldOfShip1;

                shieldOfShip1 = Math.Max(0, initialHP - damageOfShip2);
                damageOfShip2 = damageOfShip2 - (initialHP - shieldOfShip1);
            }

            // ship1 attacks ship2 armor

            while (damageOfShip2 > 0 && armorOfShip1 > 0)
            {
                initialHP = armorOfShip1;

                armorOfShip1 = Math.Max(0, initialHP - damageOfShip2);
                damageOfShip2 = damageOfShip2 - (initialHP - armorOfShip1);
            }

            // ship2 attacks ship1 health

            while (damageOfShip2 > 0 && HasHealth(ship1))
            {
                Random r = new();
                int i = r.Next(ship1.componentList.Count);
                initialHP = ship1.componentList[i].Health;

                ship1.componentList[i].Health = Math.Max(0, initialHP - Math.Min(5, damageOfShip2));
                damageOfShip2 = damageOfShip2 - (initialHP - ship1.componentList[i].Health);
            }
        }

        private static int GetTotalShield(Ship ship1)
        {
            int totalShield = 0;
            var shieldList = GetShieldList(ship1);

            foreach (Shield component in shieldList)
            {
                totalShield += component.Rating;
            }

            return totalShield;
        }

        private static List<Component> GetShieldList(Ship ship1)
        {
            List<Component> shieldList = new();

            foreach (Component component in ship1.componentList)
            {
                if (component is Shield)
                {
                    shieldList.Add(component);
                }
            }

            return shieldList;
        }

        private static int GetTotalArmor(Ship ship1)
        {
            int totalArmor = 0;
            var armorList = GetArmorList(ship1);

            foreach (Armor component in armorList)
            {
                totalArmor += component.Rating;
            }

            return totalArmor;
        }

        private static List<Component> GetArmorList(Ship ship1)
        {
            List<Component> armorList = new();

            foreach (Component component in ship1.componentList)
            {
                if (component is Armor)
                {
                    armorList.Add(component);
                }
            }

            return armorList;
        }

        private static int GetTotalDamage(Ship ship1)
        {
            int totalDmg = 0;
            var weaponList = GetWeaponList(ship1);

            foreach (Weapon component in weaponList)
            {
                if (component.Range >= distance)
                {
                    totalDmg += component.Damage;
                }
            }

            return totalDmg;
        }

        private static List<Component> GetWeaponList(Ship ship1)
        {
            List<Component> weaponList = new();

            foreach (Component component in ship1.componentList)
            {
                if (component is Weapon)
                {
                    weaponList.Add(component);
                }
            }

            return weaponList;
        }

        public static bool HasShield(Ship ship1)
        {
            var shieldList = GetShieldList(ship1);
            
            bool hasShield;
            int totalRating = 0;

            foreach (Shield component in shieldList)
            {
                totalRating += component.Rating;
            }

            if (totalRating <= 0)
            {
                hasShield = false;
            }
            else
            {
                hasShield = true;
            }

            return hasShield;
        }

        private static bool HasArmor(Ship ship1)
        {
            var armorList = GetArmorList(ship1);

            bool hasArmor;
            int totalRating = 0;

            foreach (Armor component in armorList)
            {
                totalRating += component.Rating;
            }

            if (totalRating <= 0)
            {
                hasArmor = false;
            }
            else
            {
                hasArmor = true;
            }

            return hasArmor;
        }

        private static bool HasHealth(Ship ship1)
        {
            bool hasHealth;
            int totalHealth = 0;

            foreach (Component component in ship1.componentList)
            {
                totalHealth += component.Health;
            }

            if (totalHealth <= 0)
            {
                hasHealth = false;
            }
            else
            {
                hasHealth = true;
            }

            return hasHealth;
        }

        private static void DestroyComponent(Ship ship1, Ship ship2)
        {
            ship1.componentList.RemoveAll(Component => Component.Health == 0);
            ship2.componentList.RemoveAll(Component => Component.Health == 0);
        }

        private static int GetTotalHealth(Ship ship1)
        {
            int totalHealth = 0;

            foreach (Component component in ship1.componentList)
            {
                totalHealth += component.Health;
            }

            return totalHealth;
        }

        private static void PrintHealth(Ship ship1, Ship ship2)
        {
            Console.WriteLine(ship1.Name + ":");

            foreach (Component component in ship1.componentList)
            {
                //Console.WriteLine(component.Type + ": " + component.Health);
                Console.WriteLine(component.GetType().ToString() + ": " + component.Health);
            }

            Console.WriteLine();
            Console.WriteLine(ship2.Name + ":");

            foreach (Component component in ship2.componentList)
            {
                //Console.WriteLine(component.Type + ": " + component.Health);
                Console.WriteLine(component.GetType().ToString() + ": " + component.Health);
            }
        }
    }
}
