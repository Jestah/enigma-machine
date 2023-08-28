using System.Collections.ObjectModel;
using Enigma;

namespace EnigmaTest.Unit.RotorTests;

public class EncryptTests
{
    private static readonly Rotor Rotor = EncryptionDiscFactory.CreateRotorOneEncryptionDisc();
    private static readonly HashSet<char> RotorDomain = Rotor.EncryptionMapping.Select(m => m.Item1).ToHashSet();
    
    
    [Theory]
    [MemberData(nameof(GetRotorDomain))]
    public void encryptUpper_resultInUpperMappingDomain(char inputChar)
    {
        if (RotorDomain == null) Assert.Fail("Rotor domain is null.");
        var encrypted = Rotor.Encrypt(inputChar);
        Assert.Contains(encrypted, RotorDomain);
    }
    
    [Theory]
    [MemberData(nameof(GetRotorDomainLower))]
    public void encryptLower_resultInLowerMappingDomain(char inputChar)
    {
        if (RotorDomain == null) Assert.Fail("Rotor domain is null.");
        var encrypted = Rotor.Encrypt(inputChar);
        Assert.Contains(encrypted, RotorDomain.Select(char.ToLower));
    }
    
    public static IEnumerable<object[]> GetRotorDomain()
    {
        foreach (var key in RotorDomain)
        {
            yield return new object[] { key };
        }
    }
    public static IEnumerable<object[]> GetRotorDomainLower()
    {
        foreach (var key in RotorDomain)
        {
            yield return new object[] { char.ToLower(key) };
        }
    }
}
