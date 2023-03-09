using DotNetEnv;

namespace PreviredTesting;

public class Credentials
{
    public string TokenApi { get; }
    public string PathFileTest = ".files/planillaTest.pdf";

    private Credentials()
    {
        Env.Load();
        TokenApi = Env.GetString("TokenApi");
    }

    private static Credentials? _instance;

    public static Credentials Instance => _instance ??= new Credentials();
}