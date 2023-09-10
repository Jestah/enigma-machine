using System.Collections;

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
            try
            {
                chars[i] = Encrypt(chars[i]);
            }
            catch
            {
                // ignored so that any char that can't be encrypted just stays the same.
            }
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

    public IEnumerable GetRotorPositions()
    {
        return _rotors.Select(r => r.RotorPosition).ToList();
    }

    public void SetRotorPositions(int[] rotorPositions)
    {
        if (rotorPositions.Length != _rotors.Length)
        {
            throw new ArgumentException(
                $"Expected {_rotors.Length} rotor positions. Only received {rotorPositions.Length}");
        }

        ValidateRotorPositions(rotorPositions);
        
        for (var i = 0; i < rotorPositions.Length; i++)
        {
            _rotors[i].RotorPosition = rotorPositions[i];
        }
    }

    private void ValidateRotorPositions(int[] rotorPositions)
    {
        var rotorBounds = new List<int>();
        var rotorsOutOfBounds = new List<int>();
        for (int i = 0; i < rotorPositions.Length; i++)
        {
            if (rotorPositions[i] >= _rotors[i].DiscSize)
            {
                rotorsOutOfBounds.Add(i + 1);
                rotorBounds.Add(_rotors[i].DiscSize);
            }
        }

        if (rotorsOutOfBounds.Count > 0)
        {
            throw new ArgumentException(
                $"Rotor position(s) {string.Join(", ", rotorsOutOfBounds)} too large. Must be smaller than the size of the encryption disc.");
        }
    }
}