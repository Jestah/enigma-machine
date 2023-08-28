using Enigma;
using Moq;

namespace EnigmaTest.Integration;

public class FullMachine
{
    private IRotor _rotorOne = EncryptionDiscFactory.CreateRotorOneEncryptionDisc();
    private IRotor _rotorTwo = EncryptionDiscFactory.CreateRotorTwoEncryptionDisc();
    private IRotor _rotorThree = EncryptionDiscFactory.CreateRotorThreeEncryptionDisc();
    private readonly EncryptionDisc _etw = EncryptionDiscFactory.CreateEtwEncryptionDisc();
    private readonly EncryptionDisc _ukw = EncryptionDiscFactory.CreateUkwEncryptionDisc();
    private EnigmaMachine? _enigmaMachine;

    void SetupEnigmaMachine()
    {
        _enigmaMachine = new EnigmaMachine(_etw, _ukw, _rotorOne, _rotorTwo, _rotorThree);
    }
    
    [Fact]
    public void eachRotorBeforeTurnover_incrementTwice_doubleStepping()
    {
        _rotorOne.TurnoverChars = new []{'B'};
        _rotorTwo.TurnoverChars = new []{'B'};
        _rotorThree.TurnoverChars = new []{'B'};
        _rotorOne.RotorPosition = 0;
        _rotorTwo.RotorPosition = 0;
        _rotorThree.RotorPosition = 0;

        SetupEnigmaMachine();
        
        _enigmaMachine!.Encrypt("AAA");
        
        Assert.Equal(1, _rotorOne.RotorPosition);
        Assert.Equal(2, _rotorTwo.RotorPosition);
        Assert.Equal(3, _rotorThree.RotorPosition);
    }
}