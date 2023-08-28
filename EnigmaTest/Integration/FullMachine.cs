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
        _rotorOne.RotorPosition = _rotorOne.TurnoverPositions[0] - 1;
        _rotorTwo.RotorPosition = _rotorTwo.TurnoverPositions[0] - 1;
        _rotorThree.RotorPosition = _rotorThree.TurnoverPositions[0] - 1;

        SetupEnigmaMachine();
        
        _enigmaMachine!.Encrypt("AAA");
        
        Assert.Equal(_rotorOne.TurnoverPositions[0], _rotorOne.RotorPosition);
        Assert.Equal(_rotorTwo.TurnoverPositions[0] + 1, _rotorTwo.RotorPosition);
        Assert.Equal(_rotorThree.TurnoverPositions[0] + 1, _rotorThree.RotorPosition);
    }
}