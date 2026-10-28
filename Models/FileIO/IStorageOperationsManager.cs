namespace miniDB.Files;

public interface IStorageOperationsManager
{
    // Create a table with a name (string[0]) and columns (string[1-n])
    public Task<bool> CreateTable(string[] specs);
}
