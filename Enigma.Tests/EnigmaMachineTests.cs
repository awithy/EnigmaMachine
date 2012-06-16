using Moq;
using NUnit.Framework;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnaccessedField.Global
// ReSharper disable InconsistentNaming
// ReSharper disable PossibleNullReferenceException
// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable FieldCanBeMadeReadOnly.Global

namespace Enigma.Tests
{
    [TestFixture]
    public class EnigmaMachineTests
    {
        private EnigmaMachine _enigmaMachine;

        [SetUp]
        public void SetUp()
        {
            _enigmaMachine = new EnigmaMachine(new[] {1, 2, 3}, new[] {'M', 'C', 'K'});
        }

        [TestFixture]
        public abstract class Acceptance_tests : EnigmaMachineTests
        {
            [TestFixture]
            public class When_converting_characters : Acceptance_tests
            {
                private char _first;

                [SetUp]
                public void BecauseOf()
                {
                    _first = _enigmaMachine.Convert('E');
                }

                [Test]
                public void It_should_convert_correctly()
                {
                    Assert.That(_first, Is.EqualTo('Q'));
                }
            }
        }

        [TestFixture]
        public class When_setting_up : EnigmaMachineTests
        {
            private Rotar _rotar1;
            private Rotar _rotar2;
            private Rotar _rotar3;

            [SetUp]
            public void BecauseOf()
            {
                _rotar1 = new Rotar(1, 'A');
                _rotar2 = new Rotar(2, 'B');
                _rotar3 = new Rotar(3, 'C');
                var rotarFactory = new Mock<IRotarFactory>();
                rotarFactory.Setup(x => x.GetRotar(1, 'A')).Returns(_rotar1);
                rotarFactory.Setup(x => x.GetRotar(2, 'B')).Returns(_rotar2);
                rotarFactory.Setup(x => x.GetRotar(3, 'C')).Returns(_rotar3);
                _enigmaMachine = new EnigmaMachine(rotarFactory.Object, new []{ 1, 2, 3 }, new []{ 'A', 'B', 'C' });
            }

            [Test]
            public void It_should_write_up_the_left_rotars()
            {
                Assert.That(_rotar3.LeftRotar, Is.EqualTo(_rotar2));
                Assert.That(_rotar2.LeftRotar, Is.EqualTo(_rotar1));
            }
        }

        [TestFixture]
        public class When_converting_characters_through_build_rotars : EnigmaMachineTests
        {
            private char _result;
            private static Mock<IRotar> _rotar3;

            [SetUp]
            public void BecauseOf()
            {
                var rotarFactory = _SetupRotars();
                var enigmaMachine = new EnigmaMachine(rotarFactory.Object, new []{ 1, 2, 3 }, new []{ 'M', 'C', 'K' });
                _result = enigmaMachine.Convert('E');
            }

            private static Mock<IRotarFactory> _SetupRotars()
            {
                var rotarFactory = new Mock<IRotarFactory>();
                var rotar1 = new Mock<IRotar>();
                var rotar2 = new Mock<IRotar>();
                _rotar3 = new Mock<IRotar>();
                rotarFactory.Setup(x => x.GetRotar(1, 'M')).Returns(rotar1.Object);
                rotarFactory.Setup(x => x.GetRotar(2, 'C')).Returns(rotar2.Object);
                rotarFactory.Setup(x => x.GetRotar(3, 'K')).Returns(_rotar3.Object);
                _rotar3.Setup(x => x.Convert('E')).Returns('T');
                rotar2.Setup(x => x.Convert('T')).Returns('W');
                rotar1.Setup(x => x.Convert('W')).Returns('J');
                rotar1.Setup(x => x.Reverse('X')).Returns('N');
                rotar2.Setup(x => x.Reverse('N')).Returns('S');
                _rotar3.Setup(x => x.Reverse('S')).Returns('Q');
                return rotarFactory;
            }

            [Test]
            public void It_should_pass_through_each_rotar_and_back_again()
            {
                Assert.That(_result, Is.EqualTo('Q'));
            }

            [Test]
            public void It_should_shift_the_last_rotar()
            {
                _rotar3.Verify(x => x.Shift());
            }
        }
    }
}