using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProceduralWorldGeneator.Alg
{
    class Smoothing
    {
        internal Bitmap SmoothintMap (Bitmap map)
        {
            Random Random = new Random();
            return map;
        }

        internal Bitmap MakeGrayscale(Bitmap original)
        {
            StackBlur.StackBlur.Process(original, 15);
            return original;
        }
    }
}
