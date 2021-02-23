using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using StackBlur;

namespace ProceduralWorldGeneator.Alg
{
    class Smoothing
    {
        internal Bitmap SmoothintMap (Bitmap map)
        {
            Random Random = new Random();
            /*for (int y = 0; y < map.Height - 2; y++)
            {
                for (int x = 0; x < map.Width - 2; x++)
                {
                    if (map.GetPixel(x, y).A + 10 > map.GetPixel(x + 2, y + 2).A)
                    {
                        if (254 > map.GetPixel(x + 1, y + 1).A + 50)
                            map.SetPixel(x + 1, y + 1, Color.FromArgb(map.GetPixel(x + 1, y + 1).A + 50, Color.FromArgb(0, 0, 0)));
                    }

                    if (map.GetPixel(x, y).A - 10 < map.GetPixel(x + 2, y + 2).A)
                    {
                        if ((x != 0) & (y != 0))
                            if (1 < map.GetPixel(x - 1, y - 1).A - 50)
                                map.SetPixel(x - 1, y - 1, Color.FromArgb(map.GetPixel(x - 1, y - 1).A - 50, Color.FromArgb(0, 0, 0)));
                    }

                    if (map.GetPixel(x, y).A + 10 > map.GetPixel(x + 2, y + 2).A)
                    {
                        if (254 > map.GetPixel(x, y).A + 50)
                            map.SetPixel(x, y , Color.FromArgb(map.GetPixel(x, y).A + 50, Color.FromArgb(0, 0, 0)));
                    }

                    if (map.GetPixel(x, y).A - 10 < map.GetPixel(x + 2, y + 2).A)
                    {
                        if ((x != 0) & (y != 0))
                            if (1 < map.GetPixel(x, y).A - 50)
                                map.SetPixel(x, y, Color.FromArgb(map.GetPixel(x, y).A - 50, Color.FromArgb(0, 0, 0)));
                    }

                    if (map.GetPixel(x, y).A == map.GetPixel(x + 2, y + 2).A)
                    {
                        map.SetPixel(x, y, Color.FromArgb(Random.Next(40, 200), Color.FromArgb(0, 0, 0)));
                        if ((x != 0) & (y != 0))
                            x -= 2;
                    }
                }
            }*/
            return map;
        }

        internal Bitmap MakeGrayscale(Bitmap original)
        {
            StackBlur.StackBlur.Process(original, 15);
            return original;
        }
    }
}
