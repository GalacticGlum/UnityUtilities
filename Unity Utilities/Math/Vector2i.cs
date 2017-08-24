﻿using UnityEngine;

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

        public Vector2 ToVector2()
        {
            return new Vector2(X, Y);
        }

        public Vector3 ToVector3(int z = 0)
        {
            return new Vector3(X, Y, z);
        }

        public Vector4 ToVector4(int z = 0, int w = 0)
        {
            return new Vector4(X, Y, z, w);
        }
    }
}

