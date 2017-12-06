using UnityEngine;

namespace UnityUtilities.Math
{
    public struct Vector2i
    {
        public static readonly Vector2i Zero = new Vector2i(0);

        public int X { get; set; }
        public int Y { get; set; }

        public Vector2i(int scalar) : this()
        {
            X = scalar;
            Y = scalar;
        }

        public Vector2i(int x, int y) : this()
        {
            X = x;
            Y = y;
        }

        public static float Distance(Vector2i a, Vector2i b)
        {
            return Mathf.Sqrt(Mathf.Pow(a.X - b.X, 2) + Mathf.Pow(a.Y - b.Y, 2));
        }

        public static bool operator ==(Vector2i left, Vector2i right)
        {
            return left.X == right.X && left.Y == right.Y;
        }

        public static bool operator !=(Vector2i left, Vector2i right)
        {
            return !(left == right);
        }

        public static Vector2i operator +(Vector2i left, Vector2i right)
        {
            return new Vector2i(left.X + right.X, left.Y + right.Y);
        }

        public static Vector2i operator -(Vector2i left, Vector2i right)
        {
            return new Vector2i(left.X - right.X, left.Y - right.Y);
        }

        public static Vector2i operator *(Vector2i left, Vector2i right)
        {
            return new Vector2i(left.X * right.X, left.Y * right.Y);
        }

        public static Vector2i operator /(Vector2i left, Vector2i right)
        {
            return new Vector2i(left.X / right.X, left.Y / right.Y);
        }

        public static Vector2i operator +(Vector2i left, int right)
        {
            return new Vector2i(left.X + right, left.Y + right);
        }

        public static Vector2i operator -(Vector2i left, int right)
        {
            return new Vector2i(left.X - right, left.Y - right);
        }

        public static Vector2i operator *(Vector2i left, int right)
        {
            return new Vector2i(left.X * right, left.Y * right);
        }

        public static Vector2i operator /(Vector2i left, int right)
        {
            return new Vector2i(left.X / right, left.Y / right);
        }

        public bool Equals(Vector2i other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Vector2i && Equals((Vector2i)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public static implicit operator Vector2i(Vector2 vector)
        {
            return new Vector2i(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.y));
        }

        public static implicit operator Vector2(Vector2i vector)
        {
            return new Vector2(vector.X, vector.Y);
        }
    }
}

