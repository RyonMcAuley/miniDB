namespace miniDB.Logging;

public class MiniLogger : IMiniLogger
{
    public void Log(string log)
    {
        Console.WriteLine(log);
    }
}
