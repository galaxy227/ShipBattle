using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShipBattle.Components;
using ShipBattle.Components.Weapons;

namespace ShipBattle
{
    internal class Ship
    {
        private string _name;

        public List<Component> componentList = new();
        public string Name { get { return _name; } }

        public Ship(string name)
        {
            // Initialize private variables
            _name = name;
        }

        public void AddComponent(Component component)
        {
            componentList.Add(component);
        }

        private List<Component> GetComponentOfTypeList<T>() where T : Component
        {
            List<Component> components = new();
            foreach (Component component in componentList)
            {
                Type componentType = component.GetType();
                if (componentType.BaseType == typeof(T))
                {
                    components.Add(component);
                }
            }

            return components;
        }

        /// <returns>Total damage of all weapons on the ship.</returns>
        public int GetTotalDamage()
        {
            int totalDmg = 0;
            foreach (Weapon weapon in GetComponentOfTypeList<Weapon>())
            {
                totalDmg += weapon.Damage;
            }

            return totalDmg;
        }
    }
}
