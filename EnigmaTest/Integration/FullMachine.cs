using Enigma;

namespace EnigmaTest.Integration;

public class FullMachine
{
    private static readonly EncryptionDisc Etw = EncryptionDiscFactory.CreateEtwEncryptionDisc();
    private static readonly EncryptionDisc Ukw = EncryptionDiscFactory.CreateUkwEncryptionDisc();
    private static readonly Rotor RotorOne = EncryptionDiscFactory.CreateRotorOneEncryptionDisc();
    private static readonly Rotor RotorTwo = EncryptionDiscFactory.CreateRotorTwoEncryptionDisc();
    private static readonly Rotor RotorThree = EncryptionDiscFactory.CreateRotorThreeEncryptionDisc();
    private readonly EnigmaMachine _enigmaMachine = new EnigmaMachine(Etw, Ukw, RotorOne, RotorTwo, RotorThree);
    
    [Fact]
    public void eachRotorBeforeTurnover_incrementTwice_doubleStepping()
    {
        RotorOne.TurnoverChars = new []{'B'};
        RotorTwo.TurnoverChars = new []{'B'};
        RotorThree.TurnoverChars = new []{'B'};
        RotorOne.RotorPosition = 0;
        RotorTwo.RotorPosition = 0;
        RotorThree.RotorPosition = 0;
        
        _enigmaMachine!.Encrypt("AAA");
        
        Assert.Equal(1, RotorOne.RotorPosition);
        Assert.Equal(2, RotorTwo.RotorPosition);
        Assert.Equal(3, RotorThree.RotorPosition);
    }
    
    [Theory]
    [InlineData(" ")]
    [InlineData("String with spaces")]
    [InlineData("String\twith\ttabs")]
    [InlineData("String\nwith\nnewlines")]
    public void stringWithWhitespace_encrypted_resultHasSameWhitespace(string input)
    {
        var encrypted = _enigmaMachine?.Encrypt(input);
        
        Assert.Equivalent(input.Split().Select(s => s.Length), encrypted.Split().Select(s => s.Length));
    }
}