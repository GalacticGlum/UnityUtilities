using UnityEngine;

namespace UnityUtilities.Math
{
    public struct Vector3i
    {
        public static readonly Vector3i Zero = new Vector3i(0);

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Vector3i(int scalar) : this()
        {
            X = scalar;
            Y = scalar;
            Z = scalar;
        }

        public Vector3i(int x, int y, int z) : this()
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static float Distance(Vector3i a, Vector3i b)
        {
            return Mathf.Sqrt(Mathf.Pow(a.X - b.X, 2) + Mathf.Pow(a.Y - b.Y, 2) + Mathf.Pow(a.Z - b.Z, 2));
        }

        public static bool operator ==(Vector3i left, Vector3i right)
        {
            return left.X == right.X && left.Y == right.Y && left.Z == right.Z;
        }

        public static bool operator !=(Vector3i left, Vector3i right)
        {
            return !(left == right);
        }

        public static Vector3i operator +(Vector3i left, Vector3i right)
        {
            return new Vector3i(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        public static Vector3i operator -(Vector3i left, Vector3i right)
        {
            return new Vector3i(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }

        public static Vector3i operator *(Vector3i left, Vector3i right)
        {
            return new Vector3i(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
        }

        public static Vector3i operator /(Vector3i left, Vector3i right)
        {
            return new Vector3i(left.X / right.X, left.Y / right.Y, left.Z / right.Z);
        }

        public static Vector3i operator +(Vector3i left, int right)
        {
            return new Vector3i(left.X + right, left.Y + right, left.Z + right);
        }

        public static Vector3i operator -(Vector3i left, int right)
        {
            return new Vector3i(left.X - right, left.Y - right, left.Z - right);
        }

        public static Vector3i operator *(Vector3i left, int right)
        {
            return new Vector3i(left.X * right, left.Y * right, left.Z * right);
        }

        public static Vector3i operator /(Vector3i left, int right)
        {
            return new Vector3i(left.X / right, left.Y / right, left.Z / right);
        }

        public bool Equals(Vector3i other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Vector3i && Equals((Vector3i)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = X;
                hashCode = (hashCode * 397) ^ Y;
                hashCode = (hashCode * 397) ^ Z;
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }

        public static implicit operator Vector3i(Vector3 vector)
        {
            return new Vector3i(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.y), Mathf.RoundToInt(vector.z));
        }

        public static implicit operator Vector3(Vector3i vector)
        {
            return new Vector3(vector.X, vector.Y, vector.Z);
        }

        public Vector2 ToVector2()
        {
            return new Vector2(X, Y);
        }

        public Vector3 ToVector3()
        {
            return new Vector3(X, Y, Z);
        }

        public Vector4 ToVector4(int w = 0)
        {
            return new Vector4(X, Y, Z, w);
        }
    }
}

