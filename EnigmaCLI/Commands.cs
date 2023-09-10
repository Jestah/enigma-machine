using System.Diagnostics.CodeAnalysis;
using System.Text;
using Enigma;

namespace EnigmaCLI;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class Commands {
    public bool Exiting { get; private set; }
    private EnigmaMachine _enigmaMachine;

    public Commands(EnigmaMachine enigmaMachine)
    {
        Exiting = false;
        _enigmaMachine = enigmaMachine;
    }

    public void exit() {
        Exiting = true;
    }

    public string encrypt(string[] inputString)
    {
        return "The encrypted string is: " + _enigmaMachine.Encrypt(string.Join(string.Empty, inputString));
    }
    
    public string decrypt(string[] inputString)
    {
        return "The decrypted string is: " + _enigmaMachine.Encrypt(string.Join(string.Empty, inputString));
    }
    
    public string setpositions(string[] positions)
    {
        /*
         * try to convert string positions into int positions.
         * return an error message if error
         */
        
        try
        {
            var rotorPositions = new int[positions.Length];

            for (int i = 0; i < positions.Length; i++)
            {
                rotorPositions[i] = int.Parse(positions[i]);
            }
            
            _enigmaMachine.SetRotorPositions(rotorPositions);

            return "Rotor positions updated. The new positions are:";
        }
        catch (Exception e)
        {
            return e.Message;
        }
        
    }

    public bool TryInvokeMember(string methodName, object[] args) {
        var method = typeof(Commands).GetMethod(methodName.ToLower());

        if (method != null) {
            object? res;
            
            if (method.GetParameters().Length > 0)
                res = method.Invoke(this, new object[] { args });
            else
                res = method.Invoke(this, Array.Empty<object>());

            if (method.ReturnType != typeof(void))
                Console.WriteLine(res?.ToString());

            return true;
        }

        return false;
    }

    
}