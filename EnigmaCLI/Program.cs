using System.Text.RegularExpressions;
using Enigma;

namespace EnigmaCLI;

public static partial class Program
{
    public static void Main()
    {
        EnigmaMachine enigmaMachine = new EnigmaMachine(EncryptionDiscFactory.CreateEtwEncryptionDisc(),
            EncryptionDiscFactory.CreateUkwEncryptionDisc(),
            EncryptionDiscFactory.CreateRotorOneEncryptionDisc(),
            EncryptionDiscFactory.CreateRotorTwoEncryptionDisc(),
            EncryptionDiscFactory.CreateRotorThreeEncryptionDisc());

        var cmd = new Commands(enigmaMachine);

        while (!cmd.Exiting)
        {
            Console.WriteLine(RotorPositionAscii(enigmaMachine));
            var cmdline = Console.ReadLine();
            var cmdArgs = MyRegex().Split(cmdline?.Trim() ?? string.Empty);
            if (!cmd.TryInvokeMember(cmdArgs[0], cmdArgs.Skip(1).ToArray()))
                Console.WriteLine($"Unknown command: {cmdArgs[0]}");
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

    [GeneratedRegex(@"\s+")]
    private static partial Regex MyRegex();
}