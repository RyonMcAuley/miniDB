namespace miniDB.Logging;

public class MiniLogger : IMiniLogger
{
    public void Log(string log)
    {
        Console.WriteLine(log);
    }

    public void LogWarning(string log)
    {
        Console.WriteLine("WARN: " + log);
    }

    public void LogError(string log)
    {
        Console.WriteLine("ERR: " + log);
    }
}
