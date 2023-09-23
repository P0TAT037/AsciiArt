using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiArt.Functions.Video
{
    internal class Facade
    {
        public static void DrawVideo(string path, int width = 100, int sleep = 10)
        {
            Video.DrawVideo(path, width, sleep);
        }
    }
}
