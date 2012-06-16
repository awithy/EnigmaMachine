using System.Collections.Generic;

namespace Enigma
{
    public interface IReflector
    {
        char Reflect(char source);
    }

    public class Reflector : IReflector
    {
        private Logger _logger = new Logger();
        public char Reflect(char source)
        {
            var reflected = _mappings[source];
            _logger.Debug("Reflected " + source + ":" + reflected);
            return reflected;
        }

        private readonly Dictionary<char, char> _mappings = new Dictionary<char, char>();
        public Reflector()
        {
            _mappings.Add('A', 'Y');
            _mappings.Add('B', 'R');
            _mappings.Add('C', 'U');
            _mappings.Add('D', 'H');
            _mappings.Add('E', 'Q');
            _mappings.Add('F', 'S');
            _mappings.Add('G', 'L');
            _mappings.Add('H', 'D');
            _mappings.Add('I', 'P');
            _mappings.Add('J', 'X');
            _mappings.Add('K', 'N');
            _mappings.Add('L', 'G');
            _mappings.Add('M', 'O');
            _mappings.Add('N', 'K');
            _mappings.Add('O', 'M');
            _mappings.Add('P', 'I');
            _mappings.Add('Q', 'E');
            _mappings.Add('R', 'B');
            _mappings.Add('S', 'F');
            _mappings.Add('T', 'Z');
            _mappings.Add('U', 'C');
            _mappings.Add('V', 'W');
            _mappings.Add('W', 'V');
            _mappings.Add('X', 'J');
            _mappings.Add('Y', 'A');
            _mappings.Add('Z', 'T');
        }
    }
}