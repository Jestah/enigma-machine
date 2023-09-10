namespace Enigma;

public interface IRotor : IEncryptionDisc
{
	int RotorPosition { get; set; }
	char[] TurnoverChars { get; set; }
    
	void Turn(int turnAmount);

	bool IsNotchAligned();
}