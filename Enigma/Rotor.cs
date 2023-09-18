using System.Globalization;

namespace Enigma;

public class Rotor : EncryptionDisc, IRotor
{
    public Rotor(IList<Tuple<char, char>> mapping) : base(mapping)
    {
    }

    public Rotor(IList<Tuple<char, char>> mapping, char[] turnoverChars) : base(mapping)
    {
        TurnoverChars = turnoverChars;
    }

    public int RotorPosition { get; set; }

    public char[] TurnoverChars { get; set; } = { 'Z' };

    public void Turn(int turnAmount)
    {
        if (turnAmount <= 0) throw new ArgumentOutOfRangeException(nameof(turnAmount));

        this.RotorPosition = (this.RotorPosition + turnAmount) % this.DiscSize;
    }

    public override char Encrypt(char inputChar)
    {
        if (!EncryptionMapping.Select(tuple => tuple.Item1)
                .Contains(char.ToUpper(inputChar, CultureInfo.CurrentCulture)))
        {
            return inputChar;
        }

        var mappingIndex = EncryptionMapping.Select(tuple => tuple.Item1).ToList()
            .IndexOf(char.ToUpper(inputChar, CultureInfo.CurrentCulture));
        var rotationAdjustedMappingTuple =
            EncryptionMapping[Util.Mod(mappingIndex + RotorPosition, EncryptionMapping.Count)];
        var outcomeIndex = EncryptionMapping.Select(tuple => tuple.Item1).ToList()
            .IndexOf(rotationAdjustedMappingTuple.Item2);
        var encryptedChar = EncryptionMapping[Util.Mod(outcomeIndex - RotorPosition, EncryptionMapping.Count)].Item1;
        return char.IsLower(inputChar) ? char.ToLower(encryptedChar, CultureInfo.CurrentCulture) : encryptedChar;
    }

    public override char Decrypt(char inputChar)
    {
        if (!EncryptionMapping.Select(tuple => tuple.Item2)
                .Contains(char.ToUpper(inputChar, CultureInfo.CurrentCulture)))
        {
            return inputChar;
        }

        var mappingIndex = EncryptionMapping.Select(tuple => tuple.Item1).ToList()
            .IndexOf(char.ToUpper(inputChar, CultureInfo.CurrentCulture));
        var rotationAdjustedChar =
            EncryptionMapping[Util.Mod(mappingIndex + RotorPosition, EncryptionMapping.Count)].Item1;
        var outcomeIndex = EncryptionMapping.Select(tuple => tuple.Item2).ToList().IndexOf(rotationAdjustedChar);
        var decryptedChar = EncryptionMapping[Util.Mod(outcomeIndex - RotorPosition, EncryptionMapping.Count)].Item1;
        return char.IsLower(inputChar) ? char.ToLower(decryptedChar, CultureInfo.CurrentCulture) : decryptedChar;
    }

    public bool IsNotchAligned()
    {
        return TurnoverChars.Contains(EncryptionMapping[this.RotorPosition].Item1);
    }
}