using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiArt.Functions.Live
{
    internal class Facade
    {
        public static void LiveCapture(int width = 100)
        {
            Live.LiveCapture(width);
        }
    }
}
