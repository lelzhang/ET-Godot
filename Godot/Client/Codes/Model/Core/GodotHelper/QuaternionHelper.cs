using System;

namespace Godot
{
#if !NOT_UNITY
    public static class QuaternionHelper
    {
        public static Quaternion LookRotation(Vector3 viewVec, Vector3 upVec)
        {
            var lookingAt = Basis.LookingAt(viewVec, upVec);
            return lookingAt.GetRotationQuaternion();
        }

        public static bool LookRotationToQuaternion(Vector3 viewVec, Vector3 upVec, out Quaternion quat)
        {
            quat = new Quaternion(0.0f, 0.0f, 0.0f, 1f);

            // Generates a Right handed Quat from a look rotation. Returns if conversion was successful.
            Matrix3x3 m;
            if (!Matrix3x3.LookRotationToMatrix(viewVec, upVec, out m))
                return false;
            quat = MatrixToQuaternion(m);
            return true;
        }

        private static Quaternion MatrixToQuaternion(Matrix3x3 kRot)
        {
            Quaternion q = new Quaternion();

            // Algorithm in Ken Shoemake's article in 1987 SIGGRAPH course notes
            // article "Quaternionf Calculus and Fast Animation".

            float fTrace = kRot.Get(0, 0) + kRot.Get(1, 1) + kRot.Get(2, 2);
            float fRoot;

            if (fTrace > 0.0f)
            {
                // |w| > 1/2, mafy as well choose w > 1/2
                fRoot = Mathf.Sqrt(fTrace + 1.0f); // 2w
                q.W = 0.5f * fRoot;
                fRoot = 0.5f / fRoot; // 1/(4w)
                q.X = (kRot.Get(2, 1) - kRot.Get(1, 2)) * fRoot;
                q.Y = (kRot.Get(0, 2) - kRot.Get(2, 0)) * fRoot;
                q.Z = (kRot.Get(1, 0) - kRot.Get(0, 1)) * fRoot;
            }
            else
            {
                // |w| <= 1/2
                int[] s_iNext = new int[3] { 1, 2, 0 };
                int i = 0;
                if (kRot.Get(1, 1) > kRot.Get(0, 0))
                    i = 1;
                if (kRot.Get(2, 2) > kRot.Get(i, i))
                    i = 2;
                int j = s_iNext[i];
                int k = s_iNext[j];

                fRoot = Mathf.Sqrt(kRot.Get(i, i) - kRot.Get(j, j) - kRot.Get(k, k) + 1.0f);
                float[] apkQuat = new float[3] { q.X, q.Y, q.Z };

                apkQuat[i] = 0.5f * fRoot;
                fRoot = 0.5f / fRoot;
                q.W = (kRot.Get(k, j) - kRot.Get(j, k)) * fRoot;
                apkQuat[j] = (kRot.Get(j, i) + kRot.Get(i, j)) * fRoot;
                apkQuat[k] = (kRot.Get(k, i) + kRot.Get(i, k)) * fRoot;

                q.X = apkQuat[0];
                q.Y = apkQuat[1];
                q.Z = apkQuat[2];
            }

            q = Normalize(q);

            return q;
        }

        public static Quaternion Normalize(Quaternion quaternion)
        {
            float num = 1f / (float)Math.Sqrt((double)quaternion.X * (double)quaternion.X + (double)quaternion.Y * (double)quaternion.Y +
                                              (double)quaternion.Z * (double)quaternion.Z + (double)quaternion.W * (double)quaternion.W);
            Quaternion quaternion1;
            quaternion1.X = quaternion.X * num;
            quaternion1.Y = quaternion.Y * num;
            quaternion1.Z = quaternion.Z * num;
            quaternion1.W = quaternion.W * num;
            return quaternion1;
        }
    }
#endif
}