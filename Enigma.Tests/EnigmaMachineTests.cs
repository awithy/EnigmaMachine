using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Enigma.Tests
{
    [Subject("Enigma machine acceptance")]
    public class When_converting_characters
    {
        static EnigmaMachine _enigmaMachine;
        static char _result;

        Establish context = () => _enigmaMachine = new EnigmaMachine(new[] {1, 2, 3}, new[] {'M', 'C', 'K'});

        Because of = () => _result = _enigmaMachine.Convert('E');

        It should_convert = () => _result.ShouldEqual('Q');
    }

    [Subject("Enigma machine")]
    public class When_setting_up_rotars
    {
        static Mock<IRotarFactory> _rotarFactory;
        static Rotar _rotar1 = new Rotar(1, 'M');
        static Rotar _rotar2 = new Rotar(2, 'C');
        static Rotar _rotar3 = new Rotar(3, 'K');

        Establish context = _SetupRotars;

        Because of = () => new EnigmaMachine(_rotarFactory.Object, new[] {1, 2, 3}, new[] {'M', 'C', 'K'});

        It should_set_the_left_rotars = () =>
        {
            _rotar3.LeftRotar.ShouldEqual(_rotar2);
            _rotar2.LeftRotar.ShouldEqual(_rotar1);
            _rotar1.LeftRotar.ShouldBeNull();
        };

        static void _SetupRotars()
        {
            _rotarFactory = new Mock<IRotarFactory>();
            _rotarFactory.Setup(x => x.GetRotar(1, 'M')).Returns(_rotar1);
            _rotarFactory.Setup(x => x.GetRotar(2, 'C')).Returns(_rotar2);
            _rotarFactory.Setup(x => x.GetRotar(3, 'K')).Returns(_rotar3);
        }
    }

    [Subject("Enigma machine")]
    public class When_converting_character
    {
        Establish context = () =>
        {
            _rotar3ShiftCount = 0;
            var rotarFactory = new Mock<IRotarFactory>();
            var rotar1 = new Mock<IRotar>();
            var rotar2 = new Mock<IRotar>();
            var rotar3 = new Mock<IRotar>();
            rotar3.Setup(x => x.Shift()).Callback(() => _rotar3ShiftCount++);
            rotarFactory.Setup(x => x.GetRotar(1, 'M')).Returns(rotar1.Object);
            rotarFactory.Setup(x => x.GetRotar(2, 'C')).Returns(rotar2.Object);
            rotarFactory.Setup(x => x.GetRotar(3, 'K')).Returns(rotar3.Object);
            rotar3.Setup(x => x.Convert('E')).Returns('T');
            rotar2.Setup(x => x.Convert('T')).Returns('W');
            rotar1.Setup(x => x.Convert('W')).Returns('J');
            rotar1.Setup(x => x.Reverse('X')).Returns('N');
            rotar2.Setup(x => x.Reverse('N')).Returns('S');
            rotar3.Setup(x => x.Reverse('S')).Returns('Q');
            _enigmaMachine = new EnigmaMachine(rotarFactory.Object, new[] {1, 2, 3}, new[] {'M', 'C', 'K'});
        };

        Because of = () => _output = _enigmaMachine.Convert('E');

        It should_convert_through_each_rotar_reflector_and_reverse_through_rotars = () => _output.ShouldEqual('Q');

        It should_shift_the_third_rotars_before_each_character = () => _rotar3ShiftCount.ShouldEqual(1);

        static int _rotar3ShiftCount;
        static char _output;
        static EnigmaMachine _enigmaMachine;
    }
}