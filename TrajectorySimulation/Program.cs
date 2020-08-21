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
            var countOfMoveableObjects = 3;
            var moveableObjects = new MoveableObject[countOfMoveableObjects];

            // Spawn
            for (var i = 0; i < moveableObjects.Length; i++)
            {
                var index = i + 1;
                moveableObjects[i] = new MoveableObject(index.ToString(), new Vector2Int(index * 5, index * 5));
            }

            while (true)
            {
                // Get alive objects
                var aliveObjects = moveableObjects.Where(m => m.IsAlive).ToList();

                // Compare collisions
                for (var i = 0; i < aliveObjects.Count; i++)
                {
                    for (var j = 0; j < aliveObjects.Count; j++)
                    {
                        if (j == i) continue;

                        // If collided - destroy
                        if (aliveObjects[i].Position == aliveObjects[j].Position)
                        {
                            aliveObjects[i].Destroy();
                            aliveObjects[j].Destroy();
                        }
                    }
                }

                // Move objects
                aliveObjects.ForEach(ao => ao.RandomMove());

                // Render
                aliveObjects.ForEach(ao => ao.Render());
                
                Thread.Sleep(100);
                Console.Clear();
            }
        }
    }
}