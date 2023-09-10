using Enigma;
using NSubstitute;

namespace EnigmaTest.Unit.EnigmaMachineTest;

public class EncryptTest
{
    private readonly IEncryptionDisc _mockEtw = Substitute.For<IEncryptionDisc>();
    private readonly IEncryptionDisc _mockUkw = Substitute.For<IEncryptionDisc>();
    private readonly IRotor _mockRotorOne = Substitute.For<IRotor>();
    private readonly IRotor _mockRotorTwo = Substitute.For<IRotor>();
    private readonly IRotor _mockRotorThree = Substitute.For<IRotor>();

    private EnigmaMachine? _enigmaMachine;

    
    [Fact]
    public void encryptSingleChar_rotorOneTurns1()
    {
        SetupEnigmaMachine();
        
        _enigmaMachine!.Encrypt('A');
        
        _mockRotorThree.Received(1).Turn(1);
    }

    
    [Fact]
    public void encrypt_rollover_turnNextRotor()
    {
        _mockRotorThree.IsNotchAligned().Returns(true);
        SetupEnigmaMachine();

        _enigmaMachine!.Encrypt('A');
        
        _mockRotorThree.Received(1).Turn(1);

    }
    
    
    private void SetupEnigmaMachine()
    {
        _enigmaMachine = new EnigmaMachine(_mockEtw, _mockUkw, _mockRotorOne, _mockRotorTwo, _mockRotorThree);
    }
    
    
    

}