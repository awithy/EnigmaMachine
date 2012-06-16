using System;
using System.Linq;

namespace Enigma
{
    public interface IRotar
    {
        char Convert(char source);
        char Reverse(char source);
        void Shift();
        IRotar LeftRotar { get; set; }
    }

    public class Rotar : IRotar
    {
        private readonly int _rotarNumber;
        private readonly Mapping[] _mapping;
        private readonly int _startingPositionIndex;
        private readonly int _shiftPosition;
        private int _shift;
        public IRotar LeftRotar { get; set; }
        private readonly Logger _logger = new Logger();

        public Rotar(int rotarNumber, char startingPosition)
        {
            _rotarNumber = rotarNumber;
            _startingPositionIndex = startingPosition.Index();
            var rotarIndex = rotarNumber - 1;
            _shiftPosition = RotarShiftPositions.ShiftPositions[rotarIndex];
            _mapping = RotarMappings.Mappings[rotarIndex];
        }

        public char Convert(char source)
        {
            var sourceIndex = source.Index();
            var indexLookup = _ShiftedPosition(sourceIndex);
            var converted = _mapping[indexLookup].D;
            var convertedIndex = converted.Index();
            var result = _ReverseShiftedPosition(convertedIndex);
            _logger.Debug(string.Format("Rotar {0} converted {1}:{2}",_rotarNumber, source, result.Char()));
            return result.Char();
        }

        public char Reverse(char source)
        {
            var sourceIndex = source.Index();
            var sourceMatchIndex = _ShiftedPosition(sourceIndex);
            var sourceMatch = _mapping.ElementAt(sourceMatchIndex).S;
            for(var i = 0; i < _mapping.Length; i++)
            {
                if(_mapping[i].D == sourceMatch)
                {
                    var resultIndex = _ReverseShiftedPosition(i);
                    var result = resultIndex.Char();
                    _logger.Debug(string.Format("Rotar {0} reverse {1}:{2}", _rotarNumber, source, result));
                    return result;
                }
            }
            throw new ArgumentException("Not found");
        }

        private int _ShiftedPosition(int sourceIndex)
        {
            return (sourceIndex + _CurrentPosition()) % 26;
        }

        private int _ReverseShiftedPosition(int convertedIndex)
        {
            return ((convertedIndex - _CurrentPosition()) + 26) % 26;
        }

        public void Shift()
        {
            _logger.Log("Rotar " + _rotarNumber + " shifting");
            _ShiftLeftRotarIfNeeded();
            _shift++;
        }

        private void _ShiftLeftRotarIfNeeded()
        {
            if (LeftRotar != null && _CurrentPosition() == _shiftPosition)
                LeftRotar.Shift();
        }

        private int _CurrentPosition()
        {
            return (_startingPositionIndex + _shift)%26;
        }
    }

    public static class CharExtensions
    {
        public static int Index(this char c)
        {
            return c - 65;
        }
    }

    public static class IntExtensions
    {
        public static char Char(this int c)
        {
            return (char)(65 + c);
        }
    }

    public static class RotarShiftPositions
    {
        public static readonly int[] ShiftPositions;

        static RotarShiftPositions()
        {
            ShiftPositions = new []{ 16, 4, 21 };
        }
    }
}