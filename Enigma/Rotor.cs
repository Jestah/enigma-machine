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
        var encryptedChar = base.Encrypt((char)(inputChar + RotorPosition));
        if (!EncryptionMapping.Select(tuple => tuple.Item1).Contains(char.ToUpper((char)(inputChar + RotorPosition))))
        {
            encryptedChar -= base.Encrypt();
        }
        return encryptedChar;
    }

    public override char Decrypt(char inputChar)
    {
        var decryptedChar = base.Decrypt((char)(inputChar + RotorPosition));
        if (!EncryptionMapping.Select(tuple => tuple.Item1).Contains(char.ToUpper(inputChar)))
        {
            decryptedChar -= inputChar;
        }
        return decryptedChar;
    }

    public bool IsNotchAligned()
    {
        return TurnoverChars.Contains(EncryptionMapping[this.RotorPosition].Item1);
    }
}