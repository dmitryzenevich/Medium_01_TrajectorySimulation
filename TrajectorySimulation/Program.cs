using System;
using System.Linq;
using System.Threading;
using TrajectorySimulation.Core;

namespace TrajectorySimulation
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Initialization
            var countOfMoveableObjects = 10;
            var moveableObjects = new MoveableObject[countOfMoveableObjects];

            // Spawn
            for (var i = 0; i < moveableObjects.Length; i++)
                moveableObjects[i] = new MoveableObject(new Vector2Int(i * 2, i * 2));

            // Get alive objects
            var aliveObjects = moveableObjects.ToList();

            while (true)
            {
                // Compare collisions
                for (var i = 0; i < aliveObjects.Count; i++)
                {
                    for (var j = i + 1; j < aliveObjects.Count; j++)
                    {
                        // If collided - destroy
                        if (aliveObjects[i].Position != aliveObjects[j].Position)
                            continue;

                        aliveObjects.RemoveAt(i);
                        aliveObjects.RemoveAt(j - 1);
                    }
                }

                // Move objects
                aliveObjects.ForEach(ao => ao.RandomMove());

                // Render
                for (var i = 0; i < aliveObjects.Count; i++)
                    Render(i.ToString(), aliveObjects[i].Position);

                Thread.Sleep(100);
                Console.Clear();
            }
        }

        private static void Render(string symbol, Vector2Int cursorPosition)
        {
            Console.SetCursorPosition(cursorPosition.X, cursorPosition.Y);
            Console.Write(symbol);
        }
    }
}