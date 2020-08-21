using System;

namespace TrajectorySimulation.Core
{
    public class MoveableObject
    {
        private string _name;
        private bool _isAlive;
        private Vector2Int _position;
        private Random _random = new Random();

        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public bool IsAlive => _isAlive;
        public Vector2Int Position
        {
            get => _position;
            private set => _position = value;
        }

        public MoveableObject(string name, Vector2Int position)
        {
            _name = name;
            _isAlive = true;
            _position = position;
        }

        public void RandomMove()
        {
            var x = _random.Next(-1, 2);
            var y = _random.Next(-1, 2);
            var direction = new Vector2Int(x, y);
            Move(direction);
            CheckBounds();
        }
        
        public void Move(Vector2Int direction) => Position += direction;

        private void CheckBounds()
        {
            var x = Position.X < 0 ? 0 : Position.X > 50 ? 50 : Position.X;
            var y = Position.Y < 0 ? 0 : Position.Y > 50 ? 50 : Position.Y;
            Position = new Vector2Int(x, y);
        }

        public void Destroy() => _isAlive = false;

        public void Render()
        {
            if (IsAlive == false)
                return;
            
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(Name);
        }
    }
}