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
        protected ComponentType _type;

        public int Cost { get { return _cost; } }
        public int Size { get { return _size; } }
        public int Health;
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
                    return new Shield(type);
                case ComponentType.Armor:
                    return new Armor(type);
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
            GetStats(type);
        }

        private void GetStats(ComponentType type)
        {
            switch (type)
            {
                case ComponentType.Laser:
                    _cost = 10;
                    _size = 10;
                    Health = 10;
                    _damage = 10;
                    _range = 10;
                    break;
                case ComponentType.Missile:
                    _cost = 10;
                    _size = 10;
                    Health = 10;
                    _damage = 10;
                    _range = 10;
                    break;
            }
        }
    }

    class Shield : Component
    {
        private int _rating;
        private int _regen;
        public int Rating { get { return _rating; } }
        public int Regen { get { return _regen; } }

        public Shield(ComponentType type)
        {
            _type = type;
            GetStats(type);
        }

        private void GetStats(ComponentType type)
        {
            switch (type)
            {
                case ComponentType.Shield:
                    _cost = 10;
                    _size = 10;
                    Health = 10;
                    _rating = 10;
                    _regen = 10;
                    break;
            }
        }
    }

    class Armor : Component
    {
        private int _rating;
        public int Rating { get { return _rating; } }

        public Armor(ComponentType type)
        {
            _type = type;
            GetStats(type);
        }

        private void GetStats(ComponentType type)
        {
            switch (type)
            {
                case ComponentType.Armor:
                    _cost = 10;
                    _size = 10;
                    Health = 10;
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
            GetStats(type);
        }

        private void GetStats(ComponentType type)
        {
            switch (type)
            {
                case ComponentType.Engine:
                    _cost = 10;
                    _size = 10;
                    Health = 10;
                    _thrust = 10;
                    break;
            }
        }
    }
}
