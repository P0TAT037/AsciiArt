namespace AsciiArt.Functions
{
    public static partial class Functions
    {
        //const string ASCII = " .'\\`^\",:;Il!i><~+_-?][}{1)(|/tfjrxnuvczXYUJCLQ0OZmwqpdbkhao*#MW&8%B@$";
        //const string ASCII = " `.-':_,^=;><+!rc*/z?sLTv)J7(|Fi{C}fI31tlu[neoZ5Yxjya]2ESwqkP6h9d4VpOGbUAKXHm8RD#$Bg0MNWQ%&@";

        public class TextDecoration
        {
            public TextDecoration()
            {
                VerticalBorder = '|';
                VerticalPadding = 2;
                HorizontalBorder = '-';
                HorizontalPadding = 2;
                Effect = new ParticleEffect();
            }

            public TextDecoration(char verticalBorder, char horizontalBorder, int verticalPadding, int horizontalPadding, ParticleEffect effect)
            {
                VerticalBorder = verticalBorder;
                HorizontalBorder = horizontalBorder;
                VerticalPadding = verticalPadding;
                HorizontalPadding = horizontalPadding;
                Effect = effect;
            }

            public int VerticalPadding { get; set; }

            public int HorizontalPadding { get; set; }

            public char VerticalBorder { get; set; }

            public char HorizontalBorder { get; set; }

            public ParticleEffect Effect { get; set; }

        }
    }
}
