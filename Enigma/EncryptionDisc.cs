using System.Globalization;

namespace Enigma;

public class EncryptionDisc : IEncryptionDisc
{
    public ICollection<Tuple<char, char>> EncryptionMapping { get; }
    public int DiscSize { get; }

    public EncryptionDisc(ICollection<Tuple<char, char>> mapping)
    {
        EncryptionMapping = mapping;
        DiscSize = mapping.Count;
    }
    
    public virtual char Encrypt(char inputChar)
    {
        var mappingTuple = EncryptionMapping.FirstOrDefault(m => m.Item1 == char.ToUpper(inputChar, CultureInfo.CurrentCulture));

        if (mappingTuple == null)
        {
            return inputChar;
        }

        var shift = mappingTuple.Item2 - mappingTuple.Item1;

        return (char)(inputChar + shift);    
    }
    
    public virtual char Decrypt(char inputChar)
    {
        var mappingTuple = EncryptionMapping.FirstOrDefault(m => m.Item2 == char.ToUpper(inputChar, CultureInfo.CurrentCulture));

        if (mappingTuple == null)
        {
            return inputChar;
        }

        var shift = mappingTuple.Item1 - mappingTuple.Item2;

        return (char)(inputChar + shift);
    }

    public int Size()
    {
        return EncryptionMapping.Count;
    }
}