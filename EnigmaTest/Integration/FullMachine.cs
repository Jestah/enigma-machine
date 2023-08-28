using Enigma;
using Moq;

namespace EnigmaTest.Integration;

public class FullMachine
{
    private IRotor _rotorOne;
    private IRotor _rotorTwo;
    private IRotor _rotorThree;
    private readonly EnigmaMachine _enigmaMachine;

    public FullMachine()
    {
        _rotorOne = EncryptionDiscFactory.CreateRotorOneEncryptionDisc();
        _rotorTwo = EncryptionDiscFactory.CreateRotorTwoEncryptionDisc();
        _rotorThree = EncryptionDiscFactory.CreateRotorThreeEncryptionDisc();

        var etw = EncryptionDiscFactory.CreateEtwEncryptionDisc();
        var ukw = EncryptionDiscFactory.CreateUkwEncryptionDisc();

        _enigmaMachine = new EnigmaMachine(etw, ukw, _rotorOne, _rotorTwo, _rotorThree);
    }

    [Fact]
        public void eachRotorBeforeTurnover_incrementTwice_doubleStepping()
        {
            _rotorOne.RotorPosition = _rotorOne.TurnoverPositions[0] - 1;
            _rotorTwo.RotorPosition = _rotorTwo.TurnoverPositions[0] - 1;
            _rotorThree.RotorPosition = _rotorThree.TurnoverPositions[0] - 1;
    
            _enigmaMachine!.Encrypt("AA");
            
            Assert.Equal(_rotorOne.TurnoverPositions[0], _rotorOne.RotorPosition);
            Assert.Equal(_rotorTwo.TurnoverPositions[0] + 1, _rotorTwo.RotorPosition);
            Assert.Equal(_rotorThree.TurnoverPositions[0] + 1, _rotorThree.RotorPosition);
        }
}