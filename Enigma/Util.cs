namespace Enigma;

public static class Util
{
    public static int Mod(int a, int b)
    {
        var c = a % b;
        if ((c < 0 && b > 0) || (c > 0 && b < 0))
        {
            c += b;
        }
        return c;
    }
}