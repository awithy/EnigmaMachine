namespace Enigma
{
    public interface IEnigmaMachine
    {
        char Convert(char source);
    }

    public class EnigmaMachine : IEnigmaMachine
    {
        private readonly IRotar _rotar1;
        private readonly IRotar _rotar2;
        private readonly IRotar _rotar3;
        private readonly IReflector _reflector = new Reflector();
        private Logger _logger = new Logger();

        public EnigmaMachine(int[] rotars, char[] rotarStartingPositions)
            : this(new RotarFactory(), rotars, rotarStartingPositions)
        {
        }

        public EnigmaMachine(IRotarFactory rotarFactory, int[] rotars, char[] rotarSetup)
        {
            _rotar1 = rotarFactory.GetRotar(rotars[0], rotarSetup[0]);
            _rotar2 = rotarFactory.GetRotar(rotars[1], rotarSetup[1]);
            _rotar3 = rotarFactory.GetRotar(rotars[2], rotarSetup[2]);
            _rotar3.LeftRotar = _rotar2;
            _rotar2.LeftRotar = _rotar1;
        }

        public char Convert(char source)
        {
            _rotar3.Shift();
            var r1 = _rotar3.Convert(source);
            var r2 = _rotar2.Convert(r1);
            var r3 = _rotar1.Convert(r2);
            var r4 = _reflector.Reflect(r3);
            var r5 = _rotar1.Reverse(r4);
            var r6 = _rotar2.Reverse(r5);
            var r7 = _rotar3.Reverse(r6);
            _logger.Log("Converted " + source + ":" + r7);
            return r7;
        }
    }
}