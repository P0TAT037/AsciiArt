using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiArt.Functions.Image
{
    public class Facade
    {
        public static void DrawImage(string path, int width = 100)
        {
            Console.WriteLine(Image.getImageText(path, width));
        }
    }
}
