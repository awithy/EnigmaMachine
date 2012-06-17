using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Enigma.Tests
{
    [Subject("Rotar")]
    public class When_converting_character_with_rotar : WithRotar
    {
        Establish context = () => _rotar = new Rotar(3, 'K');

        Because of = () => _result = _rotar.Convert('E');

        It should_convert_correctly = () => _result.ShouldEqual('O');
    }

    [Subject("Rotar")]
    public class When_reverse_converting_character_with_rotar : WithRotar
    {
        Establish context = () => _rotar = new Rotar(1, 'M');

        Because of = () => _result = _rotar.Reverse('X');

        It should_reverse_correctly = () => _result.ShouldEqual('N');
    }

    [Subject("Rotar")]
    public class When_shifting_rotar : WithRotar
    {
        Establish context = () => _rotar = new Rotar(3, 'K');

        Because of = () =>
        {
            _rotar.Shift();
            _rotar.Shift();
            _rotar.Shift();
            _result = _rotar.Convert('E');
        };

        It should_convert_correctly = () => _result.ShouldEqual('J');
    }

    [Subject("Rotar")]
    public class When_shifting_rotar_with_connected_left_rotar : WithRotar
    {
        Establish context = () => _rotar = new Rotar(3, 'V') {LeftRotar = _leftRotar.Object};

        Because of = () => _rotar.Shift();

        It should_shift_the_left_rotar_if_needed = () => _leftRotar.Verify(x => x.Shift(), Times.Once());

        static Mock<IRotar> _leftRotar = new Mock<IRotar>();
    }

    [Subject("Rotar")]
    public class When_shifting_rotar_without_connected_left_rotar : WithRotar
    {
        Establish context = () => _rotar = new Rotar(3, 'V');

        Because of = () => _rotar.Shift();

        It should_not_blow_up = () => { };
    }

    public class WithRotar
    {
        protected static Rotar _rotar;
        protected static char _result;
    }
}