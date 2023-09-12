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
        // if (RotorDomain == null) Assert.Fail("Rotor domain is null.");

        var encrypted = Rotor.Encrypt(inputChar);
        
        Assert.Contains(encrypted, RotorDomain);
    }
    
    [Theory]
    [MemberData(nameof(GetRotorDomainLower))]
    public void encryptLower_resultInLowerMappingDomain(char inputChar)
    {
        // set rotor positions so that rotor encryption works even when rotor is not at base positions
        Rotor.RotorPosition = RotorDomain.Count - 1;
        if (RotorDomain == null) Assert.Fail("Rotor domain is null.");
        
        var encrypted = Rotor.Encrypt(inputChar);
        
        Assert.Contains(encrypted, RotorDomain.Select(char.ToLower));
    }

    [Theory]
    [InlineData('A', 'B')]
    [InlineData('B', 'D')]
    [InlineData('C', 'A')]
    [InlineData('D', 'C')]
    public void rotorPositionNotDefault_encrypt_expectedOutputChar(char input, char expectedOutput)
    {
        var encryptionMapping = new List<Tuple<char, char>>()
        {
            new('A', 'D'),
            new('B', 'C'),
            new('C', 'A'),
            new('D', 'B')
        };
        var rotor = new Rotor(encryptionMapping)
        {
            RotorPosition = 1
        };

        var encrypted = rotor.Encrypt(input);
        Assert.Equal(expectedOutput, encrypted);
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
