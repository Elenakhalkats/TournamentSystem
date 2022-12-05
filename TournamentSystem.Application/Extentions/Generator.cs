namespace TournamentSystem.Application.Extentions;

public class Generator
{
    private static readonly Random random = new Random();
    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    public static bool RandomBool()
    {
        var rand = random.Next(2) == 0;
        return rand;
    }
}