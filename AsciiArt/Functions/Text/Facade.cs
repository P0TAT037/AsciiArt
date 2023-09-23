using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AsciiArt.Functions.Functions;
using static AsciiArt.Functions.Text.Text;

namespace AsciiArt.Functions.Text
{
    public static class Facade
    {
        public static void DrawTextWithDefaultDecoration(string text)
        {
            var decoration = new TextDecoration();
            Text.DrawTextWithDefaultDecoration(text, decoration);
        }

        public static void DrawTextWithCustomDecoration(string text)
        {
            ParticleEffect effect;
            TextDecoration decoration;
            try
            {
                Console.Write("Vertical Border char:");
                var verticalBorder = Console.ReadLine()![0];

                Console.Write("Horizontal Border char:");
                var horizontalBorder = Console.ReadLine()![0];

                Console.Write("Veritcal padding size:");
                var verticalPadding = int.Parse(Console.ReadLine()!);

                Console.Write("Horizontal padding size:");
                var horizontalPadding = int.Parse(Console.ReadLine()!);

                Console.WriteLine("Decoration particles chars delimited by spaces:");
                var decorationStrings = Console.ReadLine()!.Split(' ');
                List<char> decorationChars = new List<char>();
                foreach (string @string in decorationStrings)
                {
                    decorationChars.Add(@string[0]);
                }
                Console.WriteLine("Behavior:");
                Console.WriteLine("1-Fall\t2-Rise\t3-Fly Right\t4-Fly Left\t5-Random Spawn");
                var behavior = (ParticleBehavior)int.Parse(Console.ReadLine()!);
                effect = new(decorationChars.ToList(), behavior);
                decoration = new TextDecoration(verticalBorder, horizontalBorder, verticalPadding, horizontalPadding, effect);
            }
            catch
            {
                Console.WriteLine("Incorrect input format!!");
                return;
            }
            var textArt = GetAsciiArtText(text, "standard");
            Decorate(textArt, decoration);
        }

        public static void DrawTextWithCustomDecorationAndFont(string text)
        {
            ParticleEffect effect;
            TextDecoration decoration;
            string font;
            try
            {
                Console.Write("Vertical Border char:");
                var verticalBorder = Console.ReadLine()![0];

                Console.Write("Horizontal Border char:");
                var horizontalBorder = Console.ReadLine()![0];

                Console.Write("Veritcal padding size:");
                var verticalPadding = int.Parse(Console.ReadLine()!);

                Console.Write("Horizontal padding size:");
                var horizontalPadding = int.Parse(Console.ReadLine()!);

                Console.WriteLine("Decoration particles chars delimited by spaces:");
                var decorationStrings = Console.ReadLine()!.Split(' ');
                List<char> decorationChars = new List<char>();
                foreach (string @string in decorationStrings)
                {
                    decorationChars.Add(@string[0]);
                }
                Console.WriteLine("Behavior:");
                Console.WriteLine("1-Fall\t2-Rise\t3-Fly Right\t4-Fly Left\t5-Random Spawn");
                var behavior = (ParticleBehavior)int.Parse(Console.ReadLine()!);
                effect = new(decorationChars.ToList(), behavior);
                decoration = new TextDecoration(verticalBorder, horizontalBorder, verticalPadding, horizontalPadding, effect);

                Console.Write("Font name:");
                font = Console.ReadLine()!;
            }
            catch
            {
                Console.WriteLine("Incorrect input format!!");
                return;
            }
            var textArt = GetAsciiArtText(text, font);
            Decorate(textArt, decoration);
        }

        public static void DrawTextRandomFont(string text)
        {
            try
            {
                Console.WriteLine(GetAsciiArtText(text, null));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void DrawText(string text, string fontname = "standard")
        {
            try
            {
                Console.WriteLine(GetAsciiArtText(text, fontname));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void GetFontNames()
        {
            foreach (string name in Text.FiggleFontNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
