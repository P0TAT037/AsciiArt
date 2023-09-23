using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiArt.Functions.Image
{
    public static class Image
    {
        const string ASCII = " .,:ilwW@@";
        public static string getImageText(string path, int width = 100)
        {
            var result = new StringBuilder();
            try
            {
                using (Bitmap img = new(path))
                {
                    width = width > img.Width ? img.Width : width;
                    double ratio = img.Width / (double)img.Height;
                    int height = (int)(width / ratio);

                    using var resizedImg = new Bitmap(img, new Size(width, height));

                    for (var i = 0; i < resizedImg.Height; i++)
                    {
                        for (var j = 0; j < resizedImg.Width; j++)
                        {
                            var pixel = resizedImg.GetPixel(j, i);
                            var avg = (pixel.R + pixel.G + pixel.B) / 3;

                            result.Append(ASCII[avg * ASCII.Length / 255 % ASCII.Length]);
                        }
                        result.Append('\n');
                    }
                }
            }
            catch (ArgumentException)
            {

                Console.WriteLine("invalid parameters");
            }
            return result.ToString();
        }
    }
}
