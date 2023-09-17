using System;

namespace Godot
{
#if !NOT_UNITY
    public class Vector3Helper
    {
        public static Vector3 Cross(Vector3 vector1, Vector3 vector2)
        {
            Vector3 vector3;
            vector3.X = (float)(vector1.Y * (double)vector2.Z - vector1.Z * (double)vector2.Y);
            vector3.Y = (float)(vector1.Z * (double)vector2.X - vector1.X * (double)vector2.Z);
            vector3.Z = (float)(vector1.X * (double)vector2.Y - vector1.Y * (double)vector2.X);
            return vector3;
        }

    }
#endif
}
