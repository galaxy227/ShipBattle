namespace ShipBattle.Components
{
    internal class Engine : Component
    {
        private int _thrust;

        public int Thrust { get { return _thrust; } }

        public Engine(int cost, int size, int health, int thrust) :
            base(cost, size, health)
        {
            // Initialize private variables
            _thrust = thrust;
        }
    }
}
