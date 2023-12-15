using Figgle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AsciiArt.Functions.Functions;

namespace AsciiArt.Functions.Text
{
    public static class Text
    {
        public const string ASCII = " .,:ilwW@@";

        #region fontNames
        public static string[] FiggleFontNames = new string[]
        {
            "1row",
            "3-d",
            "3d_diagonal",
            "3x5",
            "4max",
            "5lineoblique",
            "acrobatic",
            "alligator",
            "alligator2",
            "alligator3",
            "alpha",
            "alphabet",
            "amc3line",
            "amc3liv1",
            "amcaaa01",
            "amcneko",
            "amcrazo2",
            "amcrazor",
            "amcslash",
            "amcslder",
            "amcthin",
            "amctubes",
            "amcun1",
            "arrows",
            "ascii_new_roman",
            "avatar",
            "B1FF",
            "banner",
            "banner3",
            "banner3-D",
            "banner4",
            "barbwire",
            "basic",
            "bear",
            "bell",
            "benjamin",
            "big",
            "bigchief",
            "bigfig",
            "binary",
            "block",
            "blocks",
            "bolger",
            "braced",
            "bright",
            "broadway",
            "broadway_kb",
            "bubble",
            "bulbhead",
            "calgphy2",
            "caligraphy",
            "cards",
            "catwalk",
            "chiseled",
            "chunky",
            "coinstak",
            "cola",
            "colossal",
            "computer",
            "contessa",
            "contrast",
            "cosmic",
            "cosmike",
            "crawford",
            "crazy",
            "cricket",
            "cursive",
            "cyberlarge",
            "cybermedium",
            "cybersmall",
            "cygnet",
            "DANC4",
            "dancingfont",
            "decimal",
            "defleppard",
            "diamond",
            "dietcola",
            "digital",
            "doh",
            "doom",
            "dosrebel",
            "dotmatrix",
            "double",
            "doubleshorts",
            "drpepper",
            "dwhistled",
            "eftichess",
            "eftifont",
            "eftipiti",
            "eftirobot",
            "eftitalic",
            "eftiwall",
            "eftiwater",
            "epic",
            "fender",
            "filter",
            "fire_font-k",
            "fire_font-s",
            "flipped",
            "flowerpower",
            "fourtops",
            "fraktur",
            "funface",
            "funfaces",
            "fuzzy",
            "georgi16",
            "Georgia11",
            "ghost",
            "ghoulish",
            "glenyn",
            "goofy",
            "gothic",
            "graceful",
            "gradient",
            "graffiti",
            "greek",
            "heart_left",
            "heart_right",
            "henry3d",
            "hex",
            "hieroglyphs",
            "hollywood",
            "horizontalleft",
            "horizontalright",
            "ICL-1900",
            "impossible",
            "invita",
            "isometric1",
            "isometric2",
            "isometric3",
            "isometric4",
            "italic",
            "ivrit",
            "jacky",
            "jazmine",
            "jerusalem",
            "katakana",
            "kban",
            "keyboard",
            "knob",
            "konto",
            "kontoslant",
            "larry3d",
            "lcd",
            "lean",
            "letters",
            "lildevil",
            "lineblocks",
            "linux",
            "lockergnome",
            "madrid",
            "marquee",
            "maxfour",
            "merlin1",
            "merlin2",
            "mike",
            "mini",
            "mirror",
            "mnemonic",
            "modular",
            "morse",
            "morse2",
            "moscow",
            "mshebrew210",
            "muzzle",
            "nancyj",
            "nancyj-fancy",
            "nancyj-improved",
            "nancyj-underlined",
            "nipples",
            "nscript",
            "ntgreek",
            "nvscript",
            "o8",
            "octal",
            "ogre",
            "oldbanner",
            "os2",
            "pawp",
            "peaks",
            "peaksslant",
            "pebbles",
            "pepper",
            "poison",
            "puffy",
            "puzzle",
            "pyramid",
            "rammstein",
            "rectangles",
            "red_phoenix",
            "relief",
            "relief2",
            "rev",
            "reverse",
            "roman",
            "rot13",
            "rotated",
            "rounded",
            "rowancap",
            "rozzo",
            "runic",
            "runyc",
            "santaclara",
            "sblood",
            "script",
            "slscript",
            "serifcap",
            "shadow",
            "shimrod",
            "short",
            "slant",
            "slide",
            "small",
            "smallcaps",
            "smisome1",
            "smkeyboard",
            "smpoison",
            "smscript",
            "smshadow",
            "smslant",
            "smtengwar",
            "soft",
            "speed",
            "spliff",
            "s-relief",
            "stacey",
            "stampate",
            "stampatello",
            "standard",
            "starstrips",
            "starwars",
            "stellar",
            "stforek",
            "stop",
            "straight",
            "sub-zero",
            "swampland",
            "swan",
            "sweet",
            "tanja",
            "tengwar",
            "term",
            "test1",
            "thick",
            "thin",
            "threepoint",
            "ticks",
            "ticksslant",
            "tiles",
            "tinker-toy",
            "tombstone",
            "train",
            "trek",
            "tsalagi",
            "tubular",
            "twisted",
            "twopoint",
            "univers",
            "usaflag",
            "varsity",
            "wavy",
            "weird",
            "wetletter",
            "whimsy",
            "wow"
        };
        #endregion

        public static void DrawTextWithDefaultDecoration(string text, TextDecoration decoration)
        {
            var textArt = GetAsciiArtText(text, "standard");
            Decorate(textArt, decoration);
        }
        public static string GetAsciiArtText(string text, string fontName)
        {

            if (fontName == null)
            {
                var r = Random.Shared.Next(0, FiggleFontNames.Length);
                fontName = FiggleFontNames[r];   
            }

            var font = FiggleFonts.TryGetByName(fontName);

            if (font == null)
            {
                try
                {
                    using var fontStream = File.OpenRead(fontName);
                    font = FiggleFontParser.Parse(fontStream);

                }
                catch
                {
                    throw new Exception("font not found!!");
                }
            }

            return font.Render(text);
        }

        public static void Decorate(string textArt, TextDecoration decoration, int sleep = 200)
        {
            var lines = textArt.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].Replace('\r', ' ');
            }
            var horizontalPadding = new StringBuilder().Append(' ', decoration.HorizontalPadding).ToString();
            var paddingLine = new StringBuilder().Append(decoration.VerticalBorder).Append(' ', lines[0].Length + 2 * decoration.HorizontalPadding).Append(decoration.VerticalBorder).Append('\n').ToString();
            var verticalPaddingBuilder = new StringBuilder();
            for (int i = 0; i < decoration.VerticalPadding; i++)
            {
                verticalPaddingBuilder.Append(paddingLine);
            }
            var verticalPadding = verticalPaddingBuilder.ToString();
            var resultBuilder = new StringBuilder();

            // print the upper boarder

            resultBuilder.Append(decoration.HorizontalBorder, lines[0].Length + decoration.HorizontalPadding * 2 + 2).Append('\n');


            resultBuilder.Append(verticalPadding);

            for (int i = 0; i < lines.Length - 1; i++)
            {
                resultBuilder.Append(decoration.VerticalBorder);
                resultBuilder.Append(horizontalPadding);
                resultBuilder.Append(lines[i]);
                resultBuilder.Append(horizontalPadding);
                resultBuilder.Append(decoration.VerticalBorder).Append("\n");
            }


            resultBuilder.Append(verticalPadding);

            resultBuilder.Append(decoration.HorizontalBorder, lines[0].Length + decoration.HorizontalPadding * 2 + 2);


            var result = resultBuilder.ToString();

            // add the effect

            if (decoration.Effect.Behavior == ParticleBehavior.Fall)
            {
            Label:
                var resultLines = result.Split('\n');

                var effectResultBuilder = new StringBuilder();
                var particleCount = Random.Shared.Next((int)(resultLines[0].Length * 0.5), (int)(resultLines[0].Length * 0.8));
                // 0     1     2       3                4
                // i,    j,    step,   decorationChar,  isFinished
                int[,] particles = new int[particleCount, 5];
                for (int i = 0; i < particleCount; i++)
                {
                    particles[i, 0] = Random.Shared.Next(1, resultLines.Length - 1);
                    particles[i, 1] = Random.Shared.Next(1, resultLines[0].Length - 1);
                    particles[i, 2] = Random.Shared.Next(1, (int)(resultLines.Length * 0.2));
                    particles[i, 3] = 0;
                    particles[i, 4] = 0;
                }

                StringBuilder strBuilder;

                while (true)
                {
                    resultLines = result.Split("\n");
                    // replace every [i,j] with +
                    for (int i = 0; i < particles.Length / 5; i++)
                    {
                        var decoratoinChar = decoration.Effect.DecorationChars[Random.Shared.Next(0, decoration.Effect.DecorationChars.Count)];
                        strBuilder = new StringBuilder(resultLines[particles[i, 0]]);
                        strBuilder.Replace(' ', decoratoinChar, particles[i, 1], 1);
                        resultLines[particles[i, 0]] = strBuilder.ToString();
                    }

                    effectResultBuilder.AppendJoin('\n', resultLines);
                    Console.WriteLine(effectResultBuilder.ToString());

                    Thread.Sleep(sleep);
                    effectResultBuilder.Clear();
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    bool timeToStartOver = false;
                    for (int i = 0; i < particleCount; i++)
                    {
                        var newPosition = particles[i, 0] + particles[i, 2];
                        if (newPosition >= resultLines.Length - 1)
                        {
                            particles[i, 0] = Random.Shared.Next(1, resultLines.Length - 1);
                            particles[i, 1] = Random.Shared.Next(1, resultLines[0].Length - 1);
                            particles[i, 2] = Random.Shared.Next(1, (int)(resultLines.Length * 0.2));
                            timeToStartOver &= Convert.ToBoolean(particles[i, 4]);
                        }
                        else
                        {
                            particles[i, 0] = newPosition;
                            particles[i, 4] = 1;
                        }
                    }
                    if (timeToStartOver)
                    {
                        goto Label;
                    }
                }
            }
            else if (decoration.Effect.Behavior == ParticleBehavior.FlyRight)
            {
            TheBeginnig:

                var resultLines = result.Split('\n');

                var effectResultBuilder = new StringBuilder();
                var particleCount = Random.Shared.Next((int)(resultLines.Length * 0.7), (int)(resultLines.Length * 0.9));

                // 0     1     2       3                4
                // i,    j,    step,   decorationChar,  isFinished
                int[,] particles = new int[particleCount, 5];
                for (int i = 0; i < particleCount; i++)
                {
                    particles[i, 0] = Random.Shared.Next(1, resultLines[0].Length - 1);
                    particles[i, 1] = Random.Shared.Next(1, resultLines.Length - 1);
                    particles[i, 2] = Random.Shared.Next(1, (int)(resultLines[0].Length * 0.2));
                    particles[i, 3] = 0;
                    particles[i, 4] = 0;
                }

                StringBuilder strBuilder;

                while (true)
                {
                    resultLines = result.Split("\n");
                    // replace every [i,j] with decorationCharacter
                    for (int i = 0; i < particles.Length / 5; i++)
                    {
                        var decoratoinChar = decoration.Effect.DecorationChars[Random.Shared.Next(0, decoration.Effect.DecorationChars.Count)];
                        strBuilder = new StringBuilder(resultLines[particles[i, 1]]);
                        strBuilder.Replace(' ', decoratoinChar, particles[i, 0], 1);
                        resultLines[particles[i, 1]] = strBuilder.ToString();
                    }

                    effectResultBuilder.AppendJoin('\n', resultLines);
                    Console.WriteLine(effectResultBuilder.ToString());

                    Thread.Sleep(sleep);
                    effectResultBuilder.Clear();
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    bool timeToStartOver = false;

                    // move particles
                    for (int i = 0; i < particleCount; i++)
                    {
                        var newPosition = particles[i, 0] + particles[i, 2];
                        if (newPosition >= resultLines.Length - 1)
                        {
                            particles[i, 0] = Random.Shared.Next(1, resultLines[0].Length - 1);
                            particles[i, 1] = Random.Shared.Next(1, resultLines.Length - 1);
                            particles[i, 2] = Random.Shared.Next(1, (int)(resultLines[0].Length * 0.2));
                            timeToStartOver &= Convert.ToBoolean(particles[i, 4]);
                        }
                        else
                        {
                            particles[i, 0] = newPosition;
                            particles[i, 4] = 1;
                        }
                    }

                    if (timeToStartOver)
                    {
                        goto TheBeginnig;
                    }
                }
            }
            else if (decoration.Effect.Behavior == ParticleBehavior.Rise)
            {
            Label:
                var resultLines = result.Split('\n');

                var effectResultBuilder = new StringBuilder();
                var particleCount = Random.Shared.Next((int)(resultLines[0].Length * 0.5), (int)(resultLines[0].Length * 0.8));
                // 0     1     2       3                4
                // i,    j,    step,   decorationChar,  isFinished
                int[,] particles = new int[particleCount, 5];
                for (int i = 0; i < particleCount; i++)
                {
                    particles[i, 0] = Random.Shared.Next(1, resultLines.Length - 1);
                    particles[i, 1] = Random.Shared.Next(1, resultLines[0].Length - 1);
                    particles[i, 2] = Random.Shared.Next(1, (int)(resultLines.Length * 0.2));
                    particles[i, 3] = 0;
                    particles[i, 4] = 0;
                }

                StringBuilder strBuilder;

                while (true)
                {
                    resultLines = result.Split("\n");
                    // replace every [i,j] with +
                    for (int i = 0; i < particles.Length / 5; i++)
                    {
                        var decoratoinChar = decoration.Effect.DecorationChars[Random.Shared.Next(0, decoration.Effect.DecorationChars.Count)];
                        strBuilder = new StringBuilder(resultLines[particles[i, 0]]);
                        strBuilder.Replace(' ', decoratoinChar, particles[i, 1], 1);
                        resultLines[particles[i, 0]] = strBuilder.ToString();
                    }

                    effectResultBuilder.AppendJoin('\n', resultLines);
                    Console.WriteLine(effectResultBuilder.ToString());

                    Thread.Sleep(sleep);
                    effectResultBuilder.Clear();
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    bool timeToStartOver = false;

                    // move particles
                    for (int i = 0; i < particleCount; i++)
                    {
                        var newPosition = particles[i, 0] - particles[i, 2];
                        if (newPosition <= 0)
                        {
                            particles[i, 0] = Random.Shared.Next(1, resultLines.Length - 1);
                            particles[i, 1] = Random.Shared.Next(1, resultLines[0].Length - 1);
                            particles[i, 2] = Random.Shared.Next(1, (int)(resultLines.Length * 0.2));
                            timeToStartOver &= Convert.ToBoolean(particles[i, 4]);
                        }
                        else
                        {
                            particles[i, 0] = newPosition;
                            particles[i, 4] = 1;
                        }
                    }
                    if (timeToStartOver)
                    {
                        goto Label;
                    }
                }
            }
            else if (decoration.Effect.Behavior == ParticleBehavior.FlyLeft)
            {
            TheBeginnig:

                var resultLines = result.Split('\n');

                var effectResultBuilder = new StringBuilder();
                var particleCount = Random.Shared.Next((int)(resultLines.Length * 0.7), (int)(resultLines.Length * 0.9));

                // 0     1     2       3                4
                // i,    j,    step,   decorationChar,  isFinished
                int[,] particles = new int[particleCount, 5];
                for (int i = 0; i < particleCount; i++)
                {
                    particles[i, 0] = Random.Shared.Next(1, resultLines[0].Length - 1);
                    particles[i, 1] = Random.Shared.Next(1, resultLines.Length - 1);
                    particles[i, 2] = Random.Shared.Next(1, (int)(resultLines[0].Length * 0.2));
                    particles[i, 3] = 0;
                    particles[i, 4] = 0;
                }

                StringBuilder strBuilder;

                while (true)
                {
                    resultLines = result.Split("\n");
                    // replace every [i,j] with decorationCharacter
                    for (int i = 0; i < particles.Length / 5; i++)
                    {
                        var decoratoinChar = decoration.Effect.DecorationChars[Random.Shared.Next(0, decoration.Effect.DecorationChars.Count)];
                        strBuilder = new StringBuilder(resultLines[particles[i, 1]]);
                        strBuilder.Replace(' ', decoratoinChar, particles[i, 0], 1);
                        resultLines[particles[i, 1]] = strBuilder.ToString();
                    }

                    effectResultBuilder.AppendJoin('\n', resultLines);
                    Console.WriteLine(effectResultBuilder.ToString());

                    Thread.Sleep(sleep);
                    effectResultBuilder.Clear();
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    bool timeToStartOver = false;

                    // move particles
                    for (int i = 0; i < particleCount; i++)
                    {
                        var newPosition = particles[i, 0] - particles[i, 2];
                        if (newPosition <= 0)
                        {
                            particles[i, 0] = Random.Shared.Next(1, resultLines[0].Length - 1);
                            particles[i, 1] = Random.Shared.Next(1, resultLines.Length - 1);
                            particles[i, 2] = Random.Shared.Next(1, (int)(resultLines[0].Length * 0.2));
                            timeToStartOver &= Convert.ToBoolean(particles[i, 4]);
                        }
                        else
                        {
                            particles[i, 0] = newPosition;
                            particles[i, 4] = 1;
                        }
                    }

                    if (timeToStartOver)
                    {
                        goto TheBeginnig;
                    }
                }
            }
            else if (decoration.Effect.Behavior == ParticleBehavior.RandomSpawn)
            {
                while(true)
                {
                    var resultLines = result.Split('\n');

                    var effectResultBuilder = new StringBuilder();
                    var particleCount = Random.Shared.Next(1, (int)(resultLines.Length * resultLines[0].Length * 0.1));

                    // i, j
                    int[,] particles = new int[particleCount, 2];
                    for (int j = 0; j < particleCount; j++)
                    {
                        particles[j, 0] = Random.Shared.Next(1, resultLines.Length - 1);
                        particles[j, 1] = Random.Shared.Next(1, resultLines[0].Length - 1);
                    }

                    StringBuilder strBuilder;


                    // replace every [i,j] with +
                    for (int i = 0; i < particles.Length / 3; i++)
                    {
                        var decorationChar = decoration.Effect.DecorationChars[Random.Shared.Next(0, decoration.Effect.DecorationChars.Count)];
                        strBuilder = new StringBuilder(resultLines[particles[i, 0]]);
                        strBuilder.Replace(' ', decorationChar, particles[i, 1], 1);
                        resultLines[particles[i, 0]] = strBuilder.ToString();
                    }

                    effectResultBuilder.AppendJoin('\n', resultLines);
                    Console.WriteLine(effectResultBuilder.ToString());

                    Thread.Sleep(sleep);
                    effectResultBuilder.Clear();
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);

                }
            }

        }

    }
}
