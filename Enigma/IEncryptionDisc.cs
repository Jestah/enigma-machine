namespace Enigma;

public interface IEncryptionDisc
{
	ICollection<Tuple<char, char>> EncryptionMapping { get; }
	public int DiscSize { get; }

	/// <summary>
	/// Encrypts a character.
	/// </summary>
	/// <param name="inputChar">The character to encrypt</param>
	/// <returns>The encrypted char</returns>
	public char Encrypt(char inputChar);

	/// <summary>
	/// Decrypts a character. This is equivalent to running the letter through the Encryption disk from the other side.
	/// </summary>
	/// <param name="inputChar">The character to decrypt</param>
	/// <returns>Decrypted char</returns>
	public char Decrypt(char inputChar);
}