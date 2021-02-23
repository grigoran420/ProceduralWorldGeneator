using System.Drawing;

namespace ProceduralWorldGeneator.Alg
{
    class Analysis
    {
        void Analys(Bitmap map)
        {

        }
        
        internal double Average(Bitmap map)
        {
            double Aver = 0;
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    Aver += map.GetPixel(x, y).A;
                    Aver /= 2;
                }
            }
            return Aver;
        }
            
        internal int Min (Bitmap map)
        {
            int min = 256;
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    if (map.GetPixel(x, y).A < min) min = map.GetPixel(x, y).A;
                }
            }
            return min;
        }
        
        internal int Max (Bitmap map)
        {
            int max = -1;
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    if (map.GetPixel(x, y).A > max) max = map.GetPixel(x, y).A;
                }
            }
            return max;
        }
    }
}
