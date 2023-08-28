using Enigma;

namespace EnigmaTest.Unit.RotorTests;

public class EncryptTests
{
    private static readonly Rotor Rotor = EncryptionDiscFactory.CreateRotorOneEncryptionDisc();
    private static readonly Dictionary<char, char>.KeyCollection? RotorDomain = Rotor.EncryptionMapping.Keys;

    // public EncryptTests()
    // {
    //     _rotorDomain ;
    // }
    
    [Theory]
    [MemberData(nameof(GetRotorDomain))]
    public void encrypt_resultInMappingDomain(char inputChar)
    {
        if (RotorDomain == null) Assert.Fail("Rotor domain is null.");
        var encrypted = Rotor.Encrypt(inputChar);
        Assert.Contains(encrypted, RotorDomain);
    }
    
    public static IEnumerable<object[]> GetRotorDomain()
    {
        foreach (var key in RotorDomain)
        {
            yield return new object[] { key };
        }
    }
}
