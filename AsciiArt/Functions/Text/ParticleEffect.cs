namespace AsciiArt.Functions
{
    public static partial class Functions
    {
        public struct ParticleEffect
        {

            public ParticleEffect(List<char> decorationChars, ParticleBehavior behavior)
            {
                DecorationChars = decorationChars;
                Behavior = behavior;
            }
            public ParticleEffect()
            {
                DecorationChars = new List<char>() { '×', '+' };
                Behavior = ParticleBehavior.RandomSpawn;
            }

            public List<char> DecorationChars { get; set; } = new List<char>() { '+', '×' };

            public ParticleBehavior Behavior { get; set; } = ParticleBehavior.FlyRight;
        }
    }
}
