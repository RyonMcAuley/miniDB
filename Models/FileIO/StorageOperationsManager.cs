using miniDB.Logging;

namespace miniDB.Files;

public class StorageOperationsManager(IMiniLogger logger) : IStorageOperationsManager
{
    public async Task<bool> CreateTable(string[] specs)
    {
        logger.Log("CreateTable: " + specs[0]);
        //todo persist to file
        return true;
    }
}
