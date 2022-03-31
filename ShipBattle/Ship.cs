using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipBattle
{
    class Ship
    {
        public List<Component> componentList = new();

        public string Name;
        public int Position;

        public Ship(string name)
        {
            Name = name;
        }

        public void AddComponent(ComponentType type, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                componentList.Add(Component.CreateComponentOfType(type));
            }
        }

        private int GetComponentOfTypeCount(ComponentType type)
        {
            return GetComponentOfTypeList(type).Count;
        }

        private List<Component> GetComponentOfTypeList(ComponentType type)
        {
            List<Component> componentOfTypeList = new();

            foreach (Component component in componentList)
            {
                if (component.Type == type)
                {
                    componentOfTypeList.Add(component);
                }
            }

            return componentOfTypeList;
        }

        private int GetDamageOfType(ComponentType type)
        {
            int damage = 0;

            foreach (Weapon component in componentList)
            {
                if (component.Type == type)
                    damage += component.Damage;
            }

            return damage;
        }
    }
}
