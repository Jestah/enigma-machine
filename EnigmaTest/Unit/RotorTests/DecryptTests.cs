using Enigma;

namespace EnigmaTest.RotorTests;

public class DecryptTests
{
    
    private readonly Rotor _rotor = EncryptionDiscFactory.CreateRotorOneEncryptionDisc();

    [Theory]
    [InlineData('A')]
    [InlineData('a')]
    public void encrypt_decrypt_originalChar(char inputChar)
    {
        ResetRotorPosition(_rotor);
        var encrypted = _rotor.Encrypt(inputChar);

        ResetRotorPosition(_rotor);
        var decrypted = _rotor.Decrypt(encrypted);
        
        Assert.Equal(inputChar, decrypted);
    }
    
    private static void ResetRotorPosition(IRotor rotor)
    {
        rotor.RotorPosition = 4;
    }
}