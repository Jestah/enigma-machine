namespace Enigma;

public class EncryptionDisc : IEncryptionDisc
{
    public List<Tuple<char, char>> EncryptionMapping { get; }
    public int DiscSize { get; }

    public EncryptionDisc(List<Tuple<char, char>> mapping)
    {
        EncryptionMapping = mapping;
        DiscSize = mapping.Count;
    }
    
    public virtual char Encrypt(char inputChar)
    {
        var mappingTuple = EncryptionMapping.Find(m => m.Item1 == char.ToUpper(inputChar));

        if (mappingTuple == null)
        {
            throw new ArgumentNullException("EncryptionMapping.Find(m => m.Item1 == char.ToUpper(inputChar)");
        }

        var shift = mappingTuple.Item2 - mappingTuple.Item1;

        return (char)(inputChar + shift);    
    }
    
    public virtual char Decrypt(char inputChar)
    {
        var mappingTuple = EncryptionMapping.Find(m => m.Item2 == char.ToUpper(inputChar));

        if (mappingTuple == null)
        {
            throw new ArgumentNullException("EncryptionMapping.Find(m => m.Item2 == char.ToUpper(inputChar)");
        }

        var shift = mappingTuple.Item1 - mappingTuple.Item2;

        return (char)(inputChar + shift);
    }
}