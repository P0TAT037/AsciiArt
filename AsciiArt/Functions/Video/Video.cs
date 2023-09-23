using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiArt.Functions.Video
{
    public static class Video
    {
        const string ASCII = " .,:ilwW@@";
        public static void DrawVideo(string path, int width = 100, int sleep = 10)
        {
            var capture = new VideoCapture(path);
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
                Thread.Sleep(sleep);

                capture.Read(img);
                if (img.Cols == 0) break;
            }

        }
    }
}
