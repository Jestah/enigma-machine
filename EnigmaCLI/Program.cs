using System.Text.RegularExpressions;

namespace EnigmaCLI;
using Enigma;

public static class Program
{
    public static void Main()
    {
        

        
        EnigmaMachine enigmaMachine = new EnigmaMachine(EncryptionDiscFactory.CreateEtwEncryptionDisc(),
            EncryptionDiscFactory.CreateUkwEncryptionDisc(),
            EncryptionDiscFactory.CreateRotorOneEncryptionDisc(),
            EncryptionDiscFactory.CreateRotorTwoEncryptionDisc(),
            EncryptionDiscFactory.CreateRotorThreeEncryptionDisc());
        
        var cmd = new Commands(enigmaMachine);

        while (!cmd.Exiting) {
            Console.WriteLine(RotorPositionAscii(enigmaMachine));
            var cmdline = Console.ReadLine();
            var cmdargs = Regex.Split(cmdline.Trim(), @"\s+");
            if (!cmd.TryInvokeMember(cmdargs[0], cmdargs.Skip(1).ToArray()))
                Console.WriteLine($"Unknown command: {cmdargs[0]}");
        }
    }
    
    private static string RotorPositionAscii(EnigmaMachine enigmaMachine)
    {
        var displayRow = "* ";
        
        foreach (var rotorPosition in enigmaMachine.GetRotorPositions())
        {
            displayRow = string.Concat(displayRow, $"{rotorPosition:00} ");
        }

        displayRow = string.Concat(displayRow, "*");

        return $"{new string('*', displayRow.Length)}\n{displayRow}\n{new string('*', displayRow.Length)}\n";
    }
}