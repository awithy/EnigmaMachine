using Moq;
using NUnit.Framework;

namespace Enigma.Tests
{
    [TestFixture]
    public abstract class RotarTests
    {
        private Rotar _rotar;

        [TestFixture]
        public class When_converting_character : RotarTests
        {
            private char _reuslt;

            [SetUp]
            public void BecauseOf()
            {
                _rotar = new Rotar(3, 'K');
                _rotar.Shift();
                _reuslt = _rotar.Convert('E');
            }

            [Test]
            public void It_should_look_up_in_map()
            {
                Assert.That(_reuslt, Is.EqualTo('T'));
            }
        }

        [TestFixture]
        public class When_reverse_converting_character : RotarTests
        {
            private char _reuslt;

            [SetUp]
            public void BecauseOf()
            {
                _rotar = new Rotar(1, 'M');
                _reuslt = _rotar.Reverse('X');
            }

            [Test]
            public void It_should_look_up_in_map()
            {
                Assert.That(_reuslt, Is.EqualTo('N'));
            }
        }

        [TestFixture]
        public class When_shifting_rotar : RotarTests
        {
            private char _reuslt;

            [SetUp]
            public void BecauseOf()
            {
                _rotar = new Rotar(3, 'K');
                _rotar.Shift();
                _rotar.Shift();
                _rotar.Shift();
                _reuslt = _rotar.Convert('E');
            }

            [Test]
            public void It_should_look_up_in_map()
            {
                Assert.That(_reuslt, Is.EqualTo('J'));
            }
        }

        [TestFixture]
        public class When_shifting_rotar_with_connected_left_rotar : RotarTests
        {
            private Mock<IRotar> _leftRotar;

            [SetUp]
            public void BecauseOf()
            {
                _rotar = new Rotar(3, 'V');
                _leftRotar = new Mock<IRotar>();
                _rotar.LeftRotar = _leftRotar.Object;
                _rotar.Shift();
            }

            [Test]
            public void It_should_shift_the_left_rotar()
            {
               _leftRotar.Verify(x => x.Shift());
            }
        }

        [TestFixture]
        public class When_shifting_rotar_without_connected_left_rotar : RotarTests
        {
            [SetUp]
            public void BecauseOf()
            {
                _rotar = new Rotar(3, 'V');
                _rotar.Shift();
            }

            [Test]
            public void It_shouldnt_blow_up()
            {
            }
        }
    }
}
