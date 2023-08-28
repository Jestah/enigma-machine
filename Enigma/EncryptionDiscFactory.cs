namespace Enigma;

public class EncryptionDiscFactory
{
    public static EncryptionDisc CreateEtwEncryptionDisc()
    {
        var mapping = new List<Tuple<char,char>>(){
            new('Q', 'A'),
            new('W', 'B'),
            new('E', 'C'),
            new('R', 'D'),
            new('T', 'E'),
            new('Z', 'F'),
            new('U', 'G'),
            new('I', 'H'),
            new('O', 'I'),
            new('A', 'J'),
            new('S', 'K'),
            new('D', 'L'),
            new('F', 'M'),
            new('G', 'N'),
            new('H', 'O'),
            new('J', 'P'),
            new('K', 'Q'),
            new('P', 'R'),
            new('Y', 'S'),
            new('X', 'T'),
            new('C', 'U'),
            new('V', 'V'),
            new('B', 'W'),
            new('N', 'X'),
            new('M', 'Y'),
            new('L', 'Z'),
        };

        return new EncryptionDisc(mapping);
    }
    
    
    public static Rotor CreateRotorOneEncryptionDisc()
    {
        var mapping = new List<Tuple<char,char>>(){
            new('A', 'L'),
            new('B', 'P'),
            new('C', 'G'),
            new('D', 'S'),
            new('E', 'Z'),
            new('F', 'M'),
            new('G', 'H'),
            new('H', 'A'),
            new('I', 'E'),
            new('J', 'O'),
            new('K', 'Q'),
            new('L', 'K'),
            new('M', 'V'),
            new('N', 'X'),
            new('O', 'R'),
            new('P', 'F'),
            new('Q', 'Y'),
            new('R', 'B'),
            new('S', 'U'),
            new('T', 'T'),
            new('U', 'N'),
            new('V', 'I'),
            new('W', 'C'),
            new('X', 'J'),
            new('Y', 'D'),
            new('Z', 'W'),
        };

        var turnoverChars = new char[] { 'Y' };

        return new Rotor(mapping, turnoverChars);
    }
    
    
    public static Rotor CreateRotorTwoEncryptionDisc()
    {
        var mapping = new List<Tuple<char,char>>(){
            new('A', 'S'),
            new('B', 'L'),
            new('C', 'V'),
            new('D', 'G'),
            new('E', 'B'),
            new('F', 'T'),
            new('G', 'F'),
            new('H', 'X'),
            new('I', 'J'),
            new('J', 'Q'),
            new('K', 'O'),
            new('L', 'H'),
            new('M', 'E'),
            new('N', 'W'),
            new('O', 'I'),
            new('P', 'R'),
            new('Q', 'Z'),
            new('R', 'Y'),
            new('S', 'A'),
            new('T', 'M'),
            new('U', 'K'),
            new('V', 'P'),
            new('W', 'C'),
            new('X', 'N'),
            new('Y', 'D'),
            new('Z', 'U'),
        };

        var turnoverChars = new char[] { 'E' };

        return new Rotor(mapping, turnoverChars);
    }    
    
    
    public static Rotor CreateRotorThreeEncryptionDisc()
    {
        var mapping = new List<Tuple<char,char>>(){
            new('A', 'C'),
            new('B', 'J'),
            new('C', 'G'),
            new('D', 'D'),
            new('E', 'P'),
            new('F', 'S'),
            new('G', 'H'),
            new('H', 'K'),
            new('I', 'T'),
            new('J', 'U'),
            new('K', 'R'),
            new('L', 'A'),
            new('M', 'W'),
            new('N', 'Z'),
            new('O', 'X'),
            new('P', 'F'),
            new('Q', 'M'),
            new('R', 'Y'),
            new('S', 'N'),
            new('T', 'Q'),
            new('U', 'O'),
            new('V', 'B'),
            new('W', 'V'),
            new('X', 'L'),
            new('Y', 'I'),
            new('Z', 'E'),
        };

        var turnoverChars = new char[] { 'N' };

        return new Rotor(mapping, turnoverChars);
    }
    
    
    public static EncryptionDisc CreateUkwEncryptionDisc()
    {
        var mapping = new List<Tuple<char,char>>(){
            new('A', 'I'),
            new('B', 'M'),
            new('C', 'E'),
            new('D', 'T'),
            new('E', 'C'),
            new('F', 'G'),
            new('G', 'F'),
            new('H', 'R'),
            new('I', 'A'),
            new('J', 'Y'),
            new('K', 'S'),
            new('L', 'Q'),
            new('M', 'B'),
            new('N', 'Z'),
            new('O', 'X'),
            new('P', 'W'),
            new('Q', 'L'),
            new('R', 'H'),
            new('S', 'K'),
            new('T', 'D'),
            new('U', 'V'),
            new('V', 'U'),
            new('W', 'P'),
            new('X', 'O'),
            new('Y', 'J'),
            new('Z', 'N'),
        };

        return new EncryptionDisc(mapping);
    }
}