namespace Enigma;

public class Rotor : EncryptionDisc, IRotor
{
    public int RotorPosition { get; set; } = 'A';

    public int[] TurnoverPositions { get; set; } = new int[] { 'Z' };

    private int GetRotorOffset()
    {
        return RotorPosition - 'A';
    }

    public Rotor(Dictionary<char, char> mapping) : base(mapping){}
    
    public Rotor(Dictionary<char, char> mapping, int[] turnoverPositions) : base(mapping)
    {
        TurnoverPositions = turnoverPositions;
    }
    
    public void Turn(int turnAmount)
    {
        if (turnAmount <= 0) throw new ArgumentOutOfRangeException(nameof(turnAmount));
        
    }

    public override char Encrypt(char inputChar)
    {
        return (char)(base.Encrypt(inputChar) + GetRotorOffset());
    }

    public override char Decrypt(char inputChar)
    {
        return (char)(base.Decrypt(inputChar) + GetRotorOffset());
    }

    public bool IsNotchAligned()
    {
        return TurnoverPositions.Contains(RotorPosition);
    }
}