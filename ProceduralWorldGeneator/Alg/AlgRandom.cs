using System;
using System.Drawing;

namespace ProceduralWorldGeneator.Alg
{
    class AlgRandom
    {
        private readonly Bitmap map;
        private readonly Random range;
        int A = 0;
        public AlgRandom()
        {
            map = new Bitmap(800, 800);
            range = new Random();
        }

        internal Bitmap Generate(int scale)
        {
            Random RandCol = new Random();
            int col;

            for (int GlobalY = 0; GlobalY < (map.Height / (map.Height / scale)); GlobalY++)
            {
                for (int GlobalX = 0; GlobalX < (map.Width / (map.Width / scale)); GlobalX++)
                {
                    col = RandCol.Next(1, 4);

                    for (int LocalY = map.Height / scale * GlobalY; LocalY < map.Height / scale * (GlobalY + 1); LocalY++)
                    {
                        for (int LocalX = map.Width / scale * GlobalX; LocalX < map.Width / scale * (GlobalX + 1); LocalX++)
                        {
                            A = range.Next(60, 255);
                            A /= col;
                            map.SetPixel(LocalX, LocalY, Color.FromArgb(A, Color.FromArgb(0, 0, 0)));

                        }
                    }
                }
            }
            return map;
        }
    }
}
