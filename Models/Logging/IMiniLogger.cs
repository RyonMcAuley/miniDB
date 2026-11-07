namespace miniDB.Logging;

public interface IMiniLogger
{
    public void Log(string sql);
    public void LogWarning(string sql);
    public void LogError(string sql);
}
