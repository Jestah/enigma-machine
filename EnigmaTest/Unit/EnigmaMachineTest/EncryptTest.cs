using Enigma;
using Moq;

namespace EnigmaTest.Unit.EnigmaMachineTest;

public class EncryptTest
{
    private readonly Mock<IEncryptionDisc> _mockEtw = new();
    private readonly Mock<IEncryptionDisc> _mockUkw = new();
    private readonly Mock<IRotor> _mockRotorOne = new();
    private readonly Mock<IRotor> _mockRotorTwo = new();
    private readonly Mock<IRotor> _mockRotorThree = new();

    private EnigmaMachine? _enigmaMachine;

    
    [Fact]
    public void encryptSingleChar_rotorOneTurns1()
    {
        SetupEnigmaMachine();
        
        _enigmaMachine!.Encrypt('A');
        
        _mockRotorThree.Verify(rotor => rotor.Turn(1), Times.Once);
    }

    
    [Fact]
    public void encrypt_rollover_turnNextRotor()
    {
        _mockRotorThree.Setup(m => m.IsNotchAligned())
            .Returns(true);
        SetupEnigmaMachine();

        _enigmaMachine!.Encrypt('A');
        
        _mockRotorTwo.Verify(m => m.Turn(1), Times.Once);

    }
    
    
    private void SetupEnigmaMachine()
    {
        _enigmaMachine = new EnigmaMachine(_mockEtw.Object, _mockUkw.Object, _mockRotorOne.Object, _mockRotorTwo.Object, _mockRotorThree.Object);
    }
    
    
    

}