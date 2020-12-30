namespace TrajectorySimulation.Core
{
    public struct Vector2Int
    {
        public int X;
        public int Y;

        public Vector2Int(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Vector2Int Zero => new Vector2Int(0, 0);
        public static Vector2Int One => new Vector2Int(1, 1);

        public static bool operator ==(Vector2Int lhs, Vector2Int rhs) => lhs.X == rhs.X && lhs.Y == rhs.Y;

        public static bool operator !=(Vector2Int lhs, Vector2Int rhs) => !(lhs == rhs);
        
        public static Vector2Int operator +(Vector2Int lhs, Vector2Int rhs) => new Vector2Int(lhs.X + rhs.X, lhs.Y + rhs.Y);
        
        public static Vector2Int operator -(Vector2Int lhs, Vector2Int rhs) => new Vector2Int(lhs.X - rhs.X, lhs.Y - rhs.Y);
    }
}