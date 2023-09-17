using System.Collections;

namespace Enigma;

public class EnigmaMachine
{
    private readonly IList<IRotor> _rotors;
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
        IncrementRotors();
        
        var charOut = inputChar;

        charOut = _etw.Encrypt(charOut);

        for (var i = _rotors.Count-1; i >= 0; i--)
        {
            charOut = _rotors[i]!.Encrypt(charOut);
        }

        charOut = _ukw.Encrypt(charOut);

        for (var i = 0; i <= _rotors.Count-1; i++)
        {
            charOut = _rotors[i]!.Decrypt(charOut);
        }

        charOut = _etw.Decrypt(charOut);

        return charOut;
    }

    private void IncrementRotors()
    {
        var rotorHasTurned = new bool[_rotors.Count];

        for (var rotorIndex = 0; rotorIndex < _rotors.Count; rotorIndex++)
        {
            var rotor = _rotors[rotorIndex];
            
            if (!rotorHasTurned[rotorIndex] && ShouldTurnOnIncrement(rotor, rotorHasTurned))
            {
                rotor!.Turn(1);
                rotorHasTurned[rotorIndex] = true;
            }
        }
    }

    private bool ShouldTurnOnIncrement(IRotor rotor, bool[] rotorHasTurned)
    {
        var rotorIndex = _rotors.IndexOf(rotor);
        var isFirstRotor = rotorIndex == _rotors.Count-1;
        var isLastRotor = rotorIndex ==0;
        IRotor? previousRotor = null;
        bool doubleStepRotor = false;

        if (isFirstRotor)
        {
            return true;
        }

        previousRotor = _rotors[rotorIndex + 1];

        if (!isLastRotor) doubleStepRotor = rotorHasTurned[rotorIndex - 1];
        
        return doubleStepRotor || previousRotor.IsNotchAligned();
    }

    public IEnumerable GetRotorPositions()
    {
        return _rotors.Select(r => r!.RotorPosition).ToList();
    }

    public void SetRotorPositions(int[] rotorPositions)
    {
        if (rotorPositions.Length != _rotors.Count)
        {
            throw new ArgumentException($"Expected {_rotors.Count} rotor positions. Only received {rotorPositions.Length}", nameof(rotorPositions));
        }

        ValidateRotorPositions(rotorPositions);
        
        for (var i = 0; i < rotorPositions.Length; i++)
        {
            _rotors[i]!.RotorPosition = rotorPositions[i];
        }
    }

    private void ValidateRotorPositions(int[] rotorPositions)
    {
        var rotorsOutOfBounds = new List<int>();
        for (var i = 0; i < rotorPositions.Length; i++)
        {
            if (rotorPositions[i] < _rotors[i]!.DiscSize) continue;
            rotorsOutOfBounds.Add(i + 1);
        }

        if (rotorsOutOfBounds.Count > 0)
        {
            throw new ArgumentException(
                $"Rotor position(s) {string.Join(", ", rotorsOutOfBounds)} too large. Must be smaller than the size of the encryption disc.", nameof(rotorPositions));
        }
    }
}