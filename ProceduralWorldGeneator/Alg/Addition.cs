using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProceduralWorldGeneator.Alg
{
    class Addition
    {
        internal Bitmap Add (Bitmap map, Bitmap addMap)
        {
            int A;
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    //if ((addMap.GetPixel(x, y).A ^ map.GetPixel(x, y).A + addMap.GetPixel(x, y).A) > 254) A = 255; 
                    //else A = addMap.GetPixel(x, y).A ^ map.GetPixel(x, y).A + addMap.GetPixel(x, y).A;
                    A = map.GetPixel(x, y).A ^ addMap.GetPixel(x, y).A;
                    addMap.SetPixel(x, y, 
                        Color.FromArgb(A, 
                            Color.FromArgb(0, 0, 0)));
                }
            }
            return addMap;
        }
    }
}
