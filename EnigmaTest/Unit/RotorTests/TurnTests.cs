using Enigma;

namespace EnigmaTest.RotorTests;

public class TurnTests
{
    private readonly Rotor _rotor = EncryptionDiscFactory.CreateRotorOneEncryptionDisc();

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void turnNonPositiveAmount_throwException(int turnAmount)
    {
        Assert.ThrowsAny<Exception>((() => _rotor.Turn(turnAmount)));
    }
}