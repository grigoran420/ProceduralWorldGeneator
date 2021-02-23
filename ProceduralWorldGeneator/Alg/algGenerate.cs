using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProceduralWorldGeneator.Alg
{
    class AlgGenerate
    {
        private readonly Bitmap map;
        private readonly Random range;
        int A = 0;
        public AlgGenerate()
        {
            map = new Bitmap(800, 800);
            range = new Random();
        }

        internal Bitmap Generate()
        {
            Random RandCol = new Random();
            int col;

            for (int GlobalY = 0; GlobalY < (map.Height / 10); GlobalY++)
            {
                for (int GlobalX = 0; GlobalX < (map.Width / 10); GlobalX++)
                {
                    col = RandCol.Next(1, 4);

                    for (int LocalY = map.Height / 80 * GlobalY; LocalY < map.Height / 80 * (GlobalY + 1); LocalY++)
                    {
                        for (int LocalX = map.Width / 80 * GlobalX; LocalX < map.Width / 80 * (GlobalX + 1); LocalX++)
                        {
                            A = range.Next(60, 255);
                            A /= col;
                            map.SetPixel(LocalX, LocalY, Color.FromArgb(A, Color.FromArgb(0, 0, 0)));

                        }
                    }
                }
            }


            //for (int LocalY = 0; LocalY < map.Height; LocalY++)
            //{
            //    for (int LocalX = 0; LocalX < map.Width; LocalX++)
            //    {
            //        A = range.Next(60, 200);

            //        map.SetPixel(LocalX, LocalY, Color.FromArgb(A, Color.FromArgb(0, 0, 0)));

            //        if ((LocalX != 0) & (LocalY != 0))
            //            if (map.GetPixel(LocalX, LocalY).A + 50 > map.GetPixel(LocalX - 1, LocalY - 1).A)
            //                map.SetPixel(LocalX, LocalY, Color.FromArgb(A + 50, Color.FromArgb(0, 0, 0)));
            //        if ((LocalX != 0) & (LocalY != 0)) 
            //            if (map.GetPixel(LocalX, LocalY).A - 50 < map.GetPixel(LocalX - 1, LocalY - 1).A) 
            //                map.SetPixel(LocalX, LocalY, Color.FromArgb(A - 50, Color.FromArgb(0, 0, 0)));
            //    }
            //}

            return map;
        }
    }
}
