using Enigma;

namespace EnigmaTest.Unit.EncryptionDiscTests;

public class EncryptionTest
{
    private static readonly EncryptionDisc Disc = EncryptionDiscFactory.CreateRotorOneEncryptionDisc();
    private static readonly HashSet<char> DiscDomain = Disc.EncryptionMapping.Select(m => m.Item1).ToHashSet();

    
    
    [Theory]
    [MemberData(nameof(GetDiscDomain))]
    [MemberData(nameof(GetDiscDomainLower))]
    public void encrypt_resultInMappingDomain(char inputChar)
    {
        if (DiscDomain == null) Assert.Fail("Rotor domain is null.");
        var encrypted = Disc.Encrypt(inputChar);
        Assert.Contains(char.ToUpper(encrypted), DiscDomain);
    }
    
    public static IEnumerable<object[]> GetDiscDomain()
    {
        foreach (var key in DiscDomain)
        {
            yield return new object[] { key };
        }
    }
    public static IEnumerable<object[]> GetDiscDomainLower()
    {
        foreach (var key in DiscDomain)
        {
            yield return new object[] { char.ToLower(key) };
        }
    }
}