namespace Enigma;

public class EncryptionDisc : IEncryptionDisc
{
    public Dictionary<char, char> EncryptionMapping { get; }
    public Dictionary<char, char> ReverseEncryptionMapping { get; }
    public int DiscSize { get; }

    public EncryptionDisc(Dictionary<char, char> mapping)
    {
        EncryptionMapping = mapping;
        ReverseEncryptionMapping = mapping.ToDictionary((i) => i.Value, (i) => i.Key);
        DiscSize = mapping.Count;
    }
    
    public virtual char Encrypt(char inputChar)
    {
        return CaseInsensitiveMapping(EncryptionMapping, inputChar);
    }
    
    public virtual char Decrypt(char inputChar)
    {
        return CaseInsensitiveMapping(ReverseEncryptionMapping, inputChar);
    }

    private static char CaseInsensitiveMapping(IReadOnlyDictionary<char, char> mapping, char inputChar)
    {
        var upperInputChar = char.ToUpper(inputChar);
        var charMappingDistance =  mapping[upperInputChar] - upperInputChar;
        return (char) (inputChar + charMappingDistance);
    }
}