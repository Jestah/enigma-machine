namespace Enigma;

public class EncryptionDiscFactory
{
    public static EncryptionDisc CreateEtwEncryptionDisc()
    {
        var mapping = new Dictionary<char, char>(){
            ['Q'] = 'A',
            ['W'] = 'B',
            ['E'] = 'C',
            ['R'] = 'D',
            ['T'] = 'E',
            ['Z'] = 'F',
            ['U'] = 'G',
            ['I'] = 'H',
            ['O'] = 'I',
            ['A'] = 'J',
            ['S'] = 'K',
            ['D'] = 'L',
            ['F'] = 'M',
            ['G'] = 'N',
            ['H'] = 'O',
            ['J'] = 'P',
            ['K'] = 'Q',
            ['P'] = 'R',
            ['Y'] = 'S',
            ['X'] = 'T',
            ['C'] = 'U',
            ['V'] = 'V',
            ['B'] = 'W',
            ['N'] = 'X',
            ['M'] = 'Y',
            ['L'] = 'Z',
        };

        return new EncryptionDisc(mapping);
    }
    
    
    public static Rotor CreateRotorOneEncryptionDisc()
    {
        var mapping = new Dictionary<char, char>(){
            ['A'] = 'L',
            ['B'] = 'P',
            ['C'] = 'G',
            ['D'] = 'S',
            ['E'] = 'Z',
            ['F'] = 'M',
            ['G'] = 'H',
            ['H'] = 'A',
            ['I'] = 'E',
            ['J'] = 'O',
            ['K'] = 'Q',
            ['L'] = 'K',
            ['M'] = 'V',
            ['N'] = 'X',
            ['O'] = 'R',
            ['P'] = 'F',
            ['Q'] = 'Y',
            ['R'] = 'B',
            ['S'] = 'U',
            ['T'] = 'T',
            ['U'] = 'N',
            ['V'] = 'I',
            ['W'] = 'C',
            ['X'] = 'J',
            ['Y'] = 'D',
            ['Z'] = 'W',
        };

        int[] turnoverPositions = new int[] { 'Y' };

        return new Rotor(mapping, turnoverPositions);
    }
    
    
    public static Rotor CreateRotorTwoEncryptionDisc()
    {
        var mapping = new Dictionary<char, char>(){
            ['A'] = 'S',
            ['B'] = 'L',
            ['C'] = 'V',
            ['D'] = 'G',
            ['E'] = 'B',
            ['F'] = 'T',
            ['G'] = 'F',
            ['H'] = 'X',
            ['I'] = 'J',
            ['J'] = 'Q',
            ['K'] = 'O',
            ['L'] = 'H',
            ['M'] = 'E',
            ['N'] = 'W',
            ['O'] = 'I',
            ['P'] = 'R',
            ['Q'] = 'Z',
            ['R'] = 'Y',
            ['S'] = 'A',
            ['T'] = 'M',
            ['U'] = 'K',
            ['V'] = 'P',
            ['W'] = 'C',
            ['X'] = 'N',
            ['Y'] = 'D',
            ['Z'] = 'U',
        };

        int[] turnoverPositions = new int[] { 'E' };

        return new Rotor(mapping, turnoverPositions);
    }    
    
    
    public static Rotor CreateRotorThreeEncryptionDisc()
    {
        var mapping = new Dictionary<char, char>(){
            ['A'] = 'C',
            ['B'] = 'J',
            ['C'] = 'G',
            ['D'] = 'D',
            ['E'] = 'P',
            ['F'] = 'S',
            ['G'] = 'H',
            ['H'] = 'K',
            ['I'] = 'T',
            ['J'] = 'U',
            ['K'] = 'R',
            ['L'] = 'A',
            ['M'] = 'W',
            ['N'] = 'Z',
            ['O'] = 'X',
            ['P'] = 'F',
            ['Q'] = 'M',
            ['R'] = 'Y',
            ['S'] = 'N',
            ['T'] = 'Q',
            ['U'] = 'O',
            ['V'] = 'B',
            ['W'] = 'V',
            ['X'] = 'L',
            ['Y'] = 'I',
            ['Z'] = 'E',
        };

        int[] turnoverPositions = new int[] { 'N' };

        return new Rotor(mapping, turnoverPositions);
    }
    
    
    public static EncryptionDisc CreateUkwEncryptionDisc()
    {
        var mapping = new Dictionary<char, char>(){
            ['A'] = 'I',
            ['B'] = 'M',
            ['C'] = 'E',
            ['D'] = 'T',
            ['E'] = 'C',
            ['F'] = 'G',
            ['G'] = 'F',
            ['H'] = 'R',
            ['I'] = 'A',
            ['J'] = 'Y',
            ['K'] = 'S',
            ['L'] = 'Q',
            ['M'] = 'B',
            ['N'] = 'Z',
            ['O'] = 'X',
            ['P'] = 'W',
            ['Q'] = 'L',
            ['R'] = 'H',
            ['S'] = 'K',
            ['T'] = 'D',
            ['U'] = 'V',
            ['V'] = 'U',
            ['W'] = 'P',
            ['X'] = 'O',
            ['Y'] = 'J',
            ['Z'] = 'N',
        };

        return new EncryptionDisc(mapping);
    }
}