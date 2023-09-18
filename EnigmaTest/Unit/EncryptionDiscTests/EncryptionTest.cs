using System.Globalization;
using Enigma;

namespace EnigmaTest.Unit.EncryptionDiscTests;

public class EncryptionTest
{
    private static readonly EncryptionDisc Disc = EncryptionDiscFactory.CreateRotorOneEncryptionDisc();
    private static readonly HashSet<char> DiscDomain = Disc.EncryptionMapping.Select(m => m.Item1).ToHashSet();

    [Theory]
    [MemberData(nameof(GetDiscDomain))]
    [MemberData(nameof(GetDiscDomainLower))]
    public void encryptValidChar_resultInMappingDomain(char inputChar)
    {
        var encrypted = Disc.Encrypt(inputChar);
        Assert.Contains(char.ToUpper(encrypted, CultureInfo.CurrentCulture), DiscDomain);
    }


    [Theory]
    [InlineData('$')]
    [InlineData(' ')]
    [InlineData('`')]
    public void charNotInDiscMapping_encrypt_sameAsInputChar(char inputChar)
    {
        var result = Disc.Encrypt(inputChar);

        Assert.Equal(inputChar, result);
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
            yield return new object[] { char.ToLower(key, CultureInfo.CurrentCulture) };
        }
    }
}