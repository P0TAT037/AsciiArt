using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AsciiArt.Functions.Live
{
    public static class Live
    {
        const string ASCII = " .,:ilwW@@";
        public static void LiveCapture(int width = 100)
        {
            var capture = new VideoCapture();
            var img = new Mat();

            capture.Read(img);
            double ratio = img.Width / (double)img.Height;
            int height = (int)(width / ratio);

            StringBuilder sb = new();

            while (capture.IsOpened)
            {

                using (Bitmap frame = new(img.ToBitmap(), new Size(width, height)))
                {
                    for (var i = 0; i < frame.Height; i++)
                    {
                        for (var j = 0; j < frame.Width; j++)
                        {
                            var pixel = frame.GetPixel(j, i);
                            var avg = (pixel.R + pixel.G + pixel.B) / 3;

                            sb.Append(ASCII[avg * ASCII.Length / 255 % ASCII.Length]);
                        }
                        sb.AppendLine();
                    }
                }

                Console.WriteLine(sb.ToString());
                Console.SetCursorPosition(0, 0);
                sb.Clear();

                capture.Read(img);
                if (img.Cols == 0) break;
            }

        }

    }
}
