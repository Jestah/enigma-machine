namespace Enigma;

public class Program
{
    private static void Main(string[] args)
    {
        var etw = EncryptionDiscFactory.CreateEtwEncryptionDisc();
        var ukw = EncryptionDiscFactory.CreateUkwEncryptionDisc();
        var rotorOne = EncryptionDiscFactory.CreateRotorOneEncryptionDisc();
        var rotorTwo = EncryptionDiscFactory.CreateRotorTwoEncryptionDisc();
        var rotorThree = EncryptionDiscFactory.CreateRotorThreeEncryptionDisc();
        
        rotorOne.RotorPosition = 1;
        rotorTwo.RotorPosition = 1;
        rotorThree.RotorPosition = 1;
        
        // EnigmaMachine enigmaMachine = new(etw, ukw, rotorOne, rotorTwo, rotorThree);

        // var encrypted = enigmaMachine.Encrypt("A");
        //
        // Console.Out.WriteLine("encrypted = {0}", encrypted);
        //
        // rotorOne.RotorPosition = 1;
        // rotorTwo.RotorPosition = 1;
        // rotorThree.RotorPosition = 1;
        //
        // var decrypted = enigmaMachine.Encrypt(encrypted);
        //
        // Console.Out.WriteLine("decrypted = {0}", decrypted);



    }
}