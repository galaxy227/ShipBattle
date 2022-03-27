using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipBattle
{
    class Ship
    {
        List<Component> componentList = new();

        public Ship()
        {

        }

        public void AddComponent(ComponentType type, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                componentList.Add(Component.CreateComponentOfType(type));
            }
        }

        public int GetComponentOfTypeCount(ComponentType type)
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

        public int GetTotalDamage(ComponentType type)
        {
            int totalDmg = 0;

            foreach (Weapon component in componentList)
            {
                if (component.Type == type)
                    totalDmg += component.Damage;
            }

            return totalDmg;
        }
    }
}
