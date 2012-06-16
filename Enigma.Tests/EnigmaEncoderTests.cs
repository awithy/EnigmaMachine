using Moq;
using NUnit.Framework;

namespace Enigma.Tests
{
    [TestFixture]
    public abstract class EnigmaEncoderTests
    {
        [TestFixture]
        public class Acceptance_Tests : EnigmaEncoderTests
        {
            private string _output;

            [SetUp]
            public void BecauseOf()
            {
                var enigmaEncoder = new EnigmaEncoder(new EnigmaMachine(new[] {1, 2, 3}, new[] {'M', 'C', 'K'}));
                _output = enigmaEncoder.Encode("QMJIDOMZWZJFJR");
            }

            [Test]
            public void It_should_convert_correctly()
            {
                Assert.That(_output, Is.EqualTo("ENIGMAREVEALED"));
            }
        }

        [TestFixture]
        public class When_encoding_string : EnigmaEncoderTests
        {
            private EnigmaEncoder _enigmaEncoder;
            private Mock<IEnigmaMachine> _enigmaMachine;
            private string _output;

            [SetUp]
            public void BecauseOf()
            {
                _enigmaMachine = new Mock<IEnigmaMachine>();
                _enigmaEncoder = new EnigmaEncoder(_enigmaMachine.Object);
                _enigmaMachine.Setup(x => x.Convert('A')).Returns('X');
                _enigmaMachine.Setup(x => x.Convert('B')).Returns('Y');
                _enigmaMachine.Setup(x => x.Convert('C')).Returns('Z');
                _output = _enigmaEncoder.Encode("abc");
            }

            [Test]
            public void It_should_use_the_enigma_encoder()
            {
                Assert.That(_output, Is.EqualTo("XYZ"));
            }
        }
    }
}
