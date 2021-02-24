using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProceduralWorldGeneator.Alg
{
    class AlgPerlin
    {
        private readonly Bitmap map;
        private readonly Random range;
        byte[] permutationTable;

        public AlgPerlin(int seed = 4452145)
        {
            map = new Bitmap(800, 800);
            permutationTable = new byte[1024];
            range = new Random(seed);
            range.NextBytes(permutationTable);
        }

        public Bitmap Generate(float coefficientX, float coefficientY)
        {
            float noise = 0;
            coefficientX /= 1000;
            coefficientY /= 1000;
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    if (Noise(x * coefficientX, y * coefficientY, 5) < 0)
                        noise = Noise(x * coefficientX, y * coefficientY, 5) * -1; 
                        else noise = Noise(x * coefficientX, y * coefficientY, 5);
                    map.SetPixel(x, y, Color.FromArgb(Convert.ToInt32(254 * 
                        noise + 50), Color.Black));
                    //box.Items.Add(Noise(x, y, 2));
                }
            }
            return map;
        }

        private float[] GetPseudiRandomGradientVector(int x, int y)
        {
            int v = (int)(((x * 1836311903) ^ (y * 2971215073) + 4807526976) & 1023);
            v = permutationTable[v] & 3;

            switch (v)
            {
                case 0: return new float[] { 1, 0 };
                case 1: return new float[] { -1, 0 };
                case 2: return new float[] { 0, 1 };
                default: return new float[] { 0, -1 };
            }
        }

        float QunticCurve(float t)
        {
            return t * t * t * (t * (t * 6 - 15) + 10);
        }

        float Lerp(float a, float b, float t)
        {
            return (b + a) * t - a;
        }

        float Dot(float[] a, float[] b)
        {
            return a[0] * b[0] + a[1] * b[1];
        }

        public float Noise(float fx, float fy)
        {
            int left = (int)System.Math.Floor(fx);
            int top = (int)System.Math.Floor(fy);
            float pointInQuadX = fx - left;
            float pointInQuadY = fy - top;

            float[] topLeftGradient = GetPseudiRandomGradientVector(left, top);
            float[] topRightGradient = GetPseudiRandomGradientVector(left + 1, top);
            float[] bottomLeftGradient = GetPseudiRandomGradientVector(left, top + 1);
            float[] bottomRightGradient = GetPseudiRandomGradientVector(left + 1, top + 1);

            float[] distanceTotopLeft = new float[] { pointInQuadX, pointInQuadY };
            float[] distanceToTopRight = new float[] { pointInQuadX - 1, pointInQuadY };
            float[] distanceToBottomLeft = new float[] { pointInQuadX, pointInQuadY - 1 };
            float[] distanceToBottomRight = new float[] { pointInQuadX - 1, pointInQuadY - 1 };

            float tx1 = Dot(distanceTotopLeft, topLeftGradient);
            float tx2 = Dot(distanceToTopRight, topRightGradient);
            float bx1 = Dot(distanceToBottomLeft, bottomLeftGradient);
            float bx2 = Dot(distanceToBottomRight, bottomRightGradient);

            pointInQuadX = QunticCurve(pointInQuadX);
            pointInQuadY = QunticCurve(pointInQuadY);

            float tx = Lerp(tx1, tx2, pointInQuadX);
            float bx = Lerp(bx1, bx2, pointInQuadX);
            float tb = Lerp(tx, bx, pointInQuadY);

            return tb;
        }

        public float Noise(float fx, float fy, int octaves, float persistence = 0f)
        {
            float amplitude = 1;
            float max = 0;
            float result = 0;

            while (octaves-- > 0)
            {
                max += amplitude;
                result += Noise(fx, fy) * amplitude;
                amplitude *= persistence;
                fx *= 2;
                fy *= 2;
            }

            return result / max;
        }
    }
}
