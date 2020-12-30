using System;

namespace TrajectorySimulation.Core
{
    public class MoveableObject
    {
        private Random _random = new Random();

        public Vector2Int Position { get; private set; }

        public MoveableObject(Vector2Int position) => Position = position;

        public void RandomMove()
        {
            var x = _random.Next(-1, 2);
            var y = _random.Next(-1, 2);
            var direction = new Vector2Int(x, y);
            Move(direction);
            ClampBounds();
        }
        
        public void Move(Vector2Int direction) => Position += direction;

        private void ClampBounds()
        {
            var x = Position.X < 0 ? 0 : Position.X > 20 ? 20 : Position.X;
            var y = Position.Y < 0 ? 0 : Position.Y > 20 ? 20 : Position.Y;
            Position = new Vector2Int(x, y);
        }
    }
}