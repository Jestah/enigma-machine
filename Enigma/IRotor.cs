namespace Enigma;

public interface IRotor
{
	int RotorPosition { get; set; }
	char[] TurnoverChars { get; set; }
    
	void Turn(int turnAmount);

	char Encrypt(char inputChar);
	char Decrypt(char inputChar);
	bool IsNotchAligned();
}