namespace Enigma;

public class EnigmaMachine
{
    private readonly IRotor?[] _rotors;
    private readonly IEncryptionDisc _etw;
    private readonly IEncryptionDisc _ukw;

    public EnigmaMachine(IEncryptionDisc etw, IEncryptionDisc ukw, params IRotor[] rotors)
    {
        if (rotors.Length == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(rotors));
        _etw = etw;
        _rotors = rotors;
        _ukw = ukw;
    }

    public string Encrypt(string inputString)
    {
        if (inputString == null) throw new ArgumentNullException(nameof(inputString));
        
        var chars = inputString.ToCharArray();
        
        for (var i = 0; i < chars.Length; i++)
        {
            chars[i] = Encrypt(chars[i]);
        }

        return new string(chars);
    }

    public char Encrypt(char inputChar)
    {
        Increment();
        
        var charOut = inputChar;

        charOut = _etw.Encrypt(charOut);

        for (var i = _rotors.GetUpperBound(0); i >= 0; i--)
        {
            charOut = _rotors[i].Encrypt(charOut);
        }

        charOut = _ukw.Encrypt(charOut);

        for (var i = 0; i <= _rotors.GetUpperBound(0); i++)
        {
            charOut = _rotors[i].Decrypt(charOut);
        }

        charOut = _etw.Decrypt(charOut);

        return charOut;
    }

    private void Increment()
    {
        var rotorHasTurned = new bool[_rotors.Length];

        for (var rotorIndex = _rotors.GetUpperBound(0); rotorIndex >= 0; rotorIndex--)
        {
            var isFirstRotor = rotorIndex == _rotors.GetUpperBound(0);
            var currentRotor = _rotors[rotorIndex];
            IRotor? previousRotor = null;

            if (!isFirstRotor) previousRotor = _rotors[rotorIndex + 1];

            if (isFirstRotor && !rotorHasTurned[rotorIndex])
            {
                currentRotor!.Turn(1);
                rotorHasTurned[rotorIndex] = true;
            }
            
            if (previousRotor != null && previousRotor.IsNotchAligned())
            {
                currentRotor?.Turn(1);
                
                if (!rotorHasTurned[rotorIndex + 1])
                {
                    previousRotor!.Turn(1);
                    rotorHasTurned[rotorIndex + 1] = true;
                }
            }
        }
    }
}