using ShipBattle.Components;
using ShipBattle.Components.Defenses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShipBattle
{
    internal class Ship
    {
        private string _name;
        private int _positionX;

        public List<Component> componentList = new();

        // Getters and setters.
        public string Name { get { return _name; } }
        public int PositionX { get { return _positionX; } set { _positionX = value; } }
        public int TotalShields
        {
            get
            {
                return GetComponentOfTypeList<Shield>().Sum(shield => shield.Rating);
            }

            set
            {
                TotalShields = Math.Max(0, value);
            }
        }

        public int TotalArmor
        {
            get
            {
                return GetComponentOfTypeList<Armor>().Sum(armor => armor.Rating);
            }

            set
            {
                TotalArmor = Math.Max(0, value);
            }
        }

        public int TotalHealth
        {
            get
            {
                return componentList.Sum(component => component.Health);
            }

            set
            {
                Math.Max(0, value);
            }
        }

        public Ship(string name)
        {
            // Initialize private variables
            _name = name;
        }

        /// <summary>
        /// Add a component to the ship.
        /// </summary>
        /// <param name="component">The component to add.</param>
        public void AddComponent(Component component)
        {
            componentList.Add(component);
        }

        /// <summary>
        /// Add multiple components to the ship.
        /// </summary>
        /// <param name="component">The component to add.</param>
        /// <param name="count">The amount of components to add.</param>
        public void AddComponent(Component component, int count)
        {
            for (int i = 0; i < count; i++)
            {
                componentList.Add(component);
            }
        }

        public List<T> GetComponentOfTypeList<T>() where T : Component
        {
            List<T> components = new();
            foreach (Component component in componentList)
            {
                Type componentType = component.GetType();
                if (componentType.BaseType == typeof(T))
                {
                    components.Add((T)component);
                }
            }

            return components;
        }

        public int GetDistance(Ship other) => Math.Abs(PositionX - other.PositionX);

        /// <returns>Total damage of all weapons on the ship that are in range of enemy.</returns>
        public int GetDamageOutput(Ship other) => GetComponentOfTypeList<Weapon>().Sum(weapon => weapon.Range >= GetDistance(other) ? weapon.Damage : 0);

        public bool IsAlive() => TotalHealth > 0;

        public bool HasArmor() => TotalArmor > 0;

        public bool HasShield() => TotalShields > 0;

        public void AttackEnemyShip(Ship other)
        {
            int damageOutput = GetDamageOutput(other);

            // Attack enemy shield.
            while (damageOutput > 0 && other.TotalShields > 0)
            {
                int initialEnemyShields = other.TotalShields;

                // Reduce shields of enemy ship.
                other.TotalShields -= damageOutput;
                // Reduce damage output of ship
                damageOutput -= initialEnemyShields - other.TotalShields;
            }

            // Attack enemy armor.
            while (damageOutput > 0 && other.TotalArmor > 0)
            {
                int initialEnemyArmor = other.TotalArmor;

                other.TotalArmor -= damageOutput;
                damageOutput -= initialEnemyArmor - other.TotalArmor;
            }

            // Attack enemy Health.
            while (damageOutput > 0 && other.IsAlive())
            {
                // Get random component of enemy ship to attack.
                int randomIndex = App.RandomGenerator.Next(other.componentList.Count);
                var randomComponent = other.componentList[randomIndex];

                int initialEnemyHealth = randomComponent.Health;

                randomComponent.Health -= Math.Min(5, damageOutput); // TODO: Remove this magic number.
                damageOutput -= initialEnemyHealth - randomComponent.Health;
            }
        }

        public void PrintShipDetails()
        {
            Console.WriteLine(_name);
            Console.WriteLine("\tShield: " + TotalShields);
            Console.WriteLine("\tArmor: " + TotalArmor);
            Console.WriteLine("\tHealth: " + TotalHealth);
            Console.WriteLine();
        }

        public void PrintDestroyed()
        {
            if (!IsAlive())
                Console.WriteLine(_name + " has been destroyed!");
        }
    }
}
