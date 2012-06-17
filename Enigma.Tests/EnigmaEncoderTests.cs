using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Enigma.Tests
{
    [Subject("Enigma encoder acceptance")]
    public class When_converting_string_with_enigma_encoder
    {
        Because of = () => _outputMessage = _enigmaEncoder.Encode("QMJIDOMZWZJFJR");

        It should_convert_correctly = () => _outputMessage.ShouldEqual("ENIGMAREVEALED");

        static EnigmaEncoder _enigmaEncoder = new EnigmaEncoder(new EnigmaMachine(new[] {1, 2, 3}, new[] {'M', 'C', 'K'}));
        static string _outputMessage;
    }

    [Subject("Enigma encoder")]
    public class When_converting_string
    {
        Establish context = () =>
        {
            _enigmaMachine.Setup(x => x.Convert('A')).Returns('X');
            _enigmaMachine.Setup(x => x.Convert('B')).Returns('Y');
            _enigmaMachine.Setup(x => x.Convert('C')).Returns('Z');
        };

        Because of = () => _outputMessage = _enigmaEncoder.Encode("abc");

        It should_use_the_enigma_machine_to_encode_each_character_and_convert_to_uppercase = () =>
             _outputMessage.ShouldEqual( "XYZ"); 

        static Mock<IEnigmaMachine> _enigmaMachine = new Mock<IEnigmaMachine>();
        static EnigmaEncoder _enigmaEncoder = new EnigmaEncoder(_enigmaMachine.Object);
        static string _outputMessage;
    }
}
