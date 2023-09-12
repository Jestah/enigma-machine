namespace Enigma;

public class Rotor : EncryptionDisc, IRotor
{
    public int RotorPosition { get; set; } = 0;

    public char[] TurnoverChars { get; set; } = { 'Z' };

    public Rotor(List<Tuple<char,char>> mapping) : base(mapping){}
    
    public Rotor(List<Tuple<char,char>> mapping, char[] turnoverChars) : base(mapping)
    {
        TurnoverChars = turnoverChars;
    }
    
    public void Turn(int turnAmount)
    {
        if (turnAmount <= 0) throw new ArgumentOutOfRangeException(nameof(turnAmount));
        
        this.RotorPosition = (this.RotorPosition + turnAmount) % this.DiscSize;
    }

    public override char Encrypt(char inputChar)
    {
        if (!EncryptionMapping.Select(tuple => tuple.Item1).Contains(char.ToUpper(inputChar)))
        {
            throw new ArgumentException("Input char not in encryption mapping");
        }
        
        var isLower = char.IsLower(inputChar);
        var mappingIndex = EncryptionMapping.Select(tuple => tuple.Item1).ToList().IndexOf(char.ToUpper(inputChar));
        var rotationAdjustedMappingTuple = EncryptionMapping[Util.Mod(mappingIndex + RotorPosition, EncryptionMapping.Count)];
        var outcomeIndex = EncryptionMapping.Select(tuple => tuple.Item1).ToList().IndexOf(rotationAdjustedMappingTuple.Item2);
        var encryptedChar = EncryptionMapping[Util.Mod(outcomeIndex - RotorPosition, EncryptionMapping.Count)].Item1;
        return char.IsLower(inputChar) ? char.ToLower(encryptedChar) : encryptedChar;
    }

    public override char Decrypt(char inputChar)
    {
        if (!EncryptionMapping.Select(tuple => tuple.Item2).Contains(char.ToUpper(inputChar)))
        {
            throw new ArgumentException("Input char not in encryption mapping");
        }
        
        var isLower = char.IsLower(inputChar);
        var mappingIndex = EncryptionMapping.Select(tuple => tuple.Item1).ToList().IndexOf(char.ToUpper(inputChar));
        var rotationAdjustedChar =
            EncryptionMapping[Util.Mod(mappingIndex + RotorPosition, EncryptionMapping.Count)].Item1;
        var outcomeIndex = EncryptionMapping.Select(tuple => tuple.Item2).ToList().IndexOf(rotationAdjustedChar);
        var decryptedChar = EncryptionMapping[Util.Mod(outcomeIndex - RotorPosition, EncryptionMapping.Count)].Item1;
        return char.IsLower(inputChar) ? char.ToLower(decryptedChar) : decryptedChar;
    }

    public bool IsNotchAligned()
    {
        return TurnoverChars.Contains(EncryptionMapping[this.RotorPosition].Item1);
    }
}