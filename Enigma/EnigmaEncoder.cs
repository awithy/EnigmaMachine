using System.Linq;

namespace Enigma
{
    public class EnigmaEncoder
    {
        private IEnigmaMachine _enigmaMachine;

        public EnigmaEncoder(IEnigmaMachine enigmaMachine)
        {
            _enigmaMachine = enigmaMachine;
        }

        public string Encode(string message)
        {
            return new string(message.ToCharArray().Select(char.ToUpper).Select(_enigmaMachine.Convert).ToArray());
        }
    }
}