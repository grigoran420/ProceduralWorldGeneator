using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProceduralWorldGeneator.Alg
{
    class Coloring
    {
        internal Bitmap ColorB(Bitmap map)
        {
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    int A = map.GetPixel(x, y).A;
                    if (A < 98) map.SetPixel(x, y, Color.Blue);
                    if ((A >= 98) & (A < 110)) map.SetPixel(x, y, Color.Yellow);
                    if ((A >= 110) & ((A < 130))) map.SetPixel(x, y, Color.Green);
                    if ((A >= 130) & (A < 160)) map.SetPixel(x, y, Color.DarkGreen);
                    if ((A >= 160) & (A < 190)) map.SetPixel(x, y, Color.LightGray);
                    if ((A >= 190)) map.SetPixel(x, y, Color.DarkGray);
                }
            }

            return map;

        }
    } 
}
