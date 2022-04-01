using System;

namespace ShipBattle
{
    internal class Round
    {
        private int _turn = 1;

        public void SimulateCombat(Ship ship1, Ship ship2)
        {
            // do at start
            SetDefaultPosition(ship1, ship2);

            // Loop until one player has no health.
            while (ship1.IsAlive() && ship2.IsAlive())
            {
                PrintTurn();

                ship1.AttackEnemyShip(ship2);
                ship2.AttackEnemyShip(ship1);

                DestroyComponent(ship1, ship2);

                ship1.PrintShipDetails();
                ship2.PrintShipDetails();

                _turn++;
                Console.ReadKey();
            }

            ship1.PrintDestroyed();
            ship2.PrintDestroyed();
        }

        /// <summary>
        /// Sets default position of the ships.
        /// </summary>
        private void SetDefaultPosition(Ship ship1, Ship ship2)
        {
            ship1.PositionX = -5;
            ship2.PositionX = 5;
        }

        private void DestroyComponent(Ship ship1, Ship ship2)
        {
            ship1.componentList.RemoveAll(Component => Component.Health <= 0);
            ship2.componentList.RemoveAll(Component => Component.Health <= 0);
        }

        private void PrintTurn()
        {
            Console.WriteLine("Turn: " + _turn);
            Console.WriteLine();
        }
    }
}
