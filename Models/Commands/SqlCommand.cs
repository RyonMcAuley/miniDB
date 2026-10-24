using miniDB.Models;
using miniDB.QueryEngine;

namespace miniDB.Commands;


public class SqlCommand
{
}
public class SqlCommandHandler(IQueryEngine queryEngine)
{
    public async Task<bool> Handle(SqlCommandRequest command)
    {
        ArgumentNullException.ThrowIfNull(command);
        return await queryEngine.ExecuteAsync(command.sql) == null;
    }
}
