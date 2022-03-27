using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipBattle
{
    public enum ComponentType
    {
        Laser,
        Missile,
        Shield,
        Armor,
        Engine,
    }

    class Component
    {
        protected int _cost;
        protected int _size;
        protected int _health;
        protected ComponentType _type;

        public int Cost { get { return _cost; } }
        public int Size { get { return _size; } }
        public int Health { get { return _health; } }
        public ComponentType Type { get { return _type; } }

        protected Component()
        {

        }

        public static Component CreateComponentOfType(ComponentType type)
        {
            switch (type)
            {
                case ComponentType.Laser:
                    return new Weapon(type);
                case ComponentType.Missile:
                    return new Weapon(type);
                case ComponentType.Shield:
                    return new Defense(type);
                case ComponentType.Armor:
                    return new Defense(type);
                case ComponentType.Engine:
                    return new Engine(type);
                default:
                    return null;
            }
        }
    }

    class Weapon : Component
    {
        private int _damage;
        private int _range;

        public int Damage { get { return _damage; } }
        public int Range { get { return _range; } }

        public Weapon(ComponentType type)
        {
            _type = type;
            GetWeaponStats(type);
        }

        private void GetWeaponStats(ComponentType type)
        {
            switch (type)
            {
                case ComponentType.Laser:
                    _cost = 10;
                    _size = 10;
                    _health = 10;
                    _damage = 10;
                    _range = 10;
                    break;
                case ComponentType.Missile:
                    _cost = 10;
                    _size = 10;
                    _health = 10;
                    _damage = 10;
                    _range = 10;
                    break;
            }
        }
    }

    class Defense : Component
    {
        private int _rating;
        private int _regen;

        public int Rating { get { return _rating; } }
        public int Regen { get { return _regen; } }

        public Defense(ComponentType type)
        {
            _type = type;
            GetDefenseStats(type);
        }

        private void GetDefenseStats(ComponentType type)
        {
            switch (type)
            {
                case ComponentType.Shield:
                    _cost = 10;
                    _size = 10;
                    _health = 10;
                    _rating = 10;
                    _regen = 10;
                    break;
                case ComponentType.Armor:
                    _cost = 10;
                    _size = 10;
                    _health = 10;
                    _rating = 10;
                    break;
            }
        }
    }

    class Engine : Component
    {
        private int _thrust;

        public int Thrust { get { return _thrust; } }

        public Engine(ComponentType type)
        {
            _type = type;
            GetEngineStats(type);
        }

        private void GetEngineStats(ComponentType type)
        {
            switch (type)
            {
                case ComponentType.Engine:
                    _cost = 10;
                    _size = 10;
                    _health = 10;
                    _thrust = 10;
                    break;
            }
        }
    }
}
