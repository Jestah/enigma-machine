namespace Enigma;

public class Rotor : EncryptionDisc, IRotor
{
    public int RotorPosition { get; set; }

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
        return base.Encrypt((char)(inputChar + RotorPosition));
    }

    public override char Decrypt(char inputChar)
    {
        return base.Decrypt((char)(inputChar + RotorPosition));
    }

    public bool IsNotchAligned()
    {
        return TurnoverChars.Contains(EncryptionMapping[this.RotorPosition].Item1);
    }
}