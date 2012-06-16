namespace Enigma
{
    public interface IRotarFactory
    {
        IRotar GetRotar(int number, char startingPosition);
    }

    public class RotarFactory : IRotarFactory
    {
        public IRotar GetRotar(int number, char startingPosition)
        {
            return new Rotar(number, startingPosition);
        }
    }
}