namespace Enigma
{
    public class Mapping
    {
        public char S;
        public char D;

        public Mapping(char s, char d)
        {
            S = s;
            D = d;
        }
    }

    public static class RotarMappings
    {
        public static Mapping[][] Mappings = new Mapping[][] {};
        static RotarMappings()
        {
            Mappings = new Mapping[3][];
            Mappings[0] = Rotar1Mapping;
            Mappings[1] = Rotar2Mapping;
            Mappings[2] = Rotar3Mapping;
        }

        private static readonly Mapping[] Rotar1Mapping = new[]
                                                    {
                                                        new Mapping('A', 'E'),
                                                        new Mapping('B', 'K'),
                                                        new Mapping('C', 'M'),
                                                        new Mapping('D', 'F'),
                                                        new Mapping('E', 'L'),
                                                        new Mapping('F', 'G'),
                                                        new Mapping('G', 'D'),
                                                        new Mapping('H', 'Q'),
                                                        new Mapping('I', 'V'),
                                                        new Mapping('J', 'Z'),
                                                        new Mapping('K', 'N'),
                                                        new Mapping('L', 'T'),
                                                        new Mapping('M', 'O'),
                                                        new Mapping('N', 'W'),
                                                        new Mapping('O', 'Y'),
                                                        new Mapping('P', 'H'),
                                                        new Mapping('Q', 'X'),
                                                        new Mapping('R', 'U'),
                                                        new Mapping('S', 'S'),
                                                        new Mapping('T', 'P'),
                                                        new Mapping('U', 'A'),
                                                        new Mapping('V', 'I'),
                                                        new Mapping('W', 'B'),
                                                        new Mapping('X', 'R'),
                                                        new Mapping('Y', 'C'),
                                                        new Mapping('Z', 'J'),
                                                    };

        private static readonly Mapping[] Rotar2Mapping = new[]
                                                    {
                                                        new Mapping('A', 'A'),
                                                        new Mapping('B', 'J'),
                                                        new Mapping('C', 'D'),
                                                        new Mapping('D', 'K'),
                                                        new Mapping('E', 'S'),
                                                        new Mapping('F', 'I'),
                                                        new Mapping('G', 'R'),
                                                        new Mapping('H', 'U'),
                                                        new Mapping('I', 'X'),
                                                        new Mapping('J', 'B'),
                                                        new Mapping('K', 'L'),
                                                        new Mapping('L', 'H'),
                                                        new Mapping('M', 'W'),
                                                        new Mapping('N', 'T'),
                                                        new Mapping('O', 'M'),
                                                        new Mapping('P', 'C'),
                                                        new Mapping('Q', 'Q'),
                                                        new Mapping('R', 'G'),
                                                        new Mapping('S', 'Z'),
                                                        new Mapping('T', 'N'),
                                                        new Mapping('U', 'P'),
                                                        new Mapping('V', 'Y'),
                                                        new Mapping('W', 'F'),
                                                        new Mapping('X', 'V'),
                                                        new Mapping('Y', 'O'),
                                                        new Mapping('Z', 'E'),
                                                    };

        private static readonly Mapping[] Rotar3Mapping = new[]
                                                    {
                                                        new Mapping('A', 'B'),
                                                        new Mapping('B', 'D'),
                                                        new Mapping('C', 'F'),
                                                        new Mapping('D', 'H'),
                                                        new Mapping('E', 'J'),
                                                        new Mapping('F', 'L'),
                                                        new Mapping('G', 'C'),
                                                        new Mapping('H', 'P'),
                                                        new Mapping('I', 'R'),
                                                        new Mapping('J', 'T'),
                                                        new Mapping('K', 'X'),
                                                        new Mapping('L', 'V'),
                                                        new Mapping('M', 'Z'),
                                                        new Mapping('N', 'N'),
                                                        new Mapping('O', 'Y'),
                                                        new Mapping('P', 'E'),
                                                        new Mapping('Q', 'I'),
                                                        new Mapping('R', 'W'),
                                                        new Mapping('S', 'G'),
                                                        new Mapping('T', 'A'),
                                                        new Mapping('U', 'K'),
                                                        new Mapping('V', 'M'),
                                                        new Mapping('W', 'U'),
                                                        new Mapping('X', 'S'),
                                                        new Mapping('Y', 'Q'),
                                                        new Mapping('Z', 'O'),
                                                    };
    }
}