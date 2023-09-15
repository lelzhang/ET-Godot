using System;
using System.Globalization;

namespace Godot
{
    [Serializable]
    public struct Vector3: IEquatable<Vector3>
    {
        private const float k1OverSqrt2 = 0.7071068f;
        private const float epsilon = 1E-05f;
        public static readonly Vector3 Zero = new Vector3();
        public static readonly Vector3 One = new Vector3(1f, 1f, 1f);
        public static readonly Vector3 Up = new Vector3(0.0f, 1f, 0.0f);
        public static readonly Vector3 Down = new Vector3(0.0f, -1f, 0.0f);
        public static readonly Vector3 Right = new Vector3(1f, 0.0f, 0.0f);
        public static readonly Vector3 Left = new Vector3(-1f, 0.0f, 0.0f);
        public static readonly Vector3 Forward = new Vector3(0.0f, 0.0f, 1f);
        public static readonly Vector3 Back = new Vector3(0.0f, 0.0f, -1f);
        public float X; 
        public float Y;
        public float Z;

        public Vector3(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Vector3(float value)
        {
            this.X = this.Y = this.Z = value;
        }

        public Vector3(Vector2 value, float z)
        {
            this.X = value.x;
            this.Y = value.y;
            this.Z = z;
        }

        public override string ToString()
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            return string.Format(currentCulture, "({0}, {1}, {2})", this.X.ToString(currentCulture),
                                 this.Y.ToString(currentCulture),
                                 this.Z.ToString(currentCulture));
        }

        public bool Equals(Vector3 other)
        {
            if (this.X == (double) other.X && this.Y == (double) other.Y)
                return this.Z == (double) other.Z;
            return false;
        }

        public override bool Equals(object obj)
        {
            bool flag = false;
            if (obj is Vector3)
                flag = this.Equals((Vector3) obj);
            return flag;
        }

        public override int GetHashCode()
        {
            return this.X.GetHashCode() + this.Y.GetHashCode() + this.Z.GetHashCode();
        }

        public float Length()
        {
            return (float) Math.Sqrt(this.X * (double) this.X + this.Y * (double) this.Y + this.Z * (double) this.Z);
        }

        public float LengthSquared()
        {
            return (float) (this.X * (double) this.X + this.Y * (double) this.Y + this.Z * (double) this.Z);
        }

        public float magnitude
        {
            get
            {
                return this.Length();
            }
        }
        
        public float sqrMagnitude
        {
            get
            {
                return this.LengthSquared();
            }
        }

        public static float Distance(Vector3 value1, Vector3 value2)
        {
            float num1 = value1.X - value2.X;
            float num2 = value1.Y - value2.Y;
            float num3 = value1.Z - value2.Z;
            return (float) Math.Sqrt(num1 * (double) num1 + num2 * (double) num2 + num3 * (double) num3);
        }

        public static void Distance(ref Vector3 value1, ref Vector3 value2, out float result)
        {
            float num1 = value1.X - value2.X;
            float num2 = value1.Y - value2.Y;
            float num3 = value1.Z - value2.Z;
            float num4 = (float) (num1 * (double) num1 + num2 * (double) num2 + num3 * (double) num3);
            result = (float) Math.Sqrt(num4);
        }

        public static float DistanceSquared(Vector3 value1, Vector3 value2)
        {
            float num1 = value1.X - value2.X;
            float num2 = value1.Y - value2.Y;
            float num3 = value1.Z - value2.Z;
            return (float) (num1 * (double) num1 + num2 * (double) num2 + num3 * (double) num3);
        }

        public static void DistanceSquared(ref Vector3 value1, ref Vector3 value2, out float result)
        {
            float num1 = value1.X - value2.X;
            float num2 = value1.Y - value2.Y;
            float num3 = value1.Z - value2.Z;
            result = (float) (num1 * (double) num1 + num2 * (double) num2 + num3 * (double) num3);
        }

        public static float Dot(Vector3 vector1, Vector3 vector2)
        {
            return (float) (vector1.X * (double) vector2.X + vector1.Y * (double) vector2.Y +
                vector1.Z * (double) vector2.Z);
        }

        public static void Dot(ref Vector3 vector1, ref Vector3 vector2, out float result)
        {
            result = (float) (vector1.X * (double) vector2.X + vector1.Y * (double) vector2.Y +
                vector1.Z * (double) vector2.Z);
        }

        public void Normalize()
        {
            float num1 = (float) (this.X * (double) this.X + this.Y * (double) this.Y + this.Z * (double) this.Z);
            if (num1 < (double) Mathf.Epsilon)
                return;
            float num2 = 1f / (float) Math.Sqrt(num1);
            this.X *= num2;
            this.Y *= num2;
            this.Z *= num2;
        }
        
        public Vector3 normalized
        {
            get
            {
                return Vector3.Normalize(this);
            }
        }

        public static Vector3 Normalize(Vector3 value)
        {
            float num1 = (float) (value.X * (double) value.X + value.Y * (double) value.Y + value.Z * (double) value.Z);
            if (num1 < (double) Mathf.Epsilon)
                return value;
            float num2 = 1f / (float) Math.Sqrt(num1);
            Vector3 vector3;
            vector3.X = value.X * num2;
            vector3.Y = value.Y * num2;
            vector3.Z = value.Z * num2;
            return vector3;
        }

        public static void Normalize(ref Vector3 value, out Vector3 result)
        {
            float num1 = (float) (value.X * (double) value.X + value.Y * (double) value.Y + value.Z * (double) value.Z);
            if (num1 < (double) Mathf.Epsilon)
            {
                result = value;
            }
            else
            {
                float num2 = 1f / (float) Math.Sqrt(num1);
                result.X = value.X * num2;
                result.Y = value.Y * num2;
                result.Z = value.Z * num2;
            }
        }

        public static Vector3 Cross(Vector3 vector1, Vector3 vector2)
        {
            Vector3 vector3;
            vector3.X = (float) (vector1.Y * (double) vector2.Z - vector1.Z * (double) vector2.Y);
            vector3.Y = (float) (vector1.Z * (double) vector2.X - vector1.X * (double) vector2.Z);
            vector3.Z = (float) (vector1.X * (double) vector2.Y - vector1.Y * (double) vector2.X);
            return vector3;
        }

        public static void Cross(ref Vector3 vector1, ref Vector3 vector2, out Vector3 result)
        {
            float num1 = (float) (vector1.Y * (double) vector2.Z - vector1.Z * (double) vector2.Y);
            float num2 = (float) (vector1.Z * (double) vector2.X - vector1.X * (double) vector2.Z);
            float num3 = (float) (vector1.X * (double) vector2.Y - vector1.Y * (double) vector2.X);
            result.X = num1;
            result.Y = num2;
            result.Z = num3;
        }

        public static Vector3 Reflect(Vector3 vector, Vector3 normal)
        {
            float num =
                    (float) (vector.X * (double) normal.X + vector.Y * (double) normal.Y + vector.Z * (double) normal.Z);
            Vector3 vector3;
            vector3.X = vector.X - 2f * num * normal.X;
            vector3.Y = vector.Y - 2f * num * normal.Y;
            vector3.Z = vector.Z - 2f * num * normal.Z;
            return vector3;
        }

        public static void Reflect(ref Vector3 vector, ref Vector3 normal, out Vector3 result)
        {
            float num =
                    (float) (vector.X * (double) normal.X + vector.Y * (double) normal.Y + vector.Z * (double) normal.Z);
            result.X = vector.X - 2f * num * normal.X;
            result.Y = vector.Y - 2f * num * normal.Y;
            result.Z = vector.Z - 2f * num * normal.Z;
        }

        public static Vector3 Min(Vector3 value1, Vector3 value2)
        {
            Vector3 vector3;
            vector3.X = (double) value1.X < (double) value2.X? value1.X : value2.X;
            vector3.Y = (double) value1.Y < (double) value2.Y? value1.Y : value2.Y;
            vector3.Z = (double) value1.Z < (double) value2.Z? value1.Z : value2.Z;
            return vector3;
        }

        public static void Min(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
        {
            result.X = (double) value1.X < (double) value2.X? value1.X : value2.X;
            result.Y = (double) value1.Y < (double) value2.Y? value1.Y : value2.Y;
            result.Z = (double) value1.Z < (double) value2.Z? value1.Z : value2.Z;
        }

        public static Vector3 Max(Vector3 value1, Vector3 value2)
        {
            Vector3 vector3;
            vector3.X = (double) value1.X > (double) value2.X? value1.X : value2.X;
            vector3.Y = (double) value1.Y > (double) value2.Y? value1.Y : value2.Y;
            vector3.Z = (double) value1.Z > (double) value2.Z? value1.Z : value2.Z;
            return vector3;
        }

        public static void Max(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
        {
            result.X = (double) value1.X > (double) value2.X? value1.X : value2.X;
            result.Y = (double) value1.Y > (double) value2.Y? value1.Y : value2.Y;
            result.Z = (double) value1.Z > (double) value2.Z? value1.Z : value2.Z;
        }

        public static Vector3 Clamp(Vector3 value1, Vector3 min, Vector3 max)
        {
            float x = value1.X;
            float num1 = (double) x > (double) max.X? max.X : x;
            float num2 = (double) num1 < (double) min.X? min.X : num1;
            float y = value1.Y;
            float num3 = (double) y > (double) max.Y? max.Y : y;
            float num4 = (double) num3 < (double) min.Y? min.Y : num3;
            float z = value1.Z;
            float num5 = (double) z > (double) max.Z? max.Z : z;
            float num6 = (double) num5 < (double) min.Z? min.Z : num5;
            Vector3 vector3;
            vector3.X = num2;
            vector3.Y = num4;
            vector3.Z = num6;
            return vector3;
        }

        public static void Clamp(ref Vector3 value1, ref Vector3 min, ref Vector3 max, out Vector3 result)
        {
            float x = value1.X;
            float num1 = (double) x > (double) max.X? max.X : x;
            float num2 = (double) num1 < (double) min.X? min.X : num1;
            float y = value1.Y;
            float num3 = (double) y > (double) max.Y? max.Y : y;
            float num4 = (double) num3 < (double) min.Y? min.Y : num3;
            float z = value1.Z;
            float num5 = (double) z > (double) max.Z? max.Z : z;
            float num6 = (double) num5 < (double) min.Z? min.Z : num5;
            result.X = num2;
            result.Y = num4;
            result.Z = num6;
        }

        public static Vector3 Lerp(Vector3 value1, Vector3 value2, float amount)
        {
            Vector3 vector3;
            vector3.X = value1.X + (value2.X - value1.X) * amount;
            vector3.Y = value1.Y + (value2.Y - value1.Y) * amount;
            vector3.Z = value1.Z + (value2.Z - value1.Z) * amount;
            return vector3;
        }

        public static void Lerp(ref Vector3 value1, ref Vector3 value2, float amount, out Vector3 result)
        {
            result.X = value1.X + (value2.X - value1.X) * amount;
            result.Y = value1.Y + (value2.Y - value1.Y) * amount;
            result.Z = value1.Z + (value2.Z - value1.Z) * amount;
        }

        public static Vector3 SmoothStep(Vector3 value1, Vector3 value2, float amount)
        {
            amount = (double) amount > 1.0? 1f : ((double) amount < 0.0? 0.0f : amount);
            amount = (float) (amount * (double) amount * (3.0 - 2.0 * amount));
            Vector3 vector3;
            vector3.X = value1.X + (value2.X - value1.X) * amount;
            vector3.Y = value1.Y + (value2.Y - value1.Y) * amount;
            vector3.Z = value1.Z + (value2.Z - value1.Z) * amount;
            return vector3;
        }

        public static void SmoothStep(ref Vector3 value1, ref Vector3 value2, float amount, out Vector3 result)
        {
            amount = (double) amount > 1.0? 1f : ((double) amount < 0.0? 0.0f : amount);
            amount = (float) (amount * (double) amount * (3.0 - 2.0 * amount));
            result.X = value1.X + (value2.X - value1.X) * amount;
            result.Y = value1.Y + (value2.Y - value1.Y) * amount;
            result.Z = value1.Z + (value2.Z - value1.Z) * amount;
        }

        public static Vector3 Hermite(Vector3 value1, Vector3 tangent1, Vector3 value2, Vector3 tangent2, float amount)
        {
            float num1 = amount * amount;
            float num2 = amount * num1;
            float num3 = (float) (2.0 * num2 - 3.0 * num1 + 1.0);
            float num4 = (float) (-2.0 * num2 + 3.0 * num1);
            float num5 = num2 - 2f * num1 + amount;
            float num6 = num2 - num1;
            Vector3 vector3;
            vector3.X = (float) (value1.X * (double) num3 + value2.X * (double) num4 + tangent1.X * (double) num5 +
                tangent2.X * (double) num6);
            vector3.Y = (float) (value1.Y * (double) num3 + value2.Y * (double) num4 + tangent1.Y * (double) num5 +
                tangent2.Y * (double) num6);
            vector3.Z = (float) (value1.Z * (double) num3 + value2.Z * (double) num4 + tangent1.Z * (double) num5 +
                tangent2.Z * (double) num6);
            return vector3;
        }

        public static void Hermite(
            ref Vector3 value1, ref Vector3 tangent1, ref Vector3 value2, ref Vector3 tangent2, float amount, out Vector3 result)
        {
            float num1 = amount * amount;
            float num2 = amount * num1;
            float num3 = (float) (2.0 * num2 - 3.0 * num1 + 1.0);
            float num4 = (float) (-2.0 * num2 + 3.0 * num1);
            float num5 = num2 - 2f * num1 + amount;
            float num6 = num2 - num1;
            result.X = (float) (value1.X * (double) num3 + value2.X * (double) num4 + tangent1.X * (double) num5 +
                tangent2.X * (double) num6);
            result.Y = (float) (value1.Y * (double) num3 + value2.Y * (double) num4 + tangent1.Y * (double) num5 +
                tangent2.Y * (double) num6);
            result.Z = (float) (value1.Z * (double) num3 + value2.Z * (double) num4 + tangent1.Z * (double) num5 +
                tangent2.Z * (double) num6);
        }

        public static Vector3 Negate(Vector3 value)
        {
            Vector3 vector3;
            vector3.X = -value.X;
            vector3.Y = -value.Y;
            vector3.Z = -value.Z;
            return vector3;
        }

        public static void Negate(ref Vector3 value, out Vector3 result)
        {
            result.X = -value.X;
            result.Y = -value.Y;
            result.Z = -value.Z;
        }

        public static Vector3 Add(Vector3 value1, Vector3 value2)
        {
            Vector3 vector3;
            vector3.X = value1.X + value2.X;
            vector3.Y = value1.Y + value2.Y;
            vector3.Z = value1.Z + value2.Z;
            return vector3;
        }

        public static void Add(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
        {
            result.X = value1.X + value2.X;
            result.Y = value1.Y + value2.Y;
            result.Z = value1.Z + value2.Z;
        }

        public static Vector3 Sub(Vector3 value1, Vector3 value2)
        {
            Vector3 vector3;
            vector3.X = value1.X - value2.X;
            vector3.Y = value1.Y - value2.Y;
            vector3.Z = value1.Z - value2.Z;
            return vector3;
        }

        public static void Sub(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
        {
            result.X = value1.X - value2.X;
            result.Y = value1.Y - value2.Y;
            result.Z = value1.Z - value2.Z;
        }

        public static Vector3 Multiply(Vector3 value1, Vector3 value2)
        {
            Vector3 vector3;
            vector3.X = value1.X * value2.X;
            vector3.Y = value1.Y * value2.Y;
            vector3.Z = value1.Z * value2.Z;
            return vector3;
        }

        public static void Multiply(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
        {
            result.X = value1.X * value2.X;
            result.Y = value1.Y * value2.Y;
            result.Z = value1.Z * value2.Z;
        }

        public static Vector3 Multiply(Vector3 value1, float scaleFactor)
        {
            Vector3 vector3;
            vector3.X = value1.X * scaleFactor;
            vector3.Y = value1.Y * scaleFactor;
            vector3.Z = value1.Z * scaleFactor;
            return vector3;
        }

        public static void Multiply(ref Vector3 value1, float scaleFactor, out Vector3 result)
        {
            result.X = value1.X * scaleFactor;
            result.Y = value1.Y * scaleFactor;
            result.Z = value1.Z * scaleFactor;
        }

        public static Vector3 Divide(Vector3 value1, Vector3 value2)
        {
            Vector3 vector3;
            vector3.X = value1.X / value2.X;
            vector3.Y = value1.Y / value2.Y;
            vector3.Z = value1.Z / value2.Z;
            return vector3;
        }

        public static void Divide(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
        {
            result.X = value1.X / value2.X;
            result.Y = value1.Y / value2.Y;
            result.Z = value1.Z / value2.Z;
        }

        public static Vector3 Divide(Vector3 value1, float divider)
        {
            float num = 1f / divider;
            Vector3 vector3;
            vector3.X = value1.X * num;
            vector3.Y = value1.Y * num;
            vector3.Z = value1.Z * num;
            return vector3;
        }

        public static void Divide(ref Vector3 value1, float divider, out Vector3 result)
        {
            float num = 1f / divider;
            result.X = value1.X * num;
            result.Y = value1.Y * num;
            result.Z = value1.Z * num;
        }

        private static float magnitudeStatic(ref Vector3 inV)
        {
            return (float) Math.Sqrt(Vector3.Dot(inV, inV));
        }

        private static Vector3 orthoNormalVectorFast(ref Vector3 n)
        {
            Vector3 vector3;
            if (Math.Abs(n.Z) > (double) Vector3.k1OverSqrt2)
            {
                float num = 1f / (float) Math.Sqrt(n.Y * (double) n.Y + n.Z * (double) n.Z);
                vector3.X = 0.0f;
                vector3.Y = -n.Z * num;
                vector3.Z = n.Y * num;
            }
            else
            {
                float num = 1f / (float) Math.Sqrt(n.X * (double) n.X + n.Y * (double) n.Y);
                vector3.X = -n.Y * num;
                vector3.Y = n.X * num;
                vector3.Z = 0.0f;
            }

            return vector3;
        }

        public static void OrthoNormalize(ref Vector3 normal, ref Vector3 tangent)
        {
            float num1 = Vector3.magnitudeStatic(ref normal);
            if (num1 > (double) Mathf.Epsilon)
                normal /= num1;
            else
                normal = new Vector3(1f, 0.0f, 0.0f);
            float num2 = Vector3.Dot(normal, tangent);
            tangent -= num2 * normal;
            float num3 = Vector3.magnitudeStatic(ref tangent);
            if (num3 < (double) Mathf.Epsilon)
                tangent = Vector3.orthoNormalVectorFast(ref normal);
            else
                tangent /= num3;
        }

        public static void OrthoNormalize(ref Vector3 normal, ref Vector3 tangent, ref Vector3 binormal)
        {
            float num1 = Vector3.magnitudeStatic(ref normal);
            if (num1 > (double) Mathf.Epsilon)
                normal /= num1;
            else
                normal = new Vector3(1f, 0.0f, 0.0f);
            float num2 = Vector3.Dot(normal, tangent);
            tangent -= num2 * normal;
            float num3 = Vector3.magnitudeStatic(ref tangent);
            if (num3 > (double) Mathf.Epsilon)
                tangent /= num3;
            else
                tangent = Vector3.orthoNormalVectorFast(ref normal);
            float num4 = Vector3.Dot(tangent, binormal);
            float num5 = Vector3.Dot(normal, binormal);
            binormal -= num5 * normal + num4 * tangent;
            float num6 = Vector3.magnitudeStatic(ref binormal);
            if (num6 > (double) Mathf.Epsilon)
                binormal /= num6;
            else
                binormal = Vector3.Cross(normal, tangent);
        }

        public static Vector3 Project(Vector3 vector, Vector3 onNormal)
        {
            return onNormal * Vector3.Dot(vector, onNormal) / Vector3.Dot(onNormal, onNormal);
        }

        public static void Project(ref Vector3 vector, ref Vector3 onNormal, out Vector3 result)
        {
            result = onNormal * Vector3.Dot(vector, onNormal) / Vector3.Dot(onNormal, onNormal);
        }

        public static float Angle(Vector3 from, Vector3 to)
        {
            from.Normalize();
            to.Normalize();
            float result;
            Vector3.Dot(ref from, ref to, out result);
            return Mathf.Cos(Mathf.Clamp(result, -1f, 1f)) * 57.29578f;
        }

        public static void Angle(ref Vector3 from, ref Vector3 to, out float result)
        {
            from.Normalize();
            to.Normalize();
            float result1;
            Vector3.Dot(ref from, ref to, out result1);
            result = Mathf.Cos(Mathf.Clamp(result1, -1f, 1f)) * 57.29578f;
        }

        public static Vector3 operator -(Vector3 value)
        {
            Vector3 vector3;
            vector3.X = -value.X;
            vector3.Y = -value.Y;
            vector3.Z = -value.Z;
            return vector3;
        }

        public static bool operator ==(Vector3 lhs, Vector3 rhs)
        {
            return (lhs - rhs).sqrMagnitude < 9.99999943962493E-11;
        }

        public static bool operator !=(Vector3 lhs, Vector3 rhs)
        {
            return !(lhs == rhs);
        }

        public static Vector3 operator +(Vector3 value1, Vector3 value2)
        {
            Vector3 vector3;
            vector3.X = value1.X + value2.X;
            vector3.Y = value1.Y + value2.Y;
            vector3.Z = value1.Z + value2.Z;
            return vector3;
        }

        public static Vector3 operator -(Vector3 value1, Vector3 value2)
        {
            Vector3 vector3;
            vector3.X = value1.X - value2.X;
            vector3.Y = value1.Y - value2.Y;
            vector3.Z = value1.Z - value2.Z;
            return vector3;
        }

        public static Vector3 operator *(Vector3 value1, Vector3 value2)
        {
            Vector3 vector3;
            vector3.X = value1.X * value2.X;
            vector3.Y = value1.Y * value2.Y;
            vector3.Z = value1.Z * value2.Z;
            return vector3;
        }

        public static Vector3 operator *(Vector3 value, float scaleFactor)
        {
            Vector3 vector3;
            vector3.X = value.X * scaleFactor;
            vector3.Y = value.Y * scaleFactor;
            vector3.Z = value.Z * scaleFactor;
            return vector3;
        }

        public static Vector3 operator *(float scaleFactor, Vector3 value)
        {
            Vector3 vector3;
            vector3.X = value.X * scaleFactor;
            vector3.Y = value.Y * scaleFactor;
            vector3.Z = value.Z * scaleFactor;
            return vector3;
        }

        public static Vector3 operator /(Vector3 value1, Vector3 value2)
        {
            Vector3 vector3;
            vector3.X = value1.X / value2.X;
            vector3.Y = value1.Y / value2.Y;
            vector3.Z = value1.Z / value2.Z;
            return vector3;
        }

        public static Vector3 operator /(Vector3 value, float divider)
        {
            float num = 1f / divider;
            Vector3 vector3;
            vector3.X = value.X * num;
            vector3.Y = value.Y * num;
            vector3.Z = value.Z * num;
            return vector3;
        }
    }
}